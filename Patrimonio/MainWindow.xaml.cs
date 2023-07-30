using Patrimonio.Entity;
using System;
using System.Windows;

namespace Patrimonio
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var equipamento = new Equipamento() 
            { 
                Nome = "Computador",
                DataAquisicao = DateTime.Now,
            };

            dbContext.insert(equipamento);
        }
    }
}
