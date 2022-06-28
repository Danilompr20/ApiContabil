using Aplication.Model;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication.Utils
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<EmpresaEstabelecimento, EmpresaEstabelecimentoViewModel>().ReverseMap() ;
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Papel, PapelViewModel>().ReverseMap();
            CreateMap<UsuarioPapel, UsuarioPapelViewModel>().ReverseMap();


        }
    }
}
