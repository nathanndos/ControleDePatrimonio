using Entity;
using Patrimonio.BLL;
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

        EmprestimoBLL.save();
    }

    private void btnNovo_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnBuscarPessoa_Click(object sender, RoutedEventArgs e)
    {

    }

    private void btnBuscarEquipamento_Click(object sender, RoutedEventArgs e)
    {

    }
}
