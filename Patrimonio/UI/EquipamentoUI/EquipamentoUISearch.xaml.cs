using BLL;
using Entity;
using Patrimonio.Util;
using System;
using System.Windows;
using System.Windows.Input;

namespace Patrimonio.UI.EquipamentoUI;

public partial class EquipamentoUISearch : Window
{
    public Equipamento equipamentoSelected = new Equipamento();

    public EquipamentoUISearch()
    {
        InitializeComponent();
        dataGridEquipamentos.ItemsSource = EquipamentoBLL.listBySearch(string.Empty);
        txtBuscar.Focus();
    }

    private void callSelect()
    {
        try
        {
            equipamentoSelected = dataGridEquipamentos.getSelectItem<Equipamento>();
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
            dataGridEquipamentos.ItemsSource = EquipamentoBLL.listBySearch(txtBuscar.getStringValue());
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Escape))
            DialogResult = false;
    }

    private void btnConfirmar_Click(object sender, RoutedEventArgs e) => callSelect();

    private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => callSelect();

    private void btnBuscar_Click(object sender, RoutedEventArgs e) => callBuscar();

    private void txtBuscar_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter) && txtBuscar.IsFocused)
            callBuscar();
    }

    private void DataGridRow_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter) && dataGridEquipamentos.IsFocused)
            callSelect();
    }

    private void DataGridRow_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
            e.Handled = true;
    }
}
