using Aplication.Model;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovcontabilClone.Context;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        public CriarUsuarioController(MovContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioViewModel>> Get()

        {
            var usuario = _context.Usuarios.ToList();
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
            var usuario = _context.Usuarios.Where(x => x.Id == id).Include(x => x.UsuariosPapeis).ThenInclude(x => x.Papel).FirstOrDefault();
            return _mapper.Map<UsuarioViewModel>(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] UsuarioViewModel usuarioModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioModel);
            if (await EmailRepetido(usuario))
                return BadRequest("E-mail já cadastrado");
            try
            {
                HashSenha(usuario);
                _context.Add(usuario);

                if (usuario.Papel.Count > 0)
                {
                    foreach (var papel in usuario.Papel)
                    {
                        var papelUsuario = new UsuarioPapel
                        {
                            IdPapel = papel.Id,
                            IdUsuario = usuario.Id
                        };
                        _context.UsuariosPapeis.Add(papelUsuario);

                    }
                }
                _context.SaveChanges();
                var usuarioView = _mapper.Map<UsuarioViewModel>(usuario);
                return Ok(GeraToken(usuario));

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UsuarioViewModel usuarioModel)
        {
            try
            {
                var usuario = _context.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                if (usuario == null)
                    return NotFound();
                else
                {
                    HashSenha(usuario);
                    _context.Add(_mapper.Map<Usuario>(usuarioModel));
                    var PapelJaCadastrado = _context.UsuariosPapeis.AsNoTracking().ToList();
                    if (usuario.Papel != null)
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

                        var excluirPapeis = PapelJaCadastrado.Where(x => !usuario.Papel.Select(s => s.Id).Contains(x.IdPapel)).ToList();
                        var adcionarPapeis = usuario.Papel.Where(x => !PapelJaCadastrado.Select(p => p.IdPapel).Contains(x.Id)).ToList();

                        _context.UsuariosPapeis.RemoveRange(excluirPapeis);
                        _context.UsuariosPapeis.AddRange(adcionarPapeis.Select(x => new UsuarioPapel
                        {
                            IdPapel = x.Id,
                            IdUsuario = usuario.Id
                        }));
                    }

                    _context.SaveChanges();


                    return Ok();
                }
            }
            catch (Exception)
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
                    var PapelJaCadastrado = _context.UsuariosPapeis.AsNoTracking().ToList();
                    foreach (var item in PapelJaCadastrado)
                    {
                        if (item.IdUsuario == usuario.Id)
                            _context.UsuariosPapeis.Remove(item);
                    }
                    _context.Usuarios.Remove(usuario);
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


        [HttpPost("Refresh")]
        public async Task<ActionResult> Refresh([FromBody] Refresh refresh)
        {
            var principal =  await GetClaims(refresh.Token);
            var email = principal.Identity.Name;
            var refreshTokenSalvo =  GetRefreshToken(email).ToString();

            if (refresh.RefreshToken != refreshTokenSalvo)
                throw new SecurityTokenException("Refresh token invalido.");
            var usuario = _context.Usuarios.Where(x => x.Email == email).FirstOrDefault();
            var novotoken = await GeraToken(usuario);
            DeleteRefreshToken(email, refresh.RefreshToken);
            SaveRefreshToken(email, novotoken.Token);
            return Ok(novotoken);
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
                issuer:_configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credencials
                );
            var refreshToken = GerarRefreshToken();
            SaveRefreshToken(usuario.Email,refreshToken);
            return new UsuarioToken()
            {
                Autenticado = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken= refreshToken,
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
        private async  Task<ClaimsPrincipal> GetClaims(string token)
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
            return   principal;
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
    }
}

