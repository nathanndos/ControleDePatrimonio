using Patrimonio.UI;
using System.Windows;
using UI.PessoaUI;

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

        private void btnPessoas_Click(object sender, RoutedEventArgs e)
        {
            PessoaView pessoaView = new PessoaView();
            pessoaView.Show();
        }
    }
}
