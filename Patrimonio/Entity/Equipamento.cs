using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrimonio.Entity
{
    public class Equipamento
    {
        public int Id { get; set; }
        public Guid Ide { get; set; }
        public string Nome { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Serial { get; set; }

        public Equipamento()
        {
            Ide = Guid.Empty;
            Nome = string.Empty;
            DataAquisicao = DateTime.Now;
            Serial = string.Empty;
        }
    }
}
