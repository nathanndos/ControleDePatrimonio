using System;

namespace Patrimonio.Entity
{
    public class EntityBase
    {
        public int Id { get; set; }
        public Guid Ide { get; set; }
        public int Status { get; set; }

        public EntityBase()
        {
            Id = 0;
            Ide = Guid.Empty;
            Status = 0;
        }
    }
}
