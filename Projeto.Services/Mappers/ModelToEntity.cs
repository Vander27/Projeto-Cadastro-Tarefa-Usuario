using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Projeto.Repository.Entities; //importando..
using Projeto.Services.Models; //importando..
using Projeto.Services.Utils; //importando..

namespace Projeto.Services.Mappers
{
    public class ModelToEntity : Profile
    {
        //construtor..
        public ModelToEntity()
        {
            //mapear a troca de dados entre 
            //UsuarioCadastroViewModel -> Usuario

            //DE -> PARA
            CreateMap<UsuarioCadastroViewModel, Usuario>()
                .AfterMap((src, dest) =>
                    dest.SenhaAcesso = CriptografiaUtil.Encriptar(src.SenhaAcesso))
                .AfterMap((src, dest) =>
                    dest.DataCriacao = DateTime.Now);
        }
    }
}