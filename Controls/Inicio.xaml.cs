using CRM.Conexao;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Path = System.IO.Path;


namespace CRM.Controls
{
    public partial class Inicio : UserControl
    {
        private conexaoCRM _conexaoCRM;
        string desktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Relações");

        public Inicio()
        {
            InitializeComponent();
            _conexaoCRM = new conexaoCRM();
            AtualizarLabelsGerar();
            AtualizarLabelsVerificar();
        }

        private void vrfcAntiparasitario_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(desktopPath, "Antiparasitario.xlsx");

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                _conexaoCRM.AtualizarExecucaoVerificar("antiparasitario");
                txtVeriAntiparasitario.Text = "Verificar Anti-Parasitário:✅";
            }
            else
            {
                MessageBox.Show("O arquivo Antiparasitario.xlsx não foi encontrado.", "Arquivo não encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void vrfcSuplemento_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(desktopPath, "Suplemento.xlsx");

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                _conexaoCRM.AtualizarExecucaoVerificar("suplemento");
                txtVeriSuplemento.Text = "Verificar Suplemento:✅";
            }
            else
            {
                MessageBox.Show("O arquivo Suplemento.xlsx não foi encontrado.", "Arquivo não encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void vrfcVermifugo_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(desktopPath, "Vermifugo.xlsx");

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                _conexaoCRM.AtualizarExecucaoVerificar("vermifugo");
                txtVeriVermifugo.Text = "Verificar Vermifugo:✅";
            }
            else
            {
                MessageBox.Show("O arquivo Vermifugo.xlsx não foi encontrado.", "Arquivo não encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void vrfcRacao_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(desktopPath, "Racao.xlsx");

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                _conexaoCRM.AtualizarExecucaoVerificar("racao");
                txtVeriRacao.Text = "Verificar Ração:✅";
            }
            else
            {
                MessageBox.Show("O arquivo Racao.xlsx não foi encontrado.", "Arquivo não encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void vrfcWelcome_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(desktopPath, "Welcome.xlsx");

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                _conexaoCRM.AtualizarExecucaoVerificar("welcome");
                txtVeriWelcome.Text = "Verificar Welcome:✅";
            }
            else
            {
                MessageBox.Show("O arquivo Welcome.xlsx não foi encontrado.", "Arquivo não encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void vrfcVacina_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(desktopPath, "Vacina.xlsx");

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                _conexaoCRM.AtualizarExecucaoVerificar("vacina");
                txtVeriVacina.Text = "Verificar Vacina:✅";
            }
            else
            {
                MessageBox.Show("O arquivo Vacina.xlsx não foi encontrado.", "Arquivo não encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void vrfcMilteforan_Click(object sender, RoutedEventArgs e)
        {
            string filePath = Path.Combine(desktopPath, "Milteforan.xlsx");

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                _conexaoCRM.AtualizarExecucaoVerificar("milteforan");
                txtVeriMilteforan.Text = "Verificar Milteforan:✅";
            }
            else
            {
                MessageBox.Show("O arquivo Milteforan.xlsx não foi encontrado.", "Arquivo não encontrado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AtualizarLabelsGerar()
        {
            try
            {
                var controle = _conexaoCRM.ObterControleExecucaoGerar();

                if (controle != null)
                {
                    lblGerarAntiparasitario.Text = controle.Antiparasitario ? "Gerar Anti-Parasitário:✅" : "Gerar Anti-Parasitário:";
                    lblGerarSuplmento.Text = controle.Suplemento ? "Gerar Suplemento:✅" : "Gerar Suplemento:";
                    lblGerarVermifugo.Text = controle.Vermifugo ? "Gerar Vermífugo:✅" : "Gerar Vermífugo:";
                    lblGerarRacao.Text = controle.Racao ? "Gerar Ração:✅" : "Gerar Ração:";
                    lblGerarWelcome.Text = controle.Welcome ? "Gerar Welcome:✅" : "Gerar Welcome:";
                    lblGerarVacina.Text = controle.Vacina ? "Gerar Vacina:✅" : "Gerar Vacina:";
                    lblGerarMilteforan.Text = controle.Milteforan ? "Gerar Milteforan:✅" : "Gerar Milteforan:";
                }
                else
                {
                    MessageBox.Show("REGISTRO DE EXECUÇÃO NÃO CRIADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar labels: {ex.Message}");
            }
        }

        private void AtualizarLabelsVerificar()
        {
            try
            {
                var controle = _conexaoCRM.ObterControleExecucaoVerificar();

                if (controle != null)
                {
                    txtVeriAntiparasitario.Text = controle.Antiparasitario ? "Verificar Anti-Parasitário:✅" : "Verificar Anti-Parasitário:";
                    txtVeriSuplemento.Text = controle.Suplemento ? "Verificar Suplemento:✅" : "Verificar Suplemento:";
                    txtVeriVermifugo.Text = controle.Vermifugo ? "Verificar Vermífugo:✅" : "Verificar Vermífugo:";
                    txtVeriRacao.Text = controle.Racao ? "Verificar Ração:✅" : "Verificar Ração:";
                    txtVeriWelcome.Text = controle.Welcome ? "Verificar Welcome:✅" : "Verificar Welcome:";
                    txtVeriVacina.Text = controle.Vacina ? "Verificar Vacina:✅" : "Verificar Vacina:";
                    txtVeriMilteforan.Text = controle.Milteforan ? "Verificar Milteforan:✅" : "Verificar Milteforan:";
                }
                else
                {
                    MessageBox.Show("REGISTRO DE EXECUÇÃO NÃO CRIADO");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar labels: {ex.Message}");
            }
        }

    }
}
