using Patrimonio.BLL;
using System.Windows;

namespace Patrimonio.UI
{
    public partial class EquipamentoUIView : Window
    {
        public EquipamentoUIView()
        {
            InitializeComponent();
            dataGridEquipamentos.ItemsSource = EquipamentoBLL.getAll();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            EquipamentoUICadastro equipamentoUI = new EquipamentoUICadastro();
            equipamentoUI.ShowDialog();
            dataGridEquipamentos.ItemsSource = EquipamentoBLL.getAll();
        }

        private void dataGridEquipamentos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
