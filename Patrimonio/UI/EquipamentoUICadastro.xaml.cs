using BLL;
using Entity;
using Patrimonio.ConstantManager;
using Patrimonio.Entity;
using Patrimonio.Util;
using System;
using System.Windows;
using System.Windows.Input;

namespace Patrimonio.UI
{
    public partial class EquipamentoUICadastro : Window
    {
        Equipamento equipamento;

        public EquipamentoUICadastro()
        {
            InitializeComponent();
            equipamento = new Equipamento();
        }

        public EquipamentoUICadastro(Equipamento obj)
        {
            InitializeComponent();
            equipamento = obj;
            fillForm(obj);
        }

        private void fillForm(Equipamento equipamento)
        {
            txtNomeEquipamento.Text = equipamento.Nome;
            txtSerial.Text = equipamento.Serial;
            txtId.Text = equipamento.Id.ToString();
            txtDataAquisicao.Text = equipamento.DataAquisicao.ToString();
        }

        private void save()
        {
            try
            {
                bStatus.resetContent();

                equipamento.Id = equipamento.Id;
                equipamento.Nome = txtNomeEquipamento.Text;
                equipamento.Serial = txtSerial.Text;
                equipamento.DataAquisicao = txtDataAquisicao.getDateTimeFormat();

                EquipamentoBLL.save(equipamento);
                bStatus.Content = CommonMessageConstant.SalvoComSucesso;
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
                txtNomeEquipamento.Text = string.Empty;
                txtSerial.Text = string.Empty;
                txtId.Text = string.Empty;
                txtDataAquisicao.Text = string.Empty;
                bStatus.resetContent();
            }
            catch (Exception ex)
            {
                bStatus.setExceptionMessage(ex);
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e) => save();

        private void btnNovo_Click(object sender, RoutedEventArgs e) => clearForm();

        private void txtDataAquisicao_KeyDown(object sender, KeyEventArgs e)
        {
            var teste = e.SystemKey.ToString();
        }
    }
}
