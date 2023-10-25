using System;
namespace Entity;

public class Pessoa : EntityBase
{
    public string Nome { get; set; }

    public Pessoa()
    {
        Nome = string.Empty;
    }
}
