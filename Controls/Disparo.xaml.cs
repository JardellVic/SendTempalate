#region Diretivas
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Microsoft.Win32;
using OfficeOpenXml;
using CRM.conexao.API;
using System.Windows.Threading;
using System.Text.Json;
using CRM.Conexao;
#endregion

namespace CRM.Controls
{
    public class LineData
    {
        public string Numero { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public List<string> Variaveis { get; set; } = [];
    }

    public partial class Disparo : UserControl
    {
        #region Properties
       //----------------------------Public------------------------------//
        public static Disparo Instance { get; private set; }
        public string TemplateIdSelecionado { get; set; } = string.Empty;
        public List<LineData> LinhasParaEnviar { get; private set; } = [];
      //-----------------------------Private-----------------------------//
        private readonly APIManager apiManager;
        private readonly HttpClient client;
        private readonly Dictionary<string, string> templateTextMap;
        private readonly Dictionary<string, int> templateParamsMap;
        private readonly Dictionary<string, string> templateIdMap;
        private DispatcherTimer timer = new();
        private TimeSpan tempoRestante;
        private bool isDisparoPaused = false;
        private bool isDisparoRunning = false;
        private int currentIndex = 0;
        private conexaoCRM _conexaoCRM;
        private string _username;
        #endregion

        public Disparo()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            apiManager = new APIManager();
            client = new HttpClient();
            templateTextMap = [];
            templateParamsMap = [];
            templateIdMap = [];
            LoadTemplatesAsync();
            cmbTemplates.SelectionChanged += CmbTemplates_SelectionChanged;
            Instance = this;
            SelectFileButton.IsEnabled = false;
            _conexaoCRM = new conexaoCRM();
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #region API PlanetFone

        private async void LoadTemplatesAsync()
        {
            try
            {
                var templates = await apiManager.GetTemplatesAsync();
                templateTextMap.Clear();
                templateParamsMap.Clear();
                templateIdMap.Clear();
                cmbTemplates.Items.Clear();

                foreach (var template in templates)
                {
                    string nome = template.Key;
                    var (texto, paramsCount, id) = template.Value;
                    templateTextMap[nome] = texto;
                    templateParamsMap[nome] = paramsCount;
                    templateIdMap[nome] = id;
                    cmbTemplates.Items.Add(nome);
                }
            }
            catch (HttpRequestException e)
            {
                ShowError(e.Message);
            }
        }

        private void CmbTemplates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbTemplates.SelectedItem != null)
                {
                    string selectedTemplate = cmbTemplates.SelectedItem?.ToString() ?? string.Empty;
                    if (templateTextMap.ContainsKey(selectedTemplate))
                    {
                        txtTemplate.Text = templateTextMap[selectedTemplate];
                        if (templateIdMap.ContainsKey(selectedTemplate))
                        {
                            TemplateIdSelecionado = templateIdMap[selectedTemplate];
                        }
                        SelectFileButton.IsEnabled = true;
                    }

                }
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new()
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    FilePathTextBox.Text = openFileDialog.FileName;

                    if (cmbTemplates.SelectedItem != null)
                    {
                        string selectedTemplate = cmbTemplates.SelectedItem?.ToString() ?? string.Empty;
                        int paramsCount = GetParamsCountForTemplate(selectedTemplate);

                        if (GetColumnCountFromExcel(openFileDialog.FileName) < paramsCount + 1)
                        {
                            ShowError($"O arquivo Excel deve ter pelo menos {paramsCount + 1} colunas.");
                            return;
                        }

                        OpenMappingWindow(paramsCount);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void OpenMappingWindow(int paramsCount)
        {
            try
            {
                var columnNames = GetColumnNamesFromExcel(FilePathTextBox.Text);
                var rowData = GetRowDataFromExcel(FilePathTextBox.Text);

                int quantidadeContatos = rowData.Count;
                AtualizarStatusBar(quantidadeContatos);

                MappingWindow mappingWindow = new(paramsCount, columnNames, rowData);
                mappingWindow.ShowDialog();

                if (!string.IsNullOrEmpty(mappingWindow.ColunaNumeroSelecionada) &&
                    !string.IsNullOrEmpty(mappingWindow.ColunaNomeSelecionada))
                {
                    ProcessRowData(mappingWindow.ColunaNumeroSelecionada, mappingWindow.ColunaNomeSelecionada, mappingWindow.ColunaVariaveisSelecionada, rowData);
                }
            }
            catch (Exception e) { ShowError(e.Message); };
        }

        private static List<string> GetColumnNamesFromExcel(string filePath)
        {
            try
            {
                var columnNames = new List<string>();
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        columnNames.Add(worksheet.Cells[1, col].Text);
                    }
                }
                return columnNames;
            }
            catch (Exception e)
            {
                ShowError(e.Message);
                return new List<string>();
            }

        }

        private void ProcessRowData(string colunaNumero, string colunaNome, string variaveisColuna, List<List<string>> rowData)
        {
            try
            {
                var linhas = new List<LineData>();
                var columnNames = GetColumnNamesFromExcel(FilePathTextBox.Text);

                if (columnNames == null)
                {
                    ShowError("Não foi possível obter os nomes das colunas do Excel.");
                    return;
                }

                int numeroIndex = columnNames.IndexOf(colunaNumero);
                int nomeIndex = columnNames.IndexOf(colunaNome);

                if (numeroIndex == -1 || nomeIndex == -1)
                {
                    ShowError("As colunas especificadas não foram encontradas no Excel.");
                    return;
                }

                if (string.IsNullOrEmpty(variaveisColuna))
                {
                    MessageBox.Show("A coluna de variáveis está vazia.");
                    return;
                }

                List<int> variaveisIndices = variaveisColuna.Trim('[', ']').Split(',')
                    .Select(v => columnNames.IndexOf(v.Trim('"')))
                    .ToList();

                if (variaveisIndices.Any(i => i < 0 || i >= columnNames.Count))
                {
                    ShowError("Alguns índices de variáveis não correspondem às colunas do Excel.");
                    return;
                }

                foreach (var row in rowData)
                {
                    if (row.Count > numeroIndex && row.Count > nomeIndex && variaveisIndices.All(i => i < row.Count))
                    {
                        var lineData = new LineData
                        {
                            Numero = row[numeroIndex],
                            Nome = row[nomeIndex],
                            Variaveis = variaveisIndices.Select(i => row[i]).ToList()
                        };
                        linhas.Add(lineData);
                    }
                }

                Disparo.Instance.LinhasParaEnviar = linhas;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AtualizarStatusBar(int quantidadeContatos)
        {
            try
            {
                statusContatos.Content = $"Quantidade de contatos: {quantidadeContatos}";

                double valorUtility = 0.008 * quantidadeContatos;
                statusUtility.Content = $"Valor Utility: ${valorUtility:F2}";

                double valorMarketing = 0.0625 * quantidadeContatos;
                statusMarketing.Content = $"Valor Marketing: ${valorMarketing:F2}";
            }
            catch (Exception e)
            {
                ShowError(e.Message);
            }
        }

        private async void btnEnviarDisparo_Click(object sender, RoutedEventArgs e)
        {
            if (isDisparoPaused)
            {
                isDisparoPaused = false;
                isDisparoRunning = true;

                InicializarContagemRegressiva(Disparo.Instance.LinhasParaEnviar.Count - currentIndex);

                await ContinuarEnvioAsync();
            }
            else
            {
                if (!isDisparoRunning)
                {
                    isDisparoRunning = true;
                    InicializarContagemRegressiva(Disparo.Instance.LinhasParaEnviar.Count);
                    await ContinuarEnvioAsync();
                }
            }
        }

        private async Task<bool> OptinNumeroAsync(string numero)
        {
            try
            {
                var (result, responseBody) = await apiManager.OptinNumeroAsync(numero);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnPareDisparo_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Deseja finalizar o disparo?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                isDisparoRunning = false;
                isDisparoPaused = false;

                timer?.Stop();

                txtBlockConsole.Inlines.Add(new Run("\nDisparo finalizado.") { Foreground = Brushes.Red });
            }
        }                  

        private static List<List<string>> GetRowDataFromExcel(string filePath)
        {
            var rowData = new List<List<string>>();

            try
            {
                using var package = new ExcelPackage(new FileInfo(filePath));
                var worksheet = package.Workbook.Worksheets[0];

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var rowValues = new List<string>();

                    for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                    {
                        rowValues.Add(worksheet.Cells[row, col].Text);
                    }

                    rowData.Add(rowValues);
                }
            }
            catch (IOException ioEx)
            {
                ShowError(ioEx.Message); ;
            }
            catch (Exception e)
            {
                ShowError(e.Message); ;
            }

            return rowData;
        }
        
        private int GetParamsCountForTemplate(string templateName)
        {
            return templateParamsMap.ContainsKey(templateName) ? templateParamsMap[templateName] : 0;
        }

        private static int GetColumnCountFromExcel(string filePath)
        {
            try
            {
                using var package = new ExcelPackage(new FileInfo(filePath));
                var worksheet = package.Workbook.Worksheets[0];
                return worksheet.Dimension.End.Column;
            }
            catch (Exception e) { ShowError(e.Message); return 0; }
        }

        private void InicializarContagemRegressiva(int quantidadeContatos)
        {
            try
            {
                double totalSegundos = 6 * quantidadeContatos;
                tempoRestante = TimeSpan.FromSeconds(totalSegundos);

                timer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };
#pragma warning disable CS8622
                timer.Tick += Timer_Tick;
#pragma warning restore CS8622
                timer.Start();
            }
            catch (Exception e) { ShowError(e.Message); return; }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (sender == null)
                {

                    return;
                }
                if (tempoRestante.TotalSeconds > 0)
                {
                    tempoRestante = tempoRestante.Subtract(TimeSpan.FromSeconds(1));
                    statusTempo.Content = $"Tempo Restante: {tempoRestante:hh\\:mm\\:ss}";
                }
                else
                {
                    timer.Stop();
                    statusTempo.Content = "Tempo Esgotado";
                }
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private async Task ContinuarEnvioAsync()
        {
            int sucessoCount = 0;
            int erroCount = 0;
            int totalLinhas = Disparo.Instance.LinhasParaEnviar.Count;

            progressDisparo.IsIndeterminate = false;
            progressDisparo.Maximum = totalLinhas;
            progressDisparo.Value = currentIndex;

            txtBlockConsole.Inlines.Clear();
            txtBlockConsoleResponse.Inlines.Clear();
            txtBlockConsole.Inlines.Add(new Run($"Iniciando envio... ({currentIndex}/{totalLinhas})") { Foreground = Brushes.Yellow });

            scrollViewerConsole.ScrollToEnd();

            try
            {
                var linhasParaEnviar = Disparo.Instance.LinhasParaEnviar;

                for (int i = currentIndex; i < linhasParaEnviar.Count; i++)
                {
                    if (!isDisparoRunning)
                        break;

                    while (isDisparoPaused)
                    {
                        await Task.Delay(500);
                    }

                    bool resultado = await EnviarLinhaAsync(linhasParaEnviar[i]);
                    if (resultado)
                    {
                        sucessoCount++;
                    }
                    else
                    {
                        erroCount++;
                        txtBlockConsole.Inlines.Add(new Run($"\nErro: {linhasParaEnviar[i].Numero}") { Foreground = Brushes.Red });
                    }

                    currentIndex = i + 1;
                    progressDisparo.Value = currentIndex;
                    txtBlockConsole.Inlines.Add(new Run($"\nProgresso: {currentIndex}/{totalLinhas}") { Foreground = Brushes.Blue });

                    scrollViewerConsole.ScrollToEnd();
                    scrollViewerConsoleT.ScrollToEnd();

                    await Task.Delay(500);
                }
            }
            catch (Exception e)
            {
                ShowError(e.Message); ;
            }
            finally
            {
                progressDisparo.IsIndeterminate = false;
                if (isDisparoRunning)
                {
                    MessageBoxResult result = MessageBox.Show(
                        $"Envios concluídos!\n\nSucessos: {sucessoCount}\nErros: {erroCount}",
                        "Resultado do Envio", MessageBoxButton.OK, MessageBoxImage.Information
                    );

                    if (result == MessageBoxResult.OK)
                    {

                        txtBlockConsole.Inlines.Clear();
                        txtBlockConsoleResponse.Inlines.Clear();
                        isDisparoRunning = false;
                        isDisparoPaused = false;
                    }
                }
                currentIndex = 0;
            }

        }

        private async Task<bool> EnviarLinhaAsync(LineData linha)
        {
            try
            {
                var (optinResult, responseBody) = await apiManager.OptinNumeroAsync(linha.Numero);
                (var sendResult, string responseBodyT) = await apiManager.EnviarLinhaAsync(TemplateIdSelecionado, linha.Numero, linha.Nome, linha.Variaveis);

                string formattedResponseBody = FormatJson(responseBody);
                string formattedResponseBodyT = FormatJson(responseBodyT);

                if (optinResult)
                {
                    txtBlockConsoleResponse.Inlines.Add(new Run($"\nOptIn feito com sucesso:") { Foreground = Brushes.Yellow });
                    txtBlockConsoleResponse.Inlines.Add(new Run($"\n{formattedResponseBody}") { Foreground = Brushes.Green });
                    txtBlockConsoleResponse.Inlines.Add(new Run($"\nMensagem enviada com sucesso") { Foreground = Brushes.Yellow });
                    txtBlockConsoleResponse.Inlines.Add(new Run($"\n{formattedResponseBodyT}") { Foreground = Brushes.Green });
                }
                else
                {
                    txtBlockConsoleResponse.Inlines.Add(new Run($"\nErro no OptIn:") { Foreground = Brushes.Red });
                    txtBlockConsoleResponse.Inlines.Add(new Run($"\n{formattedResponseBody}") { Foreground = Brushes.Red });
                    txtBlockConsoleResponse.Inlines.Add(new Run($"\n{formattedResponseBodyT}") { Foreground = Brushes.Red });
                    txtBlockConsole.Inlines.Add(new Run("Erro ao fazer optin") { Foreground = Brushes.Red });
                    return false;
                }

                if (sendResult)
                {
                    txtBlockConsole.Inlines.Add(new Run($"\nSucesso: {linha.Numero}") { Foreground = Brushes.Green });
                    return true;
                }
                else
                {
                    txtBlockConsole.Inlines.Add(new Run($"\nErro: {linha.Numero}") { Foreground = Brushes.Red });
                    return false;
                }
            }
            catch (Exception ex)
            {
                txtBlockConsole.Inlines.Add(new Run($"\nErro: {ex.Message}") { Foreground = Brushes.Red });
                return false;
            }
        }

        private string FormatJson(string json)
        {
            try
            {
                var jsonObject = JsonSerializer.Deserialize<JsonElement>(json);

                if (jsonObject.TryGetProperty("data", out var dataProperty))
                {
                    if (dataProperty.TryGetProperty("msg", out var msgProperty))
                    {
                        var status = jsonObject.GetProperty("status").GetString();
                        var message = msgProperty.GetString();
                        return $"Status: {status}\nMensagem: {message}";
                    }
                    else if (dataProperty.TryGetProperty("messageId", out var messageIdProperty) &&
                             dataProperty.TryGetProperty("status", out var statusProperty))
                    {
                        var status = jsonObject.GetProperty("status").GetString();
                        var messageId = messageIdProperty.GetString();
                        var submittedStatus = statusProperty.GetString();
                        return $"Status: {status}\nMessageId: {messageId}\nStatus: {submittedStatus}";
                    }
                }

                return json;
            }
            catch
            {
                return json;
            }
        }
        #endregion    


    }
}