using Aplication.Model;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovcontabilClone.Context;
using MovcontabilClone.Services;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovcontabilClone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriarUsuarioController : Controller
    {
        private readonly MovContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private string host = "localhost:6379";
        private readonly IEmailService  _emailService;
        public CriarUsuarioController(MovContext context, IMapper mapper, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
            _emailService = emailService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioViewModel>> Get()

        {
            var usuario = _context.Usuarios.Include(x => x.Empresas).Include(x => x.PapelUsuario).ToList();
            var usuarioViewModel = usuario.Select(x => _mapper.Map<UsuarioViewModel>(x)).ToList();
            return usuarioViewModel;
        }
        // o id da url é passado para o metodo
        [HttpGet("{id}", Name = "detalhesUsuario")]
        public ActionResult<UsuarioViewModel> Get(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = _context.Usuarios.Where(x => x.Id == id).Include(x => x.PapelUsuario).ThenInclude(x => x.Papel).FirstOrDefault();
            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UsuarioViewModel usuarioModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioModel);
            var papel = usuarioModel.Papel;
            emailInvalido(usuario.Email);
            if (await EmailRepetido(usuario))
                return BadRequest("E-mail já cadastrado");
            try
            {
                
                HashSenha(usuario);
                
                usuario.Empresas = null;
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                if (usuarioModel.Papel.Count > 0)
                    await SalvarPapelUsuario(usuario, _mapper.Map<List<Papel>>(papel));

                if (usuarioModel.Empresas is not null)
                    await SalvarEmpresaUsuario(usuario, usuarioModel.Empresas);
                var usuarioView = _mapper.Map<UsuarioViewModel>(usuario);
                return Ok(GeraToken(usuario));

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UsuarioViewModel usuarioModel)
        {
            try
            {
                var usuario = _context.Usuarios.Where(x => x.Id == id).Include(x => x.PapelUsuario).Include(x => x.Empresas).AsNoTracking().FirstOrDefault();
                if (usuario == null)
                    return NotFound();
                else
                {
                    var teste = _mapper.Map<Usuario>(usuarioModel);
                    HashSenha(usuario);
                    _context.Usuarios.Update(_mapper.Map<Usuario>(usuarioModel));
                    var PapelJaCadastrado = _context.PapelUsuario.Where(x=> x.UsuarioId == usuario.Id).AsNoTracking().ToList();
                    if (usuarioModel.Papel != null)
                    {
                        // maneira alternativa 
                        //foreach (var item in usuario.Papel)
                        //{
                        //    if (!PapelJaCadastrado.Any(x => x.IdPapel == item.Id))
                        //    {
                        //        var papelUsuario = new UsuarioPapel
                        //        {
                        //            IdPapel = item.Id,
                        //            IdUsuario = usuario.Id
                        //        };
                        //        _context.UsuariosPapeis.Add(papelUsuario);
                        //    }
                        //}

                        var excluirPapeis = PapelJaCadastrado.Where(x => !usuarioModel.Papel.Select(s => s.Id).Contains(x.PapelId)).ToList();
                        var adcionarPapeis = usuarioModel.Papel.Where(x => !PapelJaCadastrado.Select(p => p.PapelId).Contains(x.Id)).ToList();

                        _context.PapelUsuario.RemoveRange(excluirPapeis);
                        
                        _context.PapelUsuario.AddRange(adcionarPapeis.Select(x => new UsuarioPapel
                        {
                            PapelId = x.Id,
                            UsuarioId = usuario.Id
                        }));
                       
                    }
                    _context.SaveChanges();

                    if (usuarioModel.Empresas is not null)
                        await SalvarEmpresaUsuario(usuario, usuarioModel.Empresas);

                    return Ok();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<UsuarioViewModel> Delete(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                if (usuario == null)
                {
                    return NotFound();
                }
                else
                {
                    var PapelJaCadastrado = _context.PapelUsuario.AsNoTracking().ToList();
                    foreach (var item in PapelJaCadastrado)
                    {
                        if (item.UsuarioId == usuario.Id)
                            _context.PapelUsuario.Remove(item);
                        
                    }
                    _context.Usuarios.Remove(usuario);
                    DeletaEmpresa(id);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(Usuario usuario)
        {
            if (!await ValidaSenha(usuario))
                return BadRequest("Usuario ou senha invalidos");
            else
                return Ok(GeraToken(usuario));
        }

        [HttpGet("Teste")]
        public async Task<ActionResult> EmailTeste()
        {
          await  _emailService.SendEmmailAsync("Danilompr@hotmail.com", "teste","teste","Teste");
            return Ok();

        }
        [HttpPost("Refresh")]
        public async Task<ActionResult> Refresh([FromBody] Refresh refresh)
        {
            var principal = await GetClaims(refresh.Token);
            var email = principal.Identity.Name;
            var refreshTokenSalvo = GetRefreshToken(email).ToString();

            if (refresh.RefreshToken != refreshTokenSalvo)
                throw new SecurityTokenException("Refresh token invalido.");
            var usuario = _context.Usuarios.Where(x => x.Email == email).FirstOrDefault();
            var novotoken = await GeraToken(usuario);
            DeleteRefreshToken(email, refresh.RefreshToken);
            SaveRefreshToken(email, novotoken.Token);
            return Ok(novotoken);
        }
        [NonAction]
        private void DeletaEmpresa(int usuarioId)
        {
           var empresas= _context.EmpresaEstabelecimentos.Where(x => x.UsuarioId == usuarioId).AsNoTracking().ToList();
            empresas.ForEach(x =>
            {
                x.UsuarioId = null;
                _context.EmpresaEstabelecimentos.Update(x);
            });
        }

        [NonAction]
        private void HashSenha(Usuario usuario)
        {
            var passwordHash = new PasswordHasher<Usuario>();
            usuario.Senha = passwordHash.HashPassword(usuario, usuario.Senha);
        }
        [NonAction]
        private async Task<bool> ValidaSenha(Usuario usuario)
        {
            var usuarioNaBase = await GetUserByEmail(usuario);
            if (usuarioNaBase is null)
                return false;
            var passwordHash = new PasswordHasher<Usuario>();
            var status = passwordHash.VerifyHashedPassword(usuario, usuarioNaBase.Senha, usuario.Senha);
            if (status == PasswordVerificationResult.Success)
                return true;
            else
                return false;

        }

        [NonAction]
        private async Task<Usuario> GetUserByEmail(Usuario usuarioView)
        {
            return _context.Usuarios.Where(x => x.Email == usuarioView.Email).FirstOrDefault();
        }

        [NonAction]
        private async Task<bool> EmailRepetido(Usuario usuarioView)
        {
            if (_context.Usuarios.Where(x => x.Email == usuarioView.Email).FirstOrDefault() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [NonAction]
        private async Task<UsuarioToken> GeraToken(Usuario usuario)
        {
            /// claims não são obigatorios, para deixar mais seguro
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            // gerar uma chave privada
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credencials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracao = _configuration["TokenConfiguration:ExpireHours"];
            var expiration = DateTime.UtcNow.AddHours(double.Parse(expiracao));
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credencials
                );
            var refreshToken = GerarRefreshToken();
            SaveRefreshToken(usuario.Email, refreshToken);
            return new UsuarioToken()
            {
                Autenticado = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expirado = expiration,
                Mensagem = "Token Ok"
            };
        }

        [NonAction]
        private string GerarRefreshToken()
        {
            var guid = Guid.NewGuid().ToString();
            return guid;
        }

        [NonAction]
        private async Task<ClaimsPrincipal> GetClaims(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidAudience = _configuration["TokenConfiguration:Audience"],
                ValidIssuer = _configuration["TokenConfiguration:Issuer"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
            };

            var tokeHandler = new JwtSecurityTokenHandler();
            var principal = tokeHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.OrdinalIgnoreCase))
                throw new SecurityTokenException("Token Invalido");
            return principal;
        }


        [NonAction]
        private void SaveRefreshToken(string email, string refreshToken)
        {

            using (var redisClient = new RedisClient(host))
            {
                redisClient.SetValue(email, refreshToken);

            }
        }

        [NonAction]
        private string GetRefreshToken(string email)
        {
            var refreshToken = "";
            using (var redisClient = new RedisClient(host))
            {
                var bit = redisClient.GetValue(email);
                refreshToken = bit;

            }
            return refreshToken;
        }

        [NonAction]
        private void DeleteRefreshToken(string email, string refreshToken)
        {
            using (var redisClient = new RedisClient(host))
            {
                redisClient.Del(email);

            }
        }

        [NonAction]
        private async Task SalvarPapelUsuario(Usuario usuario, List<Papel> papeis)
        {
            var usuarioSalvo = await GetUserByEmail(usuario);
            foreach (var papel in papeis)
            {
                var papelUsuario = new UsuarioPapel
                {
                    PapelId = papel.Id,
                    UsuarioId = usuarioSalvo.Id
                };
                _context.PapelUsuario.Add(papelUsuario);

            }
            _context.SaveChanges();
        }

        [NonAction]
        private async Task SalvarEmpresaUsuario(Usuario usuario, List<EmpresaEstabelecimentoViewModel> empresas)
        {
            var usuarioSalvo = await GetUserByEmail(usuario);
            var empresassalvasParausuario = _context.EmpresaEstabelecimentos.Where(x=> x.UsuarioId == usuario.Id).AsNoTracking().ToList();
            var empresasASeremCadastradas = empresas.Where(x => !empresassalvasParausuario.Select(e => e.Id).Contains(x.Id)).ToList();
            var empresasASeremRemovidas = empresassalvasParausuario.Where(x => !empresas.Select(e => e.Id).Contains(x.Id)).ToList();

            if (empresasASeremRemovidas.Count > 0)
            {
                empresasASeremRemovidas.ForEach(x =>
                {
                    x.UsuarioId = null;
                    _context.EmpresaEstabelecimentos.Update(x);
                });
            }

            if (empresasASeremCadastradas.Count > 0)
            {
                empresasASeremCadastradas.ForEach(x =>
                {
                    x.UsuarioId = usuario.Id;
                    _context.EmpresaEstabelecimentos.Update(_mapper.Map<EmpresaEstabelecimento>(x));
                });
            }
            _context.SaveChanges();
        }
        private void emailInvalido(string emailRecebido)
        {
            try
            {
                MailAddress email = new MailAddress(emailRecebido);
            }
            catch (FormatException ex)
            {

                throw new FormatException("E-mail não cumpre os requisitos necessarios.");
            } 
        }
    }
}

