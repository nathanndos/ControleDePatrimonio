using Entity.Enum;
using Patrimonio.Util;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity;

public class Emprestimo : EntityBase
{
    [ForeignKey("Pessoa")] 
    public int PessoaId { get; set; }
    public virtual Pessoa Pessoa { get; set; }
    [ForeignKey("Equipamento")] 
    public int EquipamentoId { get; set; }
    public virtual Equipamento Equipamento { get; set; }
    public SituacaoEmprestimoEnumerator Situacao { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime DataFechamento { get;set; }
    public string Observacao { get; set; }

    public Emprestimo()
    {
        Situacao = SituacaoEmprestimoEnumerator.None;
        DataAbertura =
            DataFechamento = new DateTime(1900, 1 ,1);
        Observacao = string.Empty;
    }

    public bool isFinalizado => DataFechamento.isNotDefaultDateTime();
    public bool isNotFinalizado => DataFechamento.isDefaultDateTime();
}