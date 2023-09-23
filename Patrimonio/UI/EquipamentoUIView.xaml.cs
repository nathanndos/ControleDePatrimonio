using BLL;
using Patrimonio.Entity;
using Patrimonio.Util;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace Patrimonio.UI;

public partial class EquipamentoUIView : Window
{
    public EquipamentoUIView()
    {
        InitializeComponent();
        refreshDataDrid();

        txtBuscar.LostFocus += TxtBuscar_LostFocus;
        txtBuscar.GotFocus += TxtBuscar_GotFocus;
    }

    private void callNovo()
    {
        try
        {
            EquipamentoUICadastro equipamentoUI = new EquipamentoUICadastro();
            equipamentoUI.ShowDialog();

            refreshDataDrid();
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void callEditar()
    {
        try
        {
            EquipamentoUICadastro cadastro = new EquipamentoUICadastro(dataGridEquipamentos.getSelectItem<Equipamento>());
            cadastro.ShowDialog();

            refreshDataDrid();
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void callDelete()
    {
        try
        {
            EquipamentoBLL.delete(dataGridEquipamentos.getSelectItem<Equipamento>());
            refreshDataDrid();
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void refreshDataDrid()
    {
        dataGridEquipamentos.ItemsSource = EquipamentoBLL.getAll();
        txtBuscar.Focus();
    }

    private void callBuscar()
    {
        try
        {
            dataGridEquipamentos.ItemsSource = EquipamentoBLL.getBySearch(txtBuscar.getString());
            bStatus.resetContent();
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void btnNovo_Click(object sender, RoutedEventArgs e) => callNovo();

    private void btnEditar_Click(object sender, RoutedEventArgs e) => callEditar();

    private void btnExcluir_Click(object sender, RoutedEventArgs e) => callDelete();

    private void btnBuscar_Click(object sender, RoutedEventArgs e) => callBuscar();

    private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e) => callEditar();

    private void TxtBuscar_LostFocus(object sender, RoutedEventArgs e)
    {
        if (txtBuscar.getString().isEmpty())
        {
            txtBuscar.Text = "Buscar por id, serial ou nome";
            txtBuscar.Foreground = Brushes.Gray;
        }
    }

    private void TxtBuscar_GotFocus(object sender, RoutedEventArgs e)
    {
        txtBuscar.Text = string.Empty;
        txtBuscar.Foreground = Brushes.Black;
    }

    private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
            callBuscar();
    }
}
