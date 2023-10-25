using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public abstract class EntityBase
    {
        [Key()]
        public int Id { get; set; } = 0;
        public Guid Ide { get; set; } = Guid.Empty;
        public int Status { get; set; } = 0;
    }
}
