using CRM.Conexao;
using CRM.Controls;
using CRM.Controls.Ajuda;
using System.Diagnostics;
using System.Windows;
using System.Windows.Shapes;

namespace CRM.Views
{
    public partial class Home : Window
    {
        public Home(string username)
        {
            InitializeComponent();
            NomeUserText.Text = string.IsNullOrWhiteSpace(username) ? "Usuário desconhecido" : username;
            DataText.Text = DateTime.Now.ToString("dd/MM/yyyy");
            MainContent.Content = new Inicio();
        }

        #region Views

        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Inicio();
        }

        private void BancoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new AtualizarBanco();
        }

        private void antiparasitario_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RelacaoAntiparasitario();
        }

        private void HelpAntiparasitario_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new HelpAntiparasitario();
        }

        private void suplemento_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RelacaoSuplemento();
        }

        private void HelpSuplemento_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new HelpSuplemento();
        }

        private void vermifugo_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RelacaoVermifugo();
        }

        private void racao_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RelacaoRacao();
        }

        private void welcome_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RelacaoWelcome();
        }

        private void vacina_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RelacaoVacina();
        }

        private void milteforan_Click(object sender, RoutedEventArgs e)
        {
            var relacaoWindow = new RelacaoMilteforan();
        }

        private void relatorio_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RelatorioRetorno();
        }

        private void Disparo_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Disparo();
        }

        private void clientesPorProduto_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new RelacaoCpP();
        }
        #endregion
    }

}
   
