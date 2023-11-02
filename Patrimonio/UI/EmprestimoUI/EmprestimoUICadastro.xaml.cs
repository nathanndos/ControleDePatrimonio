using BLL;
using Entity;
using Patrimonio.BLL;
using Patrimonio.ConstantManager;
using Patrimonio.UI.EquipamentoUI;
using Patrimonio.UI.PessoaUI;
using Patrimonio.Util;
using System;
using System.Windows;
namespace Patrimonio.UI;

public partial class EmprestimoUICadastro : Window
{
    Emprestimo emprestimo { get; set; }
    Pessoa pessoa = new Pessoa();
    Equipamento equipamento = new Equipamento();

    public EmprestimoUICadastro()
    {
        InitializeComponent();
        emprestimo = new Emprestimo();
    }

    public EmprestimoUICadastro(Emprestimo emprestimo)
    {
        InitializeComponent();
        this.emprestimo = emprestimo;
        fillForm();
    }

    private void save()
    {
        try
        {
            emprestimo.PessoaId = txtPessoaId.Text.toInt();
            emprestimo.EquipamentoId = txtEquipamentoId.Text.toInt();
            emprestimo.Observacao = txtEmprestimoObservacao.Text;
            emprestimo = EmprestimoBLL.save(emprestimo);
            fillForm();

            bStatus.setMessage(CommonMessageConstant.SalvoComSucesso);
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }

    private void clearForm()
    {
        try
        {
            bStatus.resetContent();

            emprestimo = new Emprestimo();
            pessoa = new Pessoa();
            equipamento = new Equipamento();
            fillForm();
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

    private void fillForm()
    {
        txtEmprestimoId.Text = emprestimo.Id.emptyIfZero();
        txtEmprestimoIde.Text = emprestimo.Ide.emptyIfGuidEmpty();
        txtEmprestimoDataAbertura.Text = emprestimo.DataAbertura.emptyIfDefaultDateTime();
        txtEmprestimoDataFechamento.Text = emprestimo.DataFechamento.emptyIfDefaultDateTime();
        txtPessoaId.Text = emprestimo.Pessoa.Id.emptyIfZero();
        txtPessoaNome.Text = emprestimo.Pessoa.Nome;
        txtEquipamentoNome.Text = emprestimo.Equipamento.Nome;
        txtEquipamentoId.Text = emprestimo.Equipamento.Id.emptyIfZero();
        txtEmprestimoObservacao.Text = emprestimo.Observacao;
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

    private void btnSalvar_Click(object sender, RoutedEventArgs e) => save();

    private void btnNovo_Click(object sender, RoutedEventArgs e) => clearForm();

    private void btnBuscarPessoa_Click(object sender, RoutedEventArgs e) => callBuscaPessoa();

    private void btnBuscarEquipamento_Click(object sender, RoutedEventArgs e) => callBuscaEquipamento();

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

    private void btnFinalizarEmprestimo_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            EmprestimoBLL.finalizar(emprestimo);
        }
        catch (Exception ex)
        {
            bStatus.setExceptionMessage(ex);
        }
    }
}