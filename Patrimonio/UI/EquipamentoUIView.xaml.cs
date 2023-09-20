﻿using BLL;
using Patrimonio.Entity;
using Patrimonio.Util;
using System;
using System.Windows;
using System.Windows.Media;

namespace Patrimonio.UI
{
    public partial class EquipamentoUIView : Window
    {
        public EquipamentoUIView()
        {
            InitializeComponent();
            refreshDataDrid();

            txtBuscar.LostFocus += delegate(object sender, RoutedEventArgs e)
            {
                txtBuscar.Text = "Buscar por id, serial ou nome";
                txtBuscar.Foreground = Brushes.Gray;
            };

            txtBuscar.GotFocus += delegate (object sender, RoutedEventArgs e)
            {
                txtBuscar.Text = string.Empty;
            };
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

        private void btnNovo_Click(object sender, RoutedEventArgs e) => callNovo();

        private void btnEditar_Click(object sender, RoutedEventArgs e) => callEditar();

        private void btnExcluir_Click(object sender, RoutedEventArgs e) => callDelete();

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e) => callEditar();
    }
}
