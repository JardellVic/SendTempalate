   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CRM.Controls.AjudaCRM.Controls.Ajuda  5      '    !CRM.Controls.Ajuda.HelpSuplemento   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CRM.Controls.Ajuda     5      .��5	      � .+�5
   
   �� $
��Wrap=�6   $��10,10,10,10q�6(   
�������$��14(�6P   �� 5   
   $5�/             ### Documentação da Função ###��6   �� 5   
   �� 5   
   �� 5   
   $���Este código é uma aplicação WPF que processa dados de um arquivo Excel chamado Banco.xlsx, filtra informações de vendas de produtos e salva os resultados em um novo arquivo chamado Suplemento.xlsx, na pasta Relações no desktop do usuário.��6   �� 5   
   �� 5   
   �� 5   
   $S�M1.Classe relacaoSuplemento: Controla a interface e o processamento dos dados.��6   �� 5   
   �� 5   
   �� 5   
   $3�-                ### Métodos Importantes: ###��6   �� 5   
   �� 5   
   �� 5   
   $P�J1. StartProcessing: Inicia o processamento e exibe uma barra de progresso.��6   �� 5   
   �� 5   
   �� 5   
   $���2. ProcessarDados: Lê e filtra dados do Banco.xlsx. Agrupa produtos por código e data de venda. Salva os dados filtrados em Suplemento.xlsx.��6   5      5      5       