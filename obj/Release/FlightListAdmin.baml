   M S B A M L   `   `   `  ���� N  JAirlineProjectIntel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AirlineProjectIntelAirlineProjectIntel  )    #AirlineProjectIntel.FlightListAdmin   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:AirlineProjectIntel       � Title$  FlightListAdmin��$	��450��$	��800��.���  � ColumnDefinitions �� $��1* ��� $��2* � � RowDefinitions �� $��1* ��� $��9* �.+��� -   $��Flights�� �� SelectionMode$ Single=� �� IsTextSearchEnabled . $
��Left=�$	��331��$��	20,20,0,0q�$��1��$	��Top=�$	��220���� -   $��menuBar��$��2��$��0���� -   $��
mainScreen��$��2��$��1���� -   $
��Quit��$��1��$
��Left=�$��
434,10,0,0q�$	��Top=�$��75���� -   $��Logout��$��1��$
��Left=�$��
337,10,0,0q�$	��Top=�$��75���� -   $��UserType��$
��Left=�$��	24,13,0,0q�$
��Wrap=�$��Administrator:��$	��Top=�
�������$��Franklin Gothic Book)��� -   $��AdminId��$
��Left=�$��
100,13,0,0q�$
��Wrap=�$�� ��$	��Top=�
�������$��Franklin Gothic Book)��� $��1��$
��Left=�$��	20,20,0,0q�$��1��$
��Wrap=�$	��Top=�$��Franklin Gothic Book)�$��24(�$	��321��$ ��Intel Airlines Flight List���� -   $��RemoveButton��$��Remove Selected��$��1��$
��Left=�$��
20,296,0,0q�$��1��$	��Top=�$	��114���� -	   $��
ViewButton��$��View Selected��$��1��$
��Left=�$��
20,331,0,0q�$��1��$	��Top=�$	��114���� -
   $��	AddButton��$��Add New��$��1��$
��Left=�$��
20,261,0,0q�$��1��$	��Top=�$	��114��(  "System.Windows.Controls.DatePicker  -   $��
SearchDate��$��1��$
��Left=�$��
20,101,0,0q�$��1��$	��Top=��� $��1��$��1��$��133,98,293,234q�.+�	� -   $��OnRadio��$��On This Date��$
��Left=�$��1��$	��Top=�	� -   $��
AfterRadio��$��After This Date��$
��Left=�$��1��$	��Top=��� -   $��Apply Filters��$��1��$
��Left=�$��373,101,0,0q�$��1��$	��Top=�$��75���� -   $��Reset Filters��$��1��$
��Left=�$��373,128,0,0q�$��1��$	��Top=�$��75���� $��1��$
��Left=�$��
20,149,0,0q�$��1��$
��Wrap=�$��Sort By:��$	��Top=��� $��1��$��1��$��20,170,379,132q�.+�	� -   $��DepRadio��$��Departing Airport��$
��Left=�$��1��$	��Top=�	� -   $��ArrRadio��$��Arriving Airport��$
��Left=�$��1��$	��Top=��� -   $
��Desc��$��Descending?��$��1��$
��Left=�$��164,170,0,0q�$��1��$	��Top=�