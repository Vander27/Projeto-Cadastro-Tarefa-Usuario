namespace Projeto.Repository.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entities;
    using System.Configuration;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["AULA21"].ConnectionString)
        {
        }

        public virtual DbSet<Tarefa> Tarefa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Tarefa)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
