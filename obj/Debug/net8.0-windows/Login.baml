   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.2.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRMCRM  5   	       	CRM.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:CRM     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5	   	   $	��600��6   $
��1000��6$    )  %MaterialDesignDarkSeparatorBackground#���   5
   	    � WindowStartupLocation$ CenterScreen=�6N    � WindowState$ 	Maximized=�6s   .��5      �  � RowDefinitions 5   
   �� 5      $	��30* �6   �� 5      $
��187* �6   .+�5   
   �� $��1��6   $��Center=�6"   $��Center=�6?   $	��300��6Z   $	��238��6f   .+�5      �� $��Login��6   $��28(�6%   $
��Bold"�63    + 'MaterialDesign.Brush.Primary.Foreground#���  6E   $��Center=�6�   �� 5      -   5         ��Name$ txtLogin��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Usuário��5   
    ! MaterialDesignOutlinedTextBox#��[ 5   
   $	��250��5   
   $��	0,20,0,10q�5   
    % !MaterialDesign.Brush.Primary.Dark#���  5   
   #���  5   
   
������ 5   
   G� 5"      -   5         G�Name$ txtPass��5"      $ Senha��5#       % !MaterialDesignOutlinedPasswordBox#��[ 5$      $	��250��5%      $��	0,10,0,20q�5&      #���  6-    0 ,MaterialDesign.Brush.Primary.Dark.Foreground#���  6o   �� 5)      -   5         ��Name$ btnLogin��5)      $��Entrar��5*      $	��150��5+      $��40��5,        MaterialDesignRaisedButton#��[ 5-        PrimaryHueMidBrush#���  5.      
������� � Cursor$
 Hand��5/   (   66   51      52      53      