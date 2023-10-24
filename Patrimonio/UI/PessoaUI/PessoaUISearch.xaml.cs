using BLL;
using Entity;
using Patrimonio.Util;
using System.Windows;
using System.Windows.Input;

namespace Patrimonio.UI.PessoaUI;

public partial class PessoaUISearch : Window
{
    public Pessoa pessoa = new Pessoa();

    public PessoaUISearch()
    {
        InitializeComponent();
        dataGridPessoas.ItemsSource = PessoaBLL.listBySearch(string.Empty);
    }

    private void btnConfirmar_Click(object sender, RoutedEventArgs e)
    {
        pessoa = dataGridPessoas.getSelectItem<Pessoa>();
        DialogResult = true;
    }

    private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {

    }

    private void btnBuscar_Click(object sender, RoutedEventArgs e) => callBuscar();

    private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
            callBuscar();
        else if (e.Key.Equals(Key.Escape))
            DialogResult = false;
    }

    private void callBuscar()
    {
        dataGridPessoas.ItemsSource = PessoaBLL.listBySearch(txtBuscar.getStringValue());
    }
}
