   M S B A M L   `   `   `  ����N  JAirlineProjectIntel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AirlineProjectIntelAirlineProjectIntel  5   	       AirlineProjectIntel.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:AirlineProjectIntel     5   	     � Title$  Login��5   	   $	��450��6   $	��800��6$   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��9* �6   .+�5   
   �� -   5        $��menuBar��5      $��2��6#   $��0��67   6F   �� 5   
   -   5        $��
mainScreen��5      $��2��6&   $��1��6:   6I   �� 5   
   -   5        $
��Quit��5      $��1��63   $
��Left=�6C   $��
434,10,0,0q�6^   $	��Top=�6r   $��75��6�   �� 5   
   $��322,24,19,201q�6   $��1��6'   $��1��67   $��/images/airplane (2).png��6D   �� 5   
   $��1��6   $
��Left=�6$   $��	24,24,0,0q�6?   $��1��6R   $
��Wrap=�6_   $	��Top=�6s   $��24(�6�   $��Franklin Gothic Book)�6�   �� 6�   $�Intel Airlines��6�   �� 6�   �� 6�   $�Flight Reservation��6�   6  �� 5   
   	 �� X1$ 10��5      	 �� Y1$ 10��6   	 �� X2$ 10��5      	 �� Y2$	 350��6   
���   �$��2��5      $��2��6   $��254,0,446,0q�6-   $��1��6B   �� 5   
   $
��Left=�6   $��	25,95,0,0q�6/   $��1��6B   $
��Wrap=�6O   $	��Top=�6c   $��20(�6{   $��Franklin Gothic Book)�6�   $��Login��6�   �� 5   
   $
��Left=�6   $��23��6-   $��
25,153,0,0q�69   $��1��6M    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6�   $	��215��6�   ��6n   �� *UsernameText+6�   �� 5   
   $
��Left=�6   $��23��6-   $��
25,203,0,0q�69   $��1��6M   $
 Wrap=�6Z   $	��Top=�6�   $	��215��6�   ��6n   �� *PasswordText+6�   �� 5   
   -   5        $��Login��5      $
��Left=�65   $��
95,257,0,0q�6P   $��1��6d   $	��Top=�6q   $��75��6�   �� 5    
   $
��Left=�6   $��
25,175,0,0q�6/   $��1��6C   $
��Wrap=�6P   $	��Top=�6d   $��10(�6|   $��Franklin Gothic Book)�6�   �� 6�   $�Username��6�   �� 6�   �� 6�   6�   �� 5!   
   $
��Left=�6   $��
25,226,0,0q�6/   $��1��6C   $
��Wrap=�6P   $	��Top=�6d   $��10(�6|   $��Franklin Gothic Book)�6�   $��Password��6�   �� 5"   
   -   5         ��Name$ Error_Label��5"      $
��Left=�6I   $
��Wrap=�6d   $��
25,292,0,0q�6y   $	��Top=�6�   $	��215��6�   $��56��6�   $��1��6�   $��10(�6�   ��6)   �� *ErrorLabelText+6�   �� 5#   
   -   5        $��Register��5#      $��1��6;   $
��Left=�6K   $��
334,10,0,0q�6f   $	��Top=�6z   $��75��6�   5%      5&      