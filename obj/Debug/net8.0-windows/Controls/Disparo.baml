   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.2.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CRM.ControlsCRM.Controls  5          CRM.Controls.Disparo   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:CRM.Controls     5      ���	#FF1A1A1A.��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ cmbTemplates��5      $��Center=�6)   $��Center=�6F   $	��749��6a   $��28��6m   $��1��6y   �� 5   
   -   5         ��Name$ borderBackMensagem��5      
���   �$��1q�6A   $��2��6U   $��5q�6b   ��5      �� 5       �� ImageSource$ /Controls/backWhats.jpg��6    j� TileMode$
 None=�6C    j� Stretch$ UniformToFill=�6S   ._�5      �� $
��Auto=�6   $��Disabled=�6>   $��1q�6g   .��5      �� -   5         ��Name$ txtTemplate��5      $
��Wrap=�61   $�� ��6E   $��9q�6M   $��18(�6X   $��Bahnschrift)�6f   
�������6   5      5      � 5   
   $��4��6   $��0q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5       $��5 �6#   �� 5!      $��* �6#   .+�5$      �� -   5         ��Name$ scrollViewerConsole��5$      $
��Auto=�68   $
��Auto=�6[   $��0��6�   .��5%      �� -   5        $ txtBlockConsole��5%      $
��Wrap=�65   ���	#FF1F1E1E
�������6`   5&      �� 5(      -   5        $ scrollViewerConsoleT��5(      $
��Auto=�69   $
��Auto=�6\   $��2��6�   .��5)      �� -   5        $ txtBlockConsoleResponse��5)      $
��Wrap=�6=   ���	#FF1F1E1E
�������6h   5*      5,      � 5.   
   $��5��6   $��66��6    5/      �� 50      $��* �6#   �� 51      $��45 �6#   �� 52      $��45 �6#   .+�54      � -   5        	 �Name$	 progressDisparo��54      $��37��63   $��0��6?   $	��5,0q�6O   �� 55      -	   5        
 ��Name$
 btnEnviarDisparo��55      $��1��6/   $��37��6?   $��37��6K   ���	#FF191919$
��Left=�6�   $��Center=�6�   $	��5,0q�6�   ��56      �� 57      $ UniformToFill=�6!   $$ /Controls/botao-reproduzir.png��69   59      �� 5:      -
   5        $
 btnPareDisparo��5:      $��2��6-   $��37��6=   $��37��6I   ���	#FF191919��5;      �� 5<      $ UniformToFill=�6!   $ /Controls/pare.png��69   5>      5?      �� 5A   
   $��0,0,0,0q�6   ���	#FF212121$��Bottom=�6<   $��40��6W   
�������.@�5B      �� -   5         ��Name$ statusContatos��5B      $��	0,0,150,0q�64   .��5C      �� -   5        $ statusContatosText��5C      $��Quantidade de contatos:��68   
�������6W   5D      �� 5E      -   5        $ statusUtility��5E      $��	0,0,150,0q�63   .��5F      �� -   5        $ statusUtilityText��5F      $��Valor Utility:��67   
�������6M   5G      �� 5H      -   5        $ statusMarketing��5H      $��	0,0,120,0q�65   .��5I      �� -   5        $ statusMarketingText��5I      $��Valor Marketing:��69   
�������6Q   5J      �� 5K      -   5        $ statusTempo��5K      .��5L      �� -   5        $ statusTempoText��5L      $��Tempo Médio:��65   
�������6I   5M      5N      � 5O   
   $��3��6   $��0q�6    5P      �� 5Q      $	��190 �6#   �� 5R      $��* �6#   .+�5T      �� -   5        $��SelectFileButton��5T      $��Selecionar Arquivo��6-   $��24��6J   $��0��6u   $��Center=�6�   $��	10,0,10,0q�6�   �� 5U      -   5        $��FilePathTextBox��5U      $��24��6-    �� 
IsReadOnly$
 True��69   
�������$��1��6�   $��Center=�6�   ��6K   Z� ��6a   Z� 6�   5V      5X      5Y      