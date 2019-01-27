using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Projeto.Services.Utils
{
    public class ValidationUtil
    {
        //método para retornar as mensagens de erro de validação
        //contidas no objeto ModelState
        public static Hashtable GetErrors(ModelStateDictionary ModelState)
        {
            //declarar uma variavel do tipo hashtable
            Hashtable erros = new Hashtable();

            //percorrer o ModelState
            foreach(var state in ModelState)
            {
                //verificar se contem erros de validação
                if(state.Value.Errors.Count > 0)
                {
                    //adicionar o erro no hashtable..
                    erros[state.Key] = state.Value.Errors.Select(e => e.ErrorMessage).ToList();
                }
            }

            //retornando as mensagens de erro..
            return erros;
        }
    }
}