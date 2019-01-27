using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Repository.Entities;
using Projeto.Repository.Generics;
using Projeto.Repository.Context;

namespace Projeto.Repository.Persistence
{
    public class UsuarioRepository
        : GenericRepository<Usuario>
    {
        public bool LoginExistente(string login)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Usuario
                          .Count(u => u.LoginAcesso.Equals(login)) > 0;
            }
        }

        public Usuario Obter(string login, string senha)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Usuario
                          .FirstOrDefault(u => u.LoginAcesso.Equals(login)
                                            && u.SenhaAcesso.Equals(senha));
            }
        }
    }
}
