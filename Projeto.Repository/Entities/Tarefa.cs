namespace Projeto.Repository.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tarefa")]
    public partial class Tarefa
    {
        [Key]
        public int IdTarefa { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        public DateTime DataHora { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(15)]
        public string Status { get; set; }

        public int IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
