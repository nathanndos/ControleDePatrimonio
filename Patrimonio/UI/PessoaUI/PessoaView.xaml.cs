using BLL;
using Entity;
using Patrimonio.Util;
using System;
using System.Windows;
using System.Windows.Input;

namespace UI.PessoaUI;

public partial class PessoaView : Window
{
    Pessoa pessoaObj = new Pessoa();

    public PessoaView()
    {
        InitializeComponent();
        dataGridPessoas.ItemsSource = PessoaBLL.listBySearch(string.Empty);
    }

    private void save()
    {
        try
        {
            bStatus.resetContent();

            Pessoa pessoa = pessoaObj.Id.isZero() ? new Pessoa() : pessoaObj;
            pessoa.Nome = txtNome.getString();
            PessoaBLL.save(pessoa);

            dataGridPessoas.ItemsSource = PessoaBLL.listBySearch(string.Empty);
            txtNome.Focus();
            txtNome.Text = string.Empty;
            pessoaObj = new Pessoa();
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void callSearch()
    {
        try
        {
            bStatus.resetContent();

            dataGridPessoas.ItemsSource = PessoaBLL.listBySearch(txtBuscar.getString());
            txtBuscar.Focus();
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

            PessoaBLL.delete(dataGridPessoas.getSelectItem<Pessoa>());
            dataGridPessoas.ItemsSource = PessoaBLL.listBySearch(txtBuscar.getString());
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void callEdit()
    {
        try
        {
            bStatus.resetContent();

            pessoaObj = dataGridPessoas.getSelectItem<Pessoa>();
            txtNome.Text = pessoaObj.Nome;
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void btnSalvar_Click(object sender, RoutedEventArgs e) => save();

    private void btnBuscar_Click(object sender, RoutedEventArgs e) => callSearch();

    private void btnExcluir_Click(object sender, RoutedEventArgs e) => callDelete();

    private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e) => callEdit();

    private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key.Equals(Key.Enter))
            callSearch();
    }
}
