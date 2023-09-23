using Patrimonio.Entity;
using Patrimonio.UI;
using System;
using System.Windows;

namespace Patrimonio
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void btnEquipamentos_Click(object sender, RoutedEventArgs e)
        {
            EquipamentoUIView equipamentos = new EquipamentoUIView();
            equipamentos.Show();
        }

        private void DataGridRow_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
