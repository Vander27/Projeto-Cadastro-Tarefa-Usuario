using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper; //importando..
using Projeto.Services.Mappers; //importando..

namespace Projeto.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //registrar o automapper..
            Mapper.Initialize(m => 
            {
                m.AddProfile<EntityToModel>(); //adicionando..
                m.AddProfile<ModelToEntity>(); //adicionando..
            });
        }
    }
}
