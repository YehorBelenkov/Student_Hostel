   M S B A M L   `   `   `  ????I  EStudent_hostel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Student_hostelStudent_hostel  5   	       Student_hostel.Edit   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Student_hostel     5   	     ? Title$  	LoginView??5   	   $	??550??6   $	??800??6(    ? WindowStyle$
 None=?5   	    ? 
ResizeMode$ NoResize=?5	   	    ? WindowStartupLocation$ CenterScreen=?5
   	   
??????  ? AllowsTransparency . .??5      ??  ?? CornerRadius$ 12??6   ??5   
   ?? 5       ?? ImageSource$ /Icons/back-image1.jpg??6    j? Stretch$
 None=?5      ._?5   
   ?? $ 10??6   $??2q?5       J? Opacity$
 0.95Q?5      ??5      ?? 5      	 ?? 
StartPoint$		 0,0&?6&   
 ?? EndPoint$	
 1,1&?67   .??5      ?  ? Color$ #462AD8??6#    ? Offset$ 0Q?63   ? 5      $ #DA34AE??6#   $
 0.75Q?63   ? 5      $ #8A16C1??6#   $ 1Q?63   5      ??5       ?? 5!      $		 0,1&?6&   $	
 1,0&?67   .??5"      ? $ #060531??6#   $ 0Q?63   ? 5#      $ #1B1448??6#   $ 1Q?63   5$      ._?5'      ?  ? RowDefinitions 5(      ?? 5)      $??30 ?6$   ?? 5*      .+?5-      ? $??0??6    ? ColumnDefinitions 5/      ?? 50      ?? 51      $??25 ?6+   ?? 52      $??25 ?6+   ?? 53      $??25 ?6+   ?? 54      $??5 ?6+   .+?59      ?? -   5         ??Name$ btnMinimize??59      $??0q?5:      $??-??5;      
???????$??16(?5=      $??
Montserrat)?5>       ? Cursor$
 Hand??5?      $??1??5@      ??5B      ?? 5C       ?? 
TargetType" ??6$   .?5D   "   ??  ?? Property ? ?? ?? Value ?#28AEED6?    ?? Triggers 5E   "   P? 5F   &    P? Property ?@J?IsMouseOver P? Value . . ?5G   *   ??  ? ?? ?#278BEF6G   5H   '   5J      ??5M      ?? 5N       ?? 
TargetType" ??6.   .R?5O   "   ?? $??18??6)   $??18??64   $ 9??5P   )   #??z??5Q   )   ._?5R   &   ?? $??Center=?67   $??Center=?5S   7   5T   #   5U      5X      ?? 5Y      -   5        $ btnMaximize??5Y      $??0q?5Z      $	??▢??5[      
???????$??16(?5]      $??
Montserrat)?5^      $
 Hand??5_      $??2??5`      ??5b      ?? 5c      " ??6$   .?5d   "   ??  ? ?? ?#28AEED6?    5e   "   P? 5f   &    ?@J?IsMouseOver . . ?5g   *   ??  ? ?? ?#278BEF6G   5h   '   5j      ??5m      ?? 5n      " ??6.   .R?5o   "   ?? $??18??6)   $??18??64   $ 9??5p   )   #??z??5q   )   ._?5r   &   ?? $??Center=?67   $??Center=?5s   7   5t   #   5u      5x      ?? 5y      -   5        $ btnClose??5y      $??0q?5z      $??X??5{      
???????$??12(?5}      $??
Montserrat)?5~      $
 Hand??5      $??3??5?      $??2??6-   $??-2.4,0,0.2,0q?6A   $??30??6W   $	??Top=?6c   ??5?      ?? 5?      " ??6$   .?5?   "   ??  ? ?? ?#DA34AE6?    5?   "   P? 5?   &    ?@J?IsMouseOver . . ?5?   *   ??  ? ?? ?#C62DAE6G   5?   '   5?      ??5?      ?? 5?      " ??6.   .R?5?   "   ?? $??18??6)   $??18??64   $ 9??5?   )   #??z??5?   )   ._?5?   &   ?? $??Center=?67   $??Center=?5?   7   5?   #   5?      5?      5?      ?? 5?      $
??auto??6   $??1??5?       ?? Orientation$ Vertical=?5?      $??0,35,0,0q?5?      .+?5?      ?? $ 
Horizontal=?6!   $??0,15,0,0q?5?   !   $
??auto??63   $
??auto??6@   $
??Left=?6N   .+?5?      &   System.Windows.Controls.DataGrid  -   5        $??	datagrid1??5?   #   $	??400??64   $	??300??6@   $??30,-100,0,0q?6M   ?? 5?      -   5        $ updateinformation??5?   !   $??0q?5?      $
??EDIT??5?      
???????$??12(?5?      $??
Montserrat)?5?      $
 Hand??5?      $??-100,260,0,0q?5?      $??Center=?63   $??1??6P   ??5?      ?? 5?   "   " ??6(   .?5?   &   ??  ? ?? ?#462AD86C    5?   &   P? 5?   *    ?@J?IsMouseOver . . ?5?   .   ??  ? ?? ?#28AEED6K   5?   +   5?   #   ??5?      ?? 5?   "   " ??62   .R?5?   &   ?? $	??100??6-   $??40??69   $ 20??5?   )   #??z??5?   )   ._?5?   *   ?? $??Center=?6;   $??Center=?5?   7   5?   '   5?   #   5?      ?? 5?      -   5        $??stackpanel1??5?   =   $
??auto??5?   %   $??1??5?      $ Vertical=?5?      $??	0,0,300,0q?5?      $	??400??60   .+?5?      ?? -   5        $??label1??5?   $   $??Address:??62   
???????$??22(?6W   ?? 5?      -   5        $??textbox1??5?   &   {?. $??16(?5?      $??
Montserrat)?5?      
??????? ?? 
CaretBrush
 ?????
???????$??0,0,0,0q?5?      $??28??5?      $??Center=?5?      $??0,-7,0,0q?5?      $??7,7,0,0q?5?      $??Address??60   .??6?   ??5?   "   ?? 5?   &   .??5?   6   5?      ?? 5?      -	   5        $??label2??5?   $   $??Address:??62   
???????$??22(?6W   ?? 5?      -
   5        $??textbox2??5?   &   {?. $??16(?5?      $??
Montserrat)?5?      
???????
 ?????
???????$??0,0,0,0q?5?      $??28??5?      $??Center=?5?      $??0,-7,0,0q?5?      $??7,7,0,0q?5?      $??Address??60   .??6?   ??5?   "   ?? 5?   &   .??5?   6   5?      ?? 5?      -   5        $??label3??5?   $   $??Address:??62   
???????$??22(?6W   ?? 5?      -   5        $??textbox3??5?   &   {?. $??16(?5?      $??
Montserrat)?5?      
???????
 ?????
???????$??0,0,0,0q?5?      $??28??5?      $??Center=?5?      $??0,-7,0,0q?5?      $??7,7,0,0q?5?      $??Address??60   .??6?   ??5?   "   ?? 5?   &   .??5?   6   5?      ?? 5?      -   5        $??label4??5?   $   $??Address:??62   
???????$??22(?6W   ?? 5?      -   5        $??textbox4??5?   &   {?. $??16(?5?      $??
Montserrat)?5?      
???????
 ?????
???????$??0,0,0,0q?5?      $??28??5      $??Center=?5     $??0,-7,0,0q?5     $??7,7,0,0q?5     $??Address??60   .??6?   ??5  "   ?? 5  &   .??5  6   5     ?? 5     -   5        $??label5??5  $   $??Address:??62   
???????$??22(?6W   ?? 5	     -   5        $??textbox5??5	  &   {?. $??16(?5
     $??
Montserrat)?5     
???????
 ?????
???????$??0,0,0,0q?5     $??28??5     $??Center=?5     $??0,-7,0,0q?5     $??7,7,0,0q?5     $??Address??60   .??6?   ??5  "   ?? 5  &   .??5  6   5     ?? 5     -   5        $??labelv??5  $   $??	Violation??62   
???????$??150,-130,0,0q?6Y   $y?Hidden=?6o   ?? 5     -   5        $??violationpage??5  &   $??150,-100,0,0q?6;   $	??150??6Q   $	??100??6]   $y?Hidden=?6j   {?. 
???????6?   5     ?? 5     -   5        $??stackpanel2??5  >   $	??200??5  %   $??1??5     $ Vertical=?5     $??
-890,0,0,0q?5     $	??400??61   .+?5     ?? -   5        $??combo1??5  '   $	??100??65   $??-200,40,0,0q?6A   6V   ?? 5      -   5        $??combo2??5   '   $	??100??65   $??-200,40,0,0q?6A   6V   ?? 5!     -   5        $??combo3??5!  '   $	??100??65   $??-200,35,0,0q?6A   ?? 5"     -   5        $??combo4??5"  '   $	??100??65   $??-200,35,0,0q?6A   6V   ?? 5#     -   5        $??combo5??5#  '   $	??100??65   $??-200,40,0,0q?6A   5$     5&     5(     5)     5+     5-     5.     