   M S B A M L   `   `   `  ���� J  FWpfApplication3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication3WpfApplication3       WpfApplication3.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication3       � Title$  
MainWindow��$��516.155��$��1009.977��.��� .+��� -    ��Name$ 
tabControl��$
��Left=�$	��493��$	��Top=�$
��1014��.@��� $��Товары��.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$
��Left=�$	��Top=�$	��386��$	��989��   
IsReadOnly .    RowBackground
 �����   AlternatingRowBackground
 �����   	RowHeight$ 50Q�   AutoGenerateColumns .   � ContextMenu �� .@�m� -   $��Изменить��m� -   $��Удалить��	   Columns	 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn
   Header$
 Id��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *id+  $
 Имя�� �� *name+  $
 Цена�� �� *price+  $
 Размер�� �� *size+  $)
 #Артикль постовщика�� �� *articulPost+  $
 Наш Артикль�� �� *	articul+  $$
 Заметка к товару�� �� *	comment+4  .System.Windows.Controls.DataGridCheckBoxColumn  $
 Наличи�� �� *ButtonEnabled+ �� Mode$ OneWay=�4  .System.Windows.Controls.DataGridTemplateColumn  $
 Изображения��   CellTemplate �� .R��� -   .���� ���� *dis+�� -    ��Name$	 Add��$,��&Добавить новый товар��$
��Left=�$	��Top=�$	��161��$��26��$��
23,415,0,0q��� $��Заказы��.��� .+�  -   $ 	dataGrid1��$��10,35,221,102q� .   .  �� .@�m� -   $��Изменить��m� -	   $��Удалить��	   $
 Id�� �� *id+  $
 ФИО�� �� *fio+  $
 
Адрес�� �� *adres+  $%
 Заметка к адресу �� �� *adresComment+  $
 Телефон�� �� *tel+  $'
 !Ссылка на соц.сети�� �� *ssylkaNaSosSeti+  $
 Комментарии�� �� *	comment+  $0
 *Цена доставки курьером�� �� *
priceKur+  $,
 &Цена доставки почтой�� �� *priceDeliveryPochta+  $
 Предоплата�� �� *
predOplata+  $
 Трек�� �� *trek+  $
 Статус�� �� *status+  $
 Имя оператора�� �� *nameOperatora+�� -
    ��Name$ comboBox��$
��Left=�$��	112,8,0,0q�$	��Top=�$	��120��.@��� Все�� Завершенные�� Оформленные�� Неоформленные�� -   $ buttonProvestiZakaz��$!��Провести заказ��$��602,389,221,39q��� -    ��Name$ label��$��Сортировать��$
��Left=�$��10,4,0,0q�$	��Top=�$��64���� -    ��Name$ textBox��$
��Left=�$	��328��$��
804,35,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��179���� -   $ buttonForAddNewZakaz��$��Новый заказ��$
��Left=�$��
10,389,0,0q�$	��Top=�$	��149��$��37���� -   $ button��$��Сохранить��$
��Left=�$��804,374,0,0q�$	��Top=�$��75���� -   $ button1��$��Очистить��$��917,374,25,71q��� $��Статистика��.��� .+�(  "System.Windows.Controls.DatePicker  -     Name$ DatePicker1��$��719,5,181,438q�  -   $ DatePicker2��$��874,5,25,438q��� -   $ buttonSortDate��$��Применить��$��892,35,25,400q��� -   $ comboBoxStatistika��$
��Left=�$��	198,8,0,0q�$	��Top=�$	��120��.@��� Все�� Завершенные�� Оформленные�� Неоформленные  -   $ dataGridStatistika��$��10,35,221,102q� .   .  �� .@�m� -   $��Изменить��m� $��Удалить��	   $
 Id�� �� *id+  $
 ФИО�� �� *fio+  $
 
Адрес�� �� *adres+  $%
 Заметка к адресу �� �� *adresComment+  $
 Телефон�� �� *tel+  $'
 !Ссылка на соц.сети�� �� *ssylkaNaSosSeti+  $
 Комментарии�� �� *	comment+  $0
 *Цена доставки курьером�� �� *
priceKur+  $,
 &Цена доставки почтой�� �� *priceDeliveryPochta+  $
 Предоплата�� �� *
predOplata+  $
 Трек�� �� *trek+  $
 Статус�� �� *status+  $
 Дата заказа�� �� *	dateZak+  $
 Имя оператора�� �� *nameOperatora+�� -   $ Excel��$��Excel��$��917,374,25,71q��� $��Профиль��.��� .+��� -   $ button2��$��Button��$
��Left=�$��	10,76,0,0q�$	��Top=�$��75���� -   $ label1��$��Label��$
��Left=�$��
107,70,0,0q�$	��Top=�$	��157��