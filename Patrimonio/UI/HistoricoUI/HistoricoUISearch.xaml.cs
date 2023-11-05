using BLL;
using Entity;
using Patrimonio.BLL;
using Patrimonio.UI.EquipamentoUI;
using Patrimonio.UI.PessoaUI;
using Patrimonio.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Patrimonio.UI.HistoricoUI;

public partial class HistoricoUISearch : Window
{
    Pessoa pessoa = new Pessoa();
    Equipamento equipamento = new Equipamento();
    public HistoricoUISearch()
    {
        InitializeComponent();
    }

    private void callBuscarHistorico()
    {
        try
        {
            List<Emprestimo> emprestimos = EmprestimoBLL.listHistorico(equipamento, pessoa);
            dataGridEmprestimoAtual.ItemsSource = emprestimos.Where(i => i.isNotFinalizado);
            dataGridHistorico.ItemsSource = emprestimos.Where(i => i.isFinalizado);
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void callBuscaPessoa()
    {
        try
        {
            PessoaUISearch ui = new PessoaUISearch();
            bool? value = ui.ShowDialog();

            if (value.HasValue && value.Value)
                pessoa = ui.pessoaSelected;

            fillPessoa();
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void callBuscaEquipamento()
    {
        try
        {
            EquipamentoUISearch ui = new EquipamentoUISearch();
            bool? value = ui.ShowDialog();

            if (value.HasValue && value.Value)
                equipamento = ui.equipamentoSelected;

            fillEquipamento();

        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void callEmprestimo(Emprestimo emprestimo)
    {
        try
        {
            EmprestimoUICadastro emprestimoUI = new EmprestimoUICadastro(emprestimo);
            emprestimoUI.ShowDialog();
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void fillPessoa()
    {
        txtPessoaId.Text = pessoa.Id.emptyIfZero();
        txtPessoaNome.Text = pessoa.Nome;
    }

    private void fillEquipamento()
    {
        txtEquipamentoNome.Text = equipamento.Nome;
        txtEquipamentoId.Text = equipamento.Id.emptyIfZero();
    }

    private void btnBuscarPessoa_LostFocus(object sender, RoutedEventArgs e)
    {
        pessoa = PessoaBLL.get(txtPessoaId.Text.toInt());
        fillPessoa();
    }

    private void btnBuscarEquipamento_LostFocus(object sender, RoutedEventArgs e)
    {
        equipamento = EquipamentoBLL.get(txtEquipamentoId.Text.toInt());
        fillEquipamento();
    }

    private void btnBusca_Click(object sender, RoutedEventArgs e) => callBuscarHistorico();

    private void btnBuscarPessoa_Click(object sender, RoutedEventArgs e) => callBuscaPessoa();

    private void btnBuscarEquipamento_Click(object sender, RoutedEventArgs e) => callBuscaEquipamento();

    private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => callEmprestimo(dataGridHistorico.getSelectItem<Emprestimo>());

    private void DataGridEmprestimoAtual_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => callEmprestimo(dataGridEmprestimoAtual.getSelectItem<Emprestimo>());
}