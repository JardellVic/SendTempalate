   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CRM.Controls.AjudaCRM.Controls.Ajuda  5      ,    &CRM.Controls.Ajuda.HelpAntiparasitario   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CRM.Controls.Ajuda     5      .��5	      � .+�5
   
   �� $
��Wrap=�6   $��10,10,10,10q�6(   
�������$��14(�6P   �� 5   
   $5�/             ### Documentação da Função ###��6   �� 5   
   �� 5   
   �� 5   
   $���Este código é uma aplicação WPF em C# que processa dados de vendas de antiparasitários, utilizando a biblioteca ClosedXML para manipulação de arquivos Excel.��6   �� 5   
   �� 5   
   �� 5   
   $���1. Classe `relacaoAntiparasitario`: Inicia o processamento dos dados ao carregar a janela e exibe uma barra de progresso durante a execução.��6   �� 5   
   �� 5   
   �� 5   
   $���2. Método `ProcessarDados`: Lê o arquivo Excel `Banco.xlsx`, filtra dados indesejados, organiza produtos em grupos e exporta os resultados para `Antiparasitario.xlsx`.��6   �� 5   
   �� 5   
   �� 5   
   $R�L3. Formato de Telefones: Telefones são ajustados para o padrão brasileiro.��6   �� 5   
   �� 5   
   �� 5   
   $c�]4. Resultado: O arquivo Excel filtrado é salvo e uma mensagem de sucesso ou erro é exibida.��6   5      5      5      