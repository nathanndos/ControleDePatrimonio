using BLL;
using Entity;
using Patrimonio.Util;
using System;
using System.Windows;
using System.Windows.Input;

namespace Patrimonio.UI.PessoaUI;

public partial class PessoaUISearch : Window
{
    public Pessoa pessoaSelected = new Pessoa();

    public PessoaUISearch()
    {
        InitializeComponent();
        dataGridPessoas.ItemsSource = PessoaBLL.listBySearch(string.Empty);
        txtBuscar.Focus();
    }

    private void callSelect()
    {
        try
        {
            pessoaSelected = dataGridPessoas.getSelectItem<Pessoa>();
            DialogResult = true;
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void callBuscar()
    {
        try
        {
            dataGridPessoas.ItemsSource = PessoaBLL.listBySearch(txtBuscar.getStringValue());
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void btnConfirmar_Click(object sender, RoutedEventArgs e) => callSelect();

    private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e) => callSelect();

    private void btnBuscar_Click(object sender, RoutedEventArgs e) => callBuscar();

    private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
            callBuscar();
    }

    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Escape) && txtBuscar.IsFocused)
            DialogResult = false;
    }

    private void DataGridRow_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
            callSelect();
    }

    private void DataGridRow_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
            e.Handled = true;
    }
}