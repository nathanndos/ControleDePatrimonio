using Patrimonio.BLL;
using Patrimonio.Entity;
using Patrimonio.Util;
using System;
using System.Windows;

namespace Patrimonio.UI
{
    public partial class EquipamentoUIView : Window
    {
        public EquipamentoUIView()
        {
            InitializeComponent();
            refreshDataDrid();
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

        private void dataGridEquipamentos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void refreshDataDrid() => dataGridEquipamentos.ItemsSource = EquipamentoBLL.getAll();

        private void btnNovo_Click(object sender, RoutedEventArgs e) => callNovo();

        private void btnEditar_Click(object sender, RoutedEventArgs e) => callEditar();

        private void btnExcluir_Click(object sender, RoutedEventArgs e) => callDelete();
    }
}
