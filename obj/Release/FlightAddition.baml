   M S B A M L   `   `   `  ���� N  JAirlineProjectIntel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AirlineProjectIntelAirlineProjectIntel  (    "AirlineProjectIntel.FlightAddition   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:AirlineProjectIntel       � Title$  
MainWindow��$	��450��$	��800��.���  � ColumnDefinitions �� $��1* ��� $��2* � � RowDefinitions �� $��1* ��� $��9* �.+��� $	��➔��$��254,95,252,251q�$��1��$��1��$��18(�$��20��$��30���� -   $��menuBar��$��2��$��0���� -   $��
mainScreen��$��2��$��1���� -    ��Name$ MyItemsControl_FCLeft��$��Center=�$	��Top=�$��55,50,145,0q�$��1��$��0��$��60������ .R��� $	��Foo��$
��20.0��$
��20.0��.��� .+��� $��60(�$
��Bold"�$��Center=�$��Center=����� *	TileLabel+���� *	TileBrush+���� .R��  � Orientation$ 
Horizontal=��� -   $ MyItemsControl_FCRight��$��Center=�$	��Top=�$��145,50,55,0q�$��1��$��0��$��60������ .R���  ��Name$	 Foo��$
��20.0��$
��20.0��.��� .+��� $��60(�$
��Bold"�$��Center=�$��Center=����� *	TileLabel+���� *	TileBrush+���� .R�� $ 
Horizontal=��� -   $ MyItemsControl_ELeft��$��Center=�$	��Top=�$��55,175,145,0q�$��1��$��0��$��60������ .R��� $	��Foo��$
��20.0��$
��20.0��.��� .+��� $��60(�$
��Bold"�$��Center=�$��Center=����� *	TileLabel+���� *	TileBrush+���� .R�� $ 
Horizontal=��� -   $ MyItemsControl_ERight��$��Center=�$	��Top=�$��145,175,55,0q�$��1��$��0��$��60������ .R��� $	 Foo��$
��20.0��$
��20.0��.��� .+��� $��60(�$
��Bold"�$��Center=�$��Center=����� *	TileLabel+���� *	TileBrush+���� .R�� $ 
Horizontal=��� $��420,281,10,31q�$��1��$��1��$��/images/airplane (2).png���� -   $��UserType��$
��Left=�$��	24,13,0,0q�$
��Wrap=�$��Administrator:��$	��Top=�
�������$��Franklin Gothic Book)��� -   $��
adminIdBox��$
��Left=�$��
100,11,0,0q�$
��Wrap=�
�������$	��Top=����� *AdminIDText+�� -	   $
��Back��$��1��$
��Left=�$��
52,331,0,0q�$��1��$	��Top=�$��75���� -
   $��Refresh Seating��$��1��$
��Left=�$��158,331,0,0q�$��1��$	��Top=�$	��100���� -   $
��Quit��$��1��$
��Left=�$��
434,10,0,0q�$	��Top=�$��75���� -   $��totalCapacityBox�� �� 
IsReadOnly . $��1��$
��Left=�$��20��$��
92,264,0,0q�$��1�� �� TextWrapping$
 Wrap=�$	��Top=�$��75������ *CapacityText+�� $��1��$
��Left=�$��12��$��
10,267,0,0q�$��1��$
��Wrap=�$��Total Capacity��$	��Top=�$��82��
���   �$��Franklin Gothic Book)��� -   $��firstCapacityBox��$��1��$
��Left=�$��20��$��
92,183,0,0q�$��1��$
 Wrap=�$	��Top=�$��75������ *	FCNumText+�� -   $��firstPriceBox��$��1��$
��Left=�$��20��$��178,183,0,0q�$��1��$
 Wrap=�$	��Top=�$��75������ *FCPriceText+�� -   $��economyCapacityBox��$��1��$
��Left=�$��20��$��
92,224,0,0q�$��1��$
 Wrap=�$	��Top=�$��75������ *
ENumText+�� -   $��economyPriceBox��$��1��$
��Left=�$��20��$��178,224,0,0q�$��1��$
 Wrap=�$	��Top=�$��75������ *
EPriceText+�� -    ��Name$ Error_Label��$
��Left=�$
��Wrap=�$��283,183,0,0q�$	��Top=�$	��224��$��58��$��1��$��1��$��10(����� *ErrorLabelText+�� ���	#FFF4F4F5$
��Left=�$	��345��
���   �$	��Top=�$��2��$��
263,15,0,0q�$��1��	 J� RenderTransformOrigin$	 0.5,0.5&�z�V� .~��� 
 �� ScaleX$
 -1Q��� �� T� �� $��1��$
��Left=�$��
10,186,0,0q�$��1��$
��Wrap=�$��First Class��$	��Top=�$��Franklin Gothic Book)��� $��1��$
��Left=�$��
10,227,0,0q�$��1��$
��Wrap=�$��Economy��$	��Top=�$��Franklin Gothic Book)��� $��1��$
��Left=�$��
92,169,0,0q�$��1��$
��Wrap=�$��Capacity��$	��Top=�$��Franklin Gothic Book)�$��10(��� $��1��$
��Left=�$��178,169,0,0q�$��1��$
��Wrap=�$	��Top=�$��Franklin Gothic Book)�$��10(��� $�Ticket Price ($)���� �� �� 
���   �$��1q�$
��Left=�$	��331��$��	20,20,0,0q�$��1��$	��Top=�$	��225���� $
��Left=�$��20,5,0,0q�$��1��$
��Wrap=�$��Seating��$	��Top=�$��Franklin Gothic Book)�$��10(��� 
���   �$��1q�$
��Left=�$��64��$��281,180,0,0q�$��1��$	��Top=�$	��228��$��1���� -   $��DAirportBox�� �� IsTextSearchEnabled . $��1��$
��Left=�$��	10,98,0,0q�$��1��$	��Top=�$	��100�� �� Text �� *DepStopText+�� -   $��AAirportBox�� . $��1��$
��Left=�$��
281,98,0,0q�$��1��$	��Top=�$	��100�� �� *ArrStopText+�� $��1��$
��Left=�$��
193,98,0,0q�$��1��$	��Top=�$��50�� �� *DepTM+.@���  �� 
IsSelected . .��AM�� .��PM�� $��1��$
��Left=�$��
460,98,0,0q�$��1��$	��Top=�$��50�� �� *ArrTM+.@���  . .��AM�� .��PM�� -    ��Name$ firstCapacityBox_Copy��$��1��$
��Left=�$��22��$��
121,98,0,0q�$��1��$
 Wrap=�$	��Top=�$��61������ *DepTimeText+�� -   $ firstCapacityBox_Copy1��$��1��$
��Left=�$��22��$��
391,98,0,0q�$��1��$
 Wrap=�$	��Top=�$��61������ *ArrTimeText+�� $��1��$
��Left=�$��	10,79,0,0q�$��1��$
��Wrap=�$��	Departure��$	��Top=�$��Franklin Gothic Book)��� $��1��$
��Left=�$��
281,79,0,0q�$��1��$
��Wrap=�$��Arrival��$	��Top=�$��Franklin Gothic Book)��� $��1��$
��Left=�$��	11,26,0,0q�$��1��$
��Wrap=�$	��Top=�$��Franklin Gothic Book)�$��24(����� *	TitleText+�� $��1��$
��Left=�$��281,249,0,0q�$��1��$
��Wrap=�$	��Top=�$��Franklin Gothic Book)�$��8(��� $�	Error Log���� �� �� -   $��Upload��$��1��$
��Left=�$��288,331,0,0q�$��1��$	��Top=�$��75���� -   $��Logout��$��1��$
��Left=�$��
338,10,0,0q�$	��Top=�$��75��(  "System.Windows.Controls.DatePicker  -   $��
FlightDate��$��1��$
��Left=�$��
408,26,0,0q�$��1��$	��Top=�