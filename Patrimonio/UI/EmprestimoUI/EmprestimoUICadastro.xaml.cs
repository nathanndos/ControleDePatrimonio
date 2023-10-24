using Entity;
using Patrimonio.BLL;
using Patrimonio.UI.PessoaUI;
using Patrimonio.Util;
using System.Windows;
namespace Patrimonio.UI;

public partial class EmprestimoUICadastro : Window
{
    Pessoa pessoa;
    Equipamento equipamento;

    public EmprestimoUICadastro()
    {
        InitializeComponent();
    }

    private void btnSalvar_Click(object sender, RoutedEventArgs e)
    {
        Emprestimo emprestimo = new Emprestimo();
        emprestimo.Pessoa = pessoa;
        emprestimo.Equipamento = equipamento;

        EmprestimoBLL.save(emprestimo);
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

        if (value ?? false)
        {
            pessoa = ui.pessoa;
            fillPessoa();
        }
    }

    private void btnBuscarEquipamento_Click(object sender, RoutedEventArgs e)
    {

    }

    private void fillPessoa()
    {
        txtPessoaId.Text = pessoa.Id.ToString();
        txtPessoaNome.Text = pessoa.Nome;
    }

    private void fillEquipamento()
    {
        txtEquipamentoNome.Text = equipamento.Nome;
        txt
    }
}
