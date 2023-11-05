namespace Patrimonio.ConstantManager.Exception;

public class EmprestimoExceptionConstant
{
    public const string PessoaNaoInformada = "Pessoa não informada";
    public const string EquipamentoNaoInformado = "Equipamento não informado";
    public const string PrecisoSalvarParaFinalizarEmprestimo = "É necessário salvar antes de finalizar o empréstimo";
    public const string EmprestimoJaFinalizado = "Empréstimo já foi finalizado anteriormente!";
    public const string EquipamentoJaEmprestado = "Não é possível emprestar um equipamento já emprestado";
    public const string DeletarEquipamentoComEmprestimo = "Não é possível excluir equipamento com movimentação de empréstimo";
}
