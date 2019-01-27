using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; //entidades
using Projeto.Repository.Context; //contexto

namespace Projeto.Repository.Generics
{
    public class GenericRepository<T>
        where T  : class
    {
        public virtual void Inserir(T obj)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(obj).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public virtual void Atualizar(T obj)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(obj).State = EntityState.Modified;
                ctx.SaveChanges();
            }
        }

        public virtual void Excluir(T obj)
        {
            using (DataContext ctx = new DataContext())
            {
                ctx.Entry(obj).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public virtual List<T> Consultar()
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Set<T>().ToList();
            }
        }

        public virtual T ConsultarPorId(int id)
        {
            using (DataContext ctx = new DataContext())
            {
                return ctx.Set<T>().Find(id);
            }
        }
    }
}
