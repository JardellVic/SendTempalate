   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CRM.ControlsCRM.Controls  5          CRM.Controls.RelacaoCpP   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:CRM.Controls     5      ���	#FF1A1A1A.��5	      � .+�5
   
   � $��	10,0,10,0q�6   $��65��6"   $	��Top=�6.     � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $	��150 �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ lblDataInicial��5      $��0��6,   $��0��69   $ ��Data Inicial (dd/mm/aaaa):��6I   
�������$��Center=�6�   $	��150��6�   $��Center=�6�   �� 5      -   5        $ lblDataFinal��5      $��0��6*   $��2��67   $��Data Final (dd/mm/aaaa):��6G   
�������$��Center=�6}   $	��150��6�   $��Center=�6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dataInicial��5      $��1��6.   $��0��6;   $	��200��6K   
�������6W     5       -   5        $ 	dataFinal��5       $��1��6,   $��2��69   $	��200��6I   
�������6U   5!      �� 5$   
   -   5         ��Name$ 	btnSearch��5$      $��	Pesquisar��6$   $��Center=�68   $	��Top=�6U   $��
689,66,0,0q�6m   $	��100��6�   ���	#FF414141
�������6�   �� 5%   
   -   5        $ btnExportarExcel��5%      $��51,531,690,10q�6+   $��59��6B   
�������$��54��6a   $��Bottom=�6�   ��6m   Z� ��5&      �� 5'       j� Stretch$ Uniform=�6    �� ImageSource$ /Controls/excel.png��6/   5)      � 5*   
   -   5         �Name$ progressBar��5*      $��Center=�6+   $��Bottom=�6H   $��111,516,0,10q�6c   $��38��6y   
�������
���  ��$	��679��6�   �� 5+   
   -   5         ��Name$ 
txtProduto��5+      $��23,70,128,0q�6&   	 �� TextWrapping$
	 Wrap=�6;   $	��Top=�6O   $	��649��6g   ���	#FF2E2E2E
�������6�   �� 5,   
   -	   5        
 ��Name$
 	listaProd��5,      $��10,103,10,115q�6&    �� View 5-      �� 5.      .P�5/      �� $
��Nome��6%    �� Width$	 150��6^    �� DisplayMemberBinding 63   ��  �� Path$
 nome�6^   �� 50      $��Telefone��6%   $ 80��6b    67   �� $
 fone�6b   �� 51      $��
Telefone 2��6%   $ 80��6e    69   �� $ fone2�6e   �� 52      $��Produto��6%   $	 120��6d    66   �� $ Produto�6d   �� 53      $��Nome do Produto��6%   $	 200��6q    6>   �� $ Nome_Produto�6q   54      56      58      59      