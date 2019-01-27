using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Projeto.Services.Controllers
{
    [Authorize]
    [RoutePrefix("api/tarefa")]
    public class TarefaController : ApiController
    {

    }
}
