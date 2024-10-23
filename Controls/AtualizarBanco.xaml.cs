using CRM.Conexao;
using OfficeOpenXml;
using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CRM.Controls
{
    public partial class AtualizarBanco : UserControl
    {
        private DataTable dataTable;
        private readonly conexaoMouraBanco dbHelper;

        public AtualizarBanco()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            dataTable = new DataTable();
            dbHelper = new conexaoMouraBanco();
            dataInicial.SelectedDate = DateTime.Now.AddMonths(-6).AddDays(-1);
            dateFinal.SelectedDate = DateTime.Now.AddDays(-1);
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (dataInicial.SelectedDate.HasValue && dateFinal.SelectedDate.HasValue)
            {
                DateTime startDate = dataInicial.SelectedDate.Value;
                DateTime endDate = dateFinal.SelectedDate.Value;

                progressBar.IsIndeterminate = true;

                try
                {
                    await Task.Run(() =>
                    {
                        dataTable = dbHelper.FetchData(startDate, endDate);
                    });

                    MessageBox.Show($"Total de registros: {dataTable.Rows.Count}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar dados: {ex.Message}");
                }
                finally
                {
                    progressBar.IsIndeterminate = false;
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione as datas.");
            }
        }

        private void btnExportarExcel_Click(object sender, RoutedEventArgs e)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "Banco.xlsx");

                // Verifica se o arquivo já existe
                if (File.Exists(filePath))
                {
                    MessageBoxResult overwriteResult = MessageBox.Show("O arquivo já existe. Deseja sobrescrever?", "Arquivo Existente", MessageBoxButton.YesNo);
                    if (overwriteResult == MessageBoxResult.No)
                    {
                        // Se o usuário não deseja sobrescrever, pode gerar um novo nome
                        string newFileName = Path.GetFileNameWithoutExtension(filePath) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                        filePath = Path.Combine(desktopPath, newFileName);
                    }
                }

                try
                {
                    using (ExcelPackage package = new())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Dados");

                        // Adiciona os nomes das colunas
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                        }

                        // Adiciona os dados
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataTable.Columns.Count; j++)
                            {
                                worksheet.Cells[i + 2, j + 1].Value = dataTable.Rows[i][j];
                            }
                        }

                        FileInfo fileInfo = new(filePath);
                        package.SaveAs(fileInfo);
                    }

                    MessageBox.Show("Exportação concluída! Arquivo salvo na área de trabalho.", "Exportação Completa", MessageBoxButton.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao exportar para Excel: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Nenhum dado para exportar. Execute a pesquisa primeiro.");
            }
        }
    }
}
