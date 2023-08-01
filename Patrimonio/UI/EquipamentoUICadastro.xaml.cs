using Patrimonio.BLL;
using Patrimonio.ConstantManager;
using Patrimonio.Entity;
using Patrimonio.Util;
using System;
using System.Windows;

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
                equipamento.Id = equipamento.Id;
                equipamento.Nome = txtNomeEquipamento.Text;
                equipamento.Serial = txtSerial.Text;
                equipamento.DataAquisicao = DateTime.Now;

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
                bStatus.Content = string.Empty;
            }
            catch (Exception ex)
            {
                bStatus.setExceptionMessage(ex);
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e) => save();

        private void btnNovo_Click(object sender, RoutedEventArgs e) => clearForm();
    }
}
