using Entity;
using Patrimonio.BLL;
using Patrimonio.UI.EquipamentoUI;
using Patrimonio.UI.PessoaUI;
using Patrimonio.Util;
using System.Windows;
namespace Patrimonio.UI;

public partial class EmprestimoUICadastro : Window
{
    Emprestimo emprestimo { get; set; }
    Pessoa pessoa = new Pessoa();
    Equipamento equipamento = new Equipamento();

    public EmprestimoUICadastro()
    {
        InitializeComponent();
    }

    public EmprestimoUICadastro(Emprestimo emprestimo)
    {
        InitializeComponent();
        this.emprestimo = emprestimo;
        fillForm();
    }

    private void btnSalvar_Click(object sender, RoutedEventArgs e)
    {
        Emprestimo emprestimo = new Emprestimo();
        emprestimo.Pessoa = pessoa;
        emprestimo.Equipamento = equipamento;

        emprestimo = EmprestimoBLL.save(emprestimo);
        fillForm();
    }

    private void btnNovo_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnBuscarPessoa_Click(object sender, RoutedEventArgs e)
    {
        PessoaUISearch ui = new PessoaUISearch();
        bool? value = ui.ShowDialog();

        if (value.HasValue && value.Value)
            pessoa = ui.pessoaSelected;
        
        fillPessoa();
    }

    private void btnBuscarEquipamento_Click(object sender, RoutedEventArgs e)
    {
        EquipamentoUISearch ui = new EquipamentoUISearch();
        bool? value = ui.ShowDialog();

        if(value.HasValue && value.Value)
            equipamento = ui.equipamentoSelected;

        fillEquipamento();
    }

    private void fillForm()
    {
        fillPessoa();
        fillEquipamento();
    }

    private void fillPessoa()
    {
        txtPessoaId.Text = pessoa.Id.ToString();
        txtPessoaNome.Text = pessoa.Nome;
    }

    private void fillEquipamento()
    {
        txtEquipamentoNome.Text = equipamento.Nome;
        txtEquipamentoId.Text = equipamento.Id.ToString();
    }
}