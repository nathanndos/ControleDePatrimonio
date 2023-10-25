using Entity;
using Patrimonio.BLL;
using Patrimonio.UI;
using System.Linq;
using System.Windows;
using UI;
using UI.PessoaUI;

namespace Patrimonio;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var teste = dbContext.get.Emprestimo.ToList();
        var teste2 = teste.FirstOrDefault();
        dataGridEmprestimos.ItemsSource = EmprestimoBLL.listBySearch(string.Empty);
    }

    private void btnEquipamentos_Click(object sender, RoutedEventArgs e)
    {
        EquipamentoUIView equipamentos = new EquipamentoUIView();
        equipamentos.Show();
    }

    private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        EmprestimoUICadastro emprestimoUICadastro = new EmprestimoUICadastro();
        emprestimoUICadastro.Show();
    }

    private void btnPessoas_Click(object sender, RoutedEventArgs e)
    {
        PessoaView pessoaView = new PessoaView();
        pessoaView.Show();
    }

    private void btnNovoEmprestimo_Click(object sender, RoutedEventArgs e)
    {
        EmprestimoUICadastro emprestimoUICadastro = new EmprestimoUICadastro();
        emprestimoUICadastro.Show();
    }
}
