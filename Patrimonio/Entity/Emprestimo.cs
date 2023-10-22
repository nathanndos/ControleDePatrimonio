using Entity.Enum;
using System;
namespace Entity;

public class Emprestimo : EntityBase
{
    public Pessoa Pessoa { get; set; }
    public Equipamento Equipamento { get; set; }
    public SituacaoEmprestimoEnumerator Situacao { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime DataFechamento { get;set; }
    public string Observacao { get; set; }

    public Emprestimo()
    {
        Id = 0;
        Ide = Guid.Empty;
        Pessoa = new Pessoa();
        Equipamento = new Equipamento();
        Situacao = SituacaoEmprestimoEnumerator.None;
        DataAbertura =
            DataFechamento = new DateTime(1900, 1 ,1);
        Observacao = string.Empty;
    }
}