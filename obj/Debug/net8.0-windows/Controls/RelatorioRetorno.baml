   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CRM.ControlsCRM.Controls  5      #    CRM.Controls.RelatorioRetorno   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:CRM.Controls     5      ���	#FF1A1A1A.��5	      � .+�5
   
   �� .+�5      �� $	��100��6   .+�5      � $	��100��6     � ColumnDefinitions  5      �� 5      �� 5      �� 5      $	��210 �6+   .+�5      �� -   5         ��Name$ lblDataInicial��5   ,   $��0��6   $ ��Data Inicial (dd/mm/aaaa):��6D   
�������$��Center=�6|   $	��Top=�6�   $��0,10,0,0q�6�   $��24��6�   $	��148��6�   �� 5      -   5        $ lblDataFinal��5   ,   $��1��6   $��Data Final (dd/mm/aaaa):��6B   
�������$��Center=�6x   $	��Top=�6�   $��0,10,0,0q�6�   $��24��6�   $	��142��6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dataInicial��5   !   $��Center=�66   $��Center=�6S   $	��200��6n   $��24��6z   
�������
�������6�     5      -   5        $ 	dateFinal��5   1   $��1��6!   $��Center=�6D   $��Center=�6a   $	��200��6|   $��24��6�   
�������
�������6�   �� 5      -   5         ��Name$ 	btnSearch��5   -   $��2��6   $��	Pesquisar��6@   $��Center=�6T   $��Center=�6q   $	��200��6�   ���	#FF414141
�������$��32��6�   5      5      �� 5      -   5        $ btnExportarExcel��5      $��Exportar para Excel��6/   $��Center=�6M   $	��Top=�6j   $	��200��6�   ���	#FF414141
�������$��0,10,0,0q�6�   � 5      -   5         �Name$ progressBar��5      $��Center=�6/   $	��Top=�6L   $��16��6d   
�������
���  ��$	��200��6�   $��0,10,0,0q�6�   �� 5      $��Propriedades��6   $��Center=�6+   $��0,10,0,0q�6H   $	��Top=�6Z   
�������6r   �� 5      -   5         ��Name$ txtClientes��5      $��Center=�6+   $��0,10,0,0q�6H    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��200��6�   6�   �� 5      -	   5         ��Name$ lstClientes��5      $��Center=�6,   $��0,10,0,0q�6I    J� RenderTransformOrigin$ 0.5,0.5&�6[   $	��591��6{   z�5      V� 5      .~�5       �� �� 5!      	 �� AngleY$	 0Q�6(   �� 5"      T� 5#      
 T� Y$
 0Q�6-   5$       �� View 5&      �� 5'      .P�5(      �� $��Código do Vendedor��6)    �� Width$
 Auto��6f    �� DisplayMemberBinding 6E   �� 6f   5)      5+      5,      5-      5.      