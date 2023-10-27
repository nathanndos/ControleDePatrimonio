using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Entity;

public class Pessoa : EntityBase
{
    public string Nome { get; set; }
    public virtual List<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();

    public Pessoa()
    {
        Nome = string.Empty;
    }
}
