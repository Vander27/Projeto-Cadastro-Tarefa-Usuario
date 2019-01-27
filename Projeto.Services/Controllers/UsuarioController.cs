using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projeto.Repository.Entities; //importando..
using Projeto.Repository.Persistence; //importando..
using Projeto.Services.Models; //importando..
using Projeto.Services.Utils; //importando..
using AutoMapper;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        //serviço para realizar o cadastro do usuário..
        [HttpPost] //requisições do tipo POST
        [Route("cadastrar")] //ENDPOINT: /api/usuario/cadastrar
        public HttpResponseMessage Cadastrar(UsuarioCadastroViewModel model)
        {
            //verificar se os dados passaram nas regras de validação..
            if(ModelState.IsValid)
            {
                try
                {
                    UsuarioRepository rep = new UsuarioRepository();

                    //verificando se o login do usuário não existe no banco..
                    if(! rep.LoginExistente(model.LoginAcesso))
                    {
                        Usuario u = Mapper.Map<Usuario>(model);
                        rep.Inserir(u); //gravando..

                        return Request.CreateResponse(HttpStatusCode.OK, "Usuário cadastrado com sucesso.");
                    }
                    else
                    {
                        //retornar um status de erro..
                        return Request.CreateResponse(HttpStatusCode.BadRequest, 
                                $"O Login {model.LoginAcesso} já está cadastrado.");
                    }                    
                }
                catch(Exception e)
                {
                    //retornar status de erro 500 (Erro interno de servidor)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                var erros = ValidationUtil.GetErrors(ModelState);
                return Request.CreateResponse(HttpStatusCode.BadRequest, erros);
            }
        }
    }
}
