using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Patrimonio.Entity
{
    public class Equipamento
    {
        public int Id { get; set; }
        public Guid Ide { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataAquisicao { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Serial { get; set; }
        public int Status { get; set; } = 0;

        public Equipamento()
        {
            Ide = Guid.Empty;
            Nome = string.Empty;
            DataAquisicao = DateTime.Now;
            Serial = string.Empty;
            Status = 0;
        }
    }
}
