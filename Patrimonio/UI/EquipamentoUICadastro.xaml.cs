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
        public EquipamentoUICadastro()
        {
            InitializeComponent();
        }

        public EquipamentoUICadastro(Equipamento equipamento)
        {
            InitializeComponent();
            fillForm(equipamento);
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
                Equipamento equipamento = new Equipamento();

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

        private void callNew()
        {
            try
            {
                txtNomeEquipamento.Text = string.Empty;
                txtSerial.Text = string.Empty;
                txtId.Text = string.Empty;
                txtDataAquisicao.Text = string.Empty;
            }
            catch (Exception ex)
            {

                bStatus.setExceptionMessage(ex);
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e) => save();

        private void btnNovo_Click(object sender, RoutedEventArgs e) => callNew();
    }
}
