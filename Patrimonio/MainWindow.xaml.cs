using Entity;
using Patrimonio.BLL;
using Patrimonio.UI;
using Patrimonio.Util;
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
        dataGridEmprestimos.ItemsSource = EmprestimoBLL.listBySearch(string.Empty);
    }

    private void btnEquipamentos_Click(object sender, RoutedEventArgs e)
    {
        EquipamentoUIView equipamentos = new EquipamentoUIView();
        equipamentos.Show();
    }

    private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        EmprestimoUICadastro emprestimoUICadastro = new EmprestimoUICadastro(dataGridEmprestimos.getSelectItem<Emprestimo>());
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

    private void btnAtualizar_Click(object sender, RoutedEventArgs e) => dataGridEmprestimos.ItemsSource = EmprestimoBLL.listBySearch(string.Empty);
}
