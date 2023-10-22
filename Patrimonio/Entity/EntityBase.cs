using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public abstract class EntityBase
    {
        [Column(TypeName = "INT NOT NULL")]
        public int Id { get; set; } = 0;
        public Guid Ide { get; set; } = Guid.Empty;
        public int Status { get; set; } = 0;
    }
}
