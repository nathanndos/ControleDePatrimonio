using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Equipamento : EntityBase
    {
        public string Nome { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataAquisicao { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Serial { get; set; }
        public virtual List<Emprestimo> Emprestimos { get; set; } =  new List<Emprestimo>();    

        public Equipamento()
        {
            Nome = string.Empty;
            DataAquisicao = new DateTime(1900, 1, 1);
            Serial = string.Empty;
        }
    }
}
