using BLL;
using Entity;
using Patrimonio.Util;
using System.Windows;
using System.Windows.Input;

namespace Patrimonio.UI.EquipamentoUI;

public partial class EquipamentoUISearch : Window
{
    Equipamento equipamento = new Equipamento();

    public EquipamentoUISearch()
    {
        InitializeComponent();
        dataGridPessoas.ItemsSource = EquipamentoBLL.listBySearch(string.Empty);
    }

    private void btnConfirmar_Click(object sender, RoutedEventArgs e)
    {

    }

    private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {

    }

    private void btnBuscar_Click(object sender, RoutedEventArgs e) => callBuscar();

    private void txtBuscar_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
            callBuscar();
    }

    private void callBuscar() => dataGridPessoas.ItemsSource = EquipamentoBLL.listBySearch(txtBuscar.getStringValue());

    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Escape))
            DialogResult = false;
    }
}
