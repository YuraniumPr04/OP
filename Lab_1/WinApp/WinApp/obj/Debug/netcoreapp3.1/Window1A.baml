   M S B A M L   `   `   `  ����A  =WinApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WinAppWinApp  5   	       WinApp.Window1A   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WinApp     5   	   -   5          � Title$  Журнал��5
   	   $��220.459��6   $��450.521��6)   ���	#FFE6C0C0$y�Visible=�5       � WindowStartupLocation$ CenterScreen=�6   .��5      � .+�5   
   �� -   5        $
��CMB0��5      $
��Left=�6   $��35��6:   $��	10,10,0,0q�6F   $��14(�6Y   $	��Top=�6g   $	��220��6    �� 
IsEditable$
 True��6�   ��5      �� 5      .R�5      �� ��6    �� 5      5      �� 5      -   5         ��Name$	 TB1��5      $
��Left=�6'   $��35��6B   $��	10,51,0,0q�6N   $��14(�5   #    �� TextWrapping$
 Wrap=�5      $	��Top=�6   $	��220��6-   6�   �� 5   
   -   5        $	 TB2��5      $
��Left=�6   $��35��6:   $��	10,92,0,0q�6F   $��14(�5   #   $
 Wrap=�5      $	��Top=�6   $	��220��6-   6�   �� 5   
   -   5        $	 TB3��5      $
��Left=�6   $��35��6:   $��
10,133,0,0q�6F   $��14(�5      $
 Wrap=�5      $	��Top=�6   $	��220��6-   6�   �� 5   
   -   5         ��Name$ 
ReadButton��5      $��Додати��6%   $
��Left=�66   $
{�True��6Q   $��
280,10,0,0q�5      $	��Top=�6   $	��150��6-   $��35��69   6E   �� 5    
   -   5        $ 
EditButton��5       $��Редагувати��6%   $
��Left=�6:   ${�False��6U   $��
280,51,0,0q�5!      $	��Top=�6   $	��150��6-   $��35��69   6E   �� 5"   
   -   5        $ DeleteButton��5"      $��Видалити��6'   $
��Left=�6:   ${�False��6U   $��
280,92,0,0q�5#      $	��Top=�6   $	��150��6-   $��35��69   6E   �� 5$   
   -	   5        $
 ToMW��5$      $(��"До головного вікна��6   $
��Left=�6<   $��280,133,0,0q�6W   $	��Top=�5%      $	��150��6   $��35��6%   61   5&      5'      