   M S B A M L   `   `   `  ????I  EStudent_hostel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Student_hostelStudent_hostel  5   	       Student_hostel.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Student_hostel     5   	     ? Title$  	LoginView??5   	   $	??550??6   $	??800??6(    ? WindowStyle$
 None=?5	   	    ? 
ResizeMode$ NoResize=?5
   	    ? WindowStartupLocation$ CenterScreen=?5   	   
??????  ? AllowsTransparency . .??5      ??  ?? CornerRadius$ 12??6   ??5   
   ?? 5      -   5        
image1?? ?? ImageSource$ /Icons/back-image.jpg??5   )    j? Stretch$
 None=?5      ._?5   
   ?? $ 10??6   $??2q?5       J? Opacity$
 0.95Q?5      ??5      ?? 5      	 ?? 
StartPoint$		 0,0&?6&   
 ?? EndPoint$	
 1,1&?67   .??5      ?  ? Color$ #462AD8??6#    ? Offset$ 0Q?63   ? 5      $ #DA34AE??6#   $
 0.75Q?63   ? 5      $ #8A16C1??6#   $ 1Q?63   5      ??5!      ?? 5"      $		 0,1&?6&   $	
 1,0&?67   .??5#      ? $ #060531??6#   $ 0Q?63   ? 5$      $ #1B1448??6#   $ 1Q?63   5%      ._?5(      ?  ? RowDefinitions 5)      ?? 5*      $??30 ?6$   ?? 5+      .+?5.      ? $??0??6    ? ColumnDefinitions 50      ?? 51      ?? 52      $??25 ?6+   ?? 53      $??25 ?6+   ?? 54      $??25 ?6+   ?? 55      $??5 ?6+   .+?5:      ?? -   5         ??Name$ btnMinimize??5:      $??0q?5;      $??-??5<      
???????$??16(?5>      $??
Montserrat)?5?       ? Cursor$
 Hand??5@      $??1??5A      ??5C      ?? 5D       ?? 
TargetType" ??6$   .?5E   "   ??  ?? Property ? ?? ?? Value ?#28AEED6?    ?? Triggers 5F   "   P? 5G   &    P? Property ?@J?IsMouseOver P? Value . . ?5H   *   ??  ? ?? ?#278BEF6G   5I   '   5K      ??5N      ?? 5O       ?? 
TargetType" ??6.   .R?5P   "   ?? $??18??6)   $??18??64   $ 9??5Q   )   #??z??5R   )   ._?5S   &   ?? $??Center=?67   $??Center=?5T   7   5U   #   5V      5Y      ?? 5Z      -   5        $ btnMaximize??5Z      $??0q?5[      $	??▢??5\      
???????$??16(?5^      $??
Montserrat)?5_      $
 Hand??5`      $??2??5a      ??5c      ?? 5d      " ??6$   .?5e   "   ??  ? ?? ?#28AEED6?    5f   "   P? 5g   &    ?@J?IsMouseOver . . ?5h   *   ??  ? ?? ?#278BEF6G   5i   '   5k      ??5n      ?? 5o      " ??6.   .R?5p   "   ?? $??18??6)   $??18??64   $ 9??5q   )   #??z??5r   )   ._?5s   &   ?? $??Center=?67   $??Center=?5t   7   5u   #   5v      5y      ?? 5z      -   5        $ btnClose??5z      $??0q?5{      $??X??5|      
???????$??12(?5~      $??
Montserrat)?5      $
 Hand??5?      $??3??5?      $??2??6-   $??-2.4,0,0.2,0q?6A   $??30??6W   $	??Top=?6c   ??5?      ?? 5?      " ??6$   .?5?   "   ??  ? ?? ?#DA34AE6?    5?   "   P? 5?   &    ?@J?IsMouseOver . . ?5?   *   ??  ? ?? ?#C62DAE6G   5?   '   5?      ??5?      ?? 5?      " ??6.   .R?5?   "   ?? $??18??6)   $??18??64   $ 9??5?   )   #??z??5?   )   ._?5?   &   ?? $??Center=?67   $??Center=?5?   7   5?   #   5?      5?      5?      ?? 5?      $	??220??6   $??1??5?       ?? Orientation$ Vertical=?5?      $??0,35,0,0q?5?      .+?5?      ?? $$??/Icons/student-hostel-logo.png??6   $	??100??5?      $	??100??6(   ?? 5?      $??Student Hostel??6    
???????$??25(?5?       $??Medium"?5?       $??
Montserrat)?5?       $??Center=?5?       ?? 5?      $%??Place where you could feel safe??6    
???????$??12(?5?       $??Medium"?5?       $??
Montserrat)?5?       $
??Wrap=?5?        ?? TextAlignment$ Center=?5?       $??0,5,0,0q?5?       ?? 5?      $??Email??6    
???????$??12(?5?       $??Medium"?5?       $??
Montserrat)?5?       $??0,35,0,0q?5?       ?? 5?      -   5         ??Name$ txtUser??5?      $??13(?5?      $??Medium"?5?      $??
Montserrat)?5?      
??????? ?? 
CaretBrush
 ?????
???????$??0,0,0,2q?5?      $??28??5?      $??Center=?5?      $??0,5,0,0q?5?      $??20,0,0,0q?5?      .??61   ??5?      ?? 5?      $ /Icons/user-icon.png??6)   $
 None=?5?   )    j? 
AlignmentX$
 Left=?5?   )   .??5?   .   5?      ?? 5?      $??Confirm Password??6    
???????$??12(?5?       $??Medium"?5?       $??
Montserrat)?5?       $??0,15,0,0q?5?       G? 5?      -   5         G?Name$ passwordtxt??5?   "   $??13(?5?      $??Medium"?5?      $??
Montserrat)?5?      
??????? G? 
CaretBrush
 ?????
???????$??0,0,0,2q?5?      $??28??5?      $??Center=?5?      $??0,5,0,0q?5?      $??20,0,0,0q?5?      ??5?      ?? 5?      $ /Icons/key-icon.png??6)   $
 None=?5?   )   $
 Left=?5?   )   5?      ?? 5?      -   5        $ btnLogin??5?      $??0q?5?      $??LOGIN??5?      
???????$??12(?5?      $??
Montserrat)?5?      $
 Hand??5?      $??0,50,0,0q?5?      ??5?      ?? 5?      " ??6$   .?5?   "   ??  ? ?? ?#462AD86?    5?   "   P? 5?   &    ?@J?IsMouseOver . . ?5?   *   ??  ? ?? ?#28AEED6G   5?   '   5?      ??5?      ?? 5?      " ??6.   .R?5?   "   ?? $	??150??6)   $??40??65   $ 20??5   )   #??z??5  )   ._?5  &   ?? $??Center=?67   $??Center=?5  7   5  #   5     5     ?? 5	     $ 
Horizontal=?6!   $??Center=?5
  !   $??0,15,0,0q?5  !   .+?5     ?? $??Forgot you're password???6$   
???????$??12(?5      $??Medium"?5      $??
Montserrat)?5      ?? 5     -   5        $??Reset??5  $   
???????$??12(?5      $??Medium"?5      $??
Montserrat)?5      $
 Hand??5      $??8,0,0,0q?5      61   5     5     5     5!     5#     5$     