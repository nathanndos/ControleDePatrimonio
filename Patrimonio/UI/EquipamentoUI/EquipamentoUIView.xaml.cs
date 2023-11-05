using BLL;
using Entity;
using Patrimonio.ConstantManager;
using Patrimonio.UI;
using Patrimonio.Util;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace UI;

public partial class EquipamentoUIView : Window
{
    public EquipamentoUIView()
    {
        InitializeComponent();
        refreshDataGrid();

        txtBuscar.LostFocus += TxtBuscar_LostFocus;
        txtBuscar.GotFocus += TxtBuscar_GotFocus;
    }

    private void callNovo()
    {
        try
        {
            bStatus.resetContent();
            EquipamentoUICadastro equipamentoUI = new EquipamentoUICadastro();
            equipamentoUI.ShowDialog();

            refreshDataGrid();
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
            bStatus.resetContent();
            EquipamentoUICadastro cadastro = new EquipamentoUICadastro(dataGridEquipamentos.getSelectItem<Equipamento>());
            cadastro.ShowDialog();

            refreshDataGrid();
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
            bStatus.resetContent();
            EquipamentoBLL.delete(dataGridEquipamentos.getSelectItem<Equipamento>());
            refreshDataGrid();
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void refreshDataGrid()
    {
        string txtSearch = txtBuscar.getStringValue().Equals(CommonMessageConstant.EquipamentoViewPlaceHolder) ? string.Empty : txtBuscar.getStringValue();
        dataGridEquipamentos.ItemsSource = EquipamentoBLL.listBySearch(txtSearch);
        txtBuscar.Focus();
    }

    private void callBuscar()
    {
        try
        {
            bStatus.resetContent();
            refreshDataGrid();
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
        if (txtBuscar.getStringValue().isEmpty())
        {
            txtBuscar.Text = CommonMessageConstant.EquipamentoViewPlaceHolder;
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
