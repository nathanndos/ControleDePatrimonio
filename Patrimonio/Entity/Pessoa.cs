using System;
namespace Entity;

public class Pessoa
{
    public Guid Ide { get; set; }
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Status { get; set; }

    public Pessoa()
    {
        Ide = Guid.Empty;
        Id = 0;
        Nome = string.Empty;
        Status = 0;
    }
}
