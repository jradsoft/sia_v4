   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35`Dclr-namespace:System.Windows.Controls;assembly=PresentationFrameworkSystem.Windows.Controls  5   	   dFclr-namespace:System.Windows.Navigation;assembly=PresentationFrameworkSystem.Windows.Navigation  5   	   p lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls 5   	   B >wpfEFac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:wpfEFac.HelperswpfEFac.Helpers 5   	      wpfEFac.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   Z	constrolsDclr-namespace:System.Windows.Controls;assembly=PresentationFramework      5   	   ]
navigationFclr-namespace:System.Windows.Navigation;assembly=PresentationFramework      5   	   ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  5   	   htoolkit_inputTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit  5   	   ,acordionclr-namespace:wpfEFac.Helpers  5   	   -   5          � Title$  < MyFacturaE CFDi/>��5	   	   $	��600��6+   $	��750��68    � WindowState$ 	Maximized=�5
   	    � Icon$3 -/wpfEFac;component/Images/IconoEFacWindow.png��6!   ��5      �� 5   
    �� ImageSource$+ %/wpfEFac;component/bin/Debug/logo.jpg��6   .��5      � -   5         �Name$ 
LayoutRoot��5      ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF6693D1��6    � Offset$ 1Q�61   � 5      $ White��6   $ 0.098Q�6-   � 5      $ 	#FFEBF0F7��6   $ 0.607Q�61   5      	 � RowDefinitions	 5   
   �� 5      $��53 �6   �� 5      $	��182 �6   �� 5      $	��145 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   
 � ColumnDefinitions
 5   
   �� 5       $��0 �6   �� 5!      $
��472* �6   .+�5$   
   �� $��2��6   $��0,0,0,0q�6(   ��5%      �� 5&      $. (/wpfEFac;component/Images/Marquesina.jpg��6   5(      �� 5*   
   -   5        $��grbMiEmpresa��5*   :   $��
Mi Empresa��6   
�������$��2��6N   $��0,0,0,0q�6_   .��5+      �  J� 	AllowDrop .  	 5,      �� 5-      $��57 �6$   �� 5.      $��33 �6$   �� 5/      $��40 �6$   �� 50      $��40 �6$   �� 51      $��40 �6$   .+�53      �� $��0��6   .+�54      �� -   5        $��txbNombreEmpresa��54   \   $
��Auto��6    $��Center=�6.   $��0,0,0,0q�6K   $��Adesoft S.A. de C.V.��6t   $	��Top=�6�   $��9(�6�   �� 55      -   5        $��txbRFC��55   \   $
��Auto��6    $��Center=�6.   $��0,0,0,0q�6K   $��RFC: PME090108144��6j   $	��Top=�6�   $��9(�6�   �� 56      -   5        $��txbCDF��56   \   $
��Auto��6    $��Center=�6.   $��0,0,0,0q�6K   $��CDF: Recibo de Honorarios��6j   $	��Top=�6�   $��9(�6�   �� 57      -   5        $��txbPlan��57   [   $
��Auto��6    $��Right=�6.   $��0,0,0,0q�6J   $��Plan ilimitado��6j   $	��Top=�6�   $��9(�6�   ���	#FF3DA6B16�   58      �� 59      $��1��6   .+�5:      �� -   5        $��txbCertificados��5:   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $&�� CERTIFICADO 10001200000000022517��6q   $	��Top=�6�   $��9(�6�   
���   �6�   �� 5;      -	   5        $��txbVerTodos��5;   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��	Ver Todos��6m   $	��Top=�6~   $��9(�6�   ���	#FF3DA6B16�   5<      �� 5=      $��2��6   .+�5>      �� -
   5        $��txbFolio��5>   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��FOLIOS 10001-10120��6j   $	��Top=�6�   $��9(�6�   
���   �6�   �� 5?      -   5        $��	txbVerMas��5?   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��Ver Mas��6k   $	��Top=�6z   $��9(�6�   ���	#FF3DA6B16�   �� 5@      -   5        $��txbSiguente��5@   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��Siguiente Folio 10001��6m   $	��Top=�6�   $��9(�6�   ���	#FF3DA6B16�   5A      �� 5B      $��3��6   .+�5C      �� -   5        $��	txbFolio1��5C   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��FOLIOS 1-3000 ��6k   $	��Top=�6�   $��9(�6�   
���   �6�   �� 5D      -   5        $��
txbVerMas1��5D   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��Ver Mas��6l   $	��Top=�6{   $��9(�6�   ���	#FF3DA6B16�   �� 5E      -   5        $��txbSiguente1��5E   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��Siguiente Folio 1��6n   $	��Top=�6�   $��9(�6�   ���	#FF3DA6B16�   5F      �� 5G      $��4��6   .+�5H      �� -   5        $��	txbFolio2��5H   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��FOLIOS 1-3000 ��6k   $	��Top=�6�   $��9(�6�   
���   �6�   �� 5I      -   5        $��
txbVerMas2��5I   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��Ver Mas��6l   $	��Top=�6{   $��9(�6�   ���	#FF3DA6B16�   �� 5J      -   5        $��txbSiguente2��5J   Z   $
��Auto��6    $
��Left=�6.   $��0,0,0,0q�6I   $��Siguiente Folio 1��6n   $	��Top=�6�   $��9(�6�   ���	#FF3DA6B16�   5K      5L      5M      o� 5N   
   -   5        $��MainMenu��5N   -   $��1��6   $
��Auto��6   
�������$	��Top=�6P   
������ .@�5O      m� -   5         m�Name$ MenuComprobantesDigitales��5O      $��Comprobantes Digitales��6:   $��13(�6Z   $y�	Collapsed=�6�    m� Icon 5P      �� 5Q      $9��3/wpfEFac;component/Images/Icons/certificatesCFD.ico��6   $��26��6Y   5S      m� 5T      -   5        $ MenuPuntoVenta��5T      $��Punto de Venta��6/   $��13(�6G    5U      �� 5V      $:��4/wpfEFac;component/Images/Icons/shoppingcart_128.png��6   $��26��6Z   5X      m� 5Y      -   5        $ MenuConfiguracion��5Y      $��Configuracion��62   $��13(�6I    5Z      �� 5[      $=��7/wpfEFac;component/Images/Icons/1280356387_Settings.ico��6   $��25��6]   5]      m� 5^      -   5        $ MenuReporte��5^      $��Reporte SAT��6,   $��13(�6A   $y�Visible=�6i    5_      �� 5`      $6��0/wpfEFac;component/Images/Icons/txtReportCFD.ico��6   $��25��6V   5b      5c       � 5e   
   -   5        $��ContentFrame��5e   O   $��1��6   $��1��6    $��5��6-   $��0,0,0,0q�6>     � Source$. (/Views/PuntoVenta/DefaultPuntoVenta.xaml?�5f      5g      �� 5i   
   -   5        $��grbComprobantesDigitales��5i   ^   $��2��6   $��Comprobantes Digitales��6    $��Stretch=�6@   $��Stretch=�6~   .��5j      � 	 5k      �� 5l      $��22 �6$   �� 5m      $��18 �6$   �� 5n      $��18 �6$   �� 5o      $��18 �6$   �� 5p      $��18 �6$   �� 5q      $��27 �6$   �� 5r      $��7* �6$   .+�5t      &    System.Windows.Controls.DataGrid  -   5        $��dtgComprobantesDigitales��5t   ,   $��6��6   $��2��6L      AutoGenerateColumns .     Columns 5u      0   *System.Windows.Controls.DataGridTextColumn  5v      ,   &System.Windows.Controls.DataGridColumn   Header$ 
Desripcion��6-      Width5   /System.Windows.Controls.DataGridLengthConverter$ 65 6a   1   +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *Descripcion+6a     5w      $	 Hoy��6-   $ * 6R    6:   �� *Hoy+6R     5x      $	 Mes��6-   $ * 6R    6:   �� *Mes+6R     5y      $	 Aut��6-   $ * 6R    6:   �� *Aut+6R     5z      $
 Pend��6-   $ * 6T    6;   �� *Pend+6T     5{      $	 Env��6-   $ * 6R    6:   �� *Env+6R     5|      $ Total��6-   $ * 6V    6<   �� *Total+6V   5~      5      5�        wpfEFac.Helpers.Accordion  5�   
   $
��Auto��6   $��3��6+   $��3��68   $��0,0,0,0q�6I   .+�5�      9� -   5        $��expVinculosInteres��5�   B   $��Vinculos de Interes��6   $
��Auto��64    9� 
IsExpanded . $
��Auto��6n   .��5�      �� -   5        $��grbVinculosInteres��5�   Z   $��Vinculos de Interes��6   $��Stretch=�6<   $	��Top=�6t   $
��Auto��6�   .��5�      � $
��Auto��6   $
��Auto��6-   	 5�      �� 5�   "   $��90 �60   �� 5�   "   $��32 �60   .+�5�      �� $��0��6)   .+�5�      �� -   5        $+��%txbVideoComprobantesFiscalesDigitales��5�   b   $
��Auto��6(   $
��Left=�66   $��0,0,0,0q�6Q   �� 6�   -   5        .�5�   �   �� $-��'Tutorial para solicitar Sellos y Folios��6�   $	��Top=�6�   $��12(�6  6  6   6,  �� 5�      -   5        $&�� txbComprobantesFiscalesDigitales��5�   b   $
��Auto��6(   $
��Left=�66   $��0,0,0,0q�6Q   �� 6�   -    5        .�5�   �   �� $!��SOLCEDI - Sol. certificados��6�   $	��Top=�6�   $��12(�6�   6  6  6  �� 5�      -!   5        $��txbComprobantesFiscales��5�   Q   $
��Auto��6(   $
��Left=�66   �� 6q   -"   5        .�5�   �   �� $ ��CertiSat WEB - Obtener.CER��6�   $��11(�6�   6�   6�   6�   �� 5�   "   -#   5        $��	txbSicofi��5�   U   $
��Auto��6,   $
��Left=�6:   �� 6g   -$   5        .�5�   �   �� $2��,Sicofi WEB - Sol. Folios/Envío Rep. Mensual��6�   $��11(�6�   6�   6�   6�   �� 5�   "   -%   5        $��txbValidador��5�   U   $
��Auto��6,   $
��Left=�6:   �� 6j   -&   5        .�5�   �   �� $
��Wrap=�6�   $��Validador SAT��6�   $��11(�6�   6�   6�   6�   5�      �� 5�      $��1��6)   $��32��66   $	��Top=�6B   .+�5�   "   �� -'   5        $��txbFirmaElectronica��5�   g   $
��Auto��6,   $
��Left=�6:   $��0,0,0,0q�6V   $'��!FIRMA ELECTRONICA AVANZADA (FIEL)��6�   $��12(�6�   6�   �� 5�   "   -(   5        $��txbFiel��5�   U   $
��Auto��6,   $
��Left=�6:   �� 6e   -)   5        .�5�   �   �� $��* FIEL��6�   $��11(�6�   6�   6�   6�   5�      5�      5�      5�      9� 5�      -*   5        $��expAgendaClientes��5�   A   $��Agenda de Clientes��6   $
��Auto��63    6Z   �� *
IsSelected+ �� Mode$ TwoWay=� �� RelativeSource �� *FindAncestor+ �� AncestorType" ��.��5�      � $��Stretch=�6   $��Stretch=�65   .+�5�      �� -+   5        $��grbAgendaClientes��5�   ;   $��Agenda de Clientes��6   $��Stretch=�6T   $��Stretch=�6r   .��5�      � 	 5�      �� 5�   "   $��* �60   �� 5�   "   $��* �60   .+�5�      �� $��0��6)   .+�5�   "   -  'System.Windows.Controls.AutoCompleteBox  -,   5          Name$ atcNom_Cliente��5�   @   $��25��6X      ValueMemberPath$ strNombreComercial��6d      
FilterMode$ Contains=�6�    � ToolTip$O IEscriba el nombre comercial y se despliega una lista de opciones posibles��6�      ItemTemplate 5�   &   �� 5�   *   .R�5�   .   �� .+�5�   2   �� $
��Bold"�6`   $��Center=�6r   $
��Left=�6�   ��6<   �� *strNombreComercial+6�   �� 5�   2   $��Stretch=�6T   $��Stretch=�6p   ��6<   �� *strRFC+6p   �� 5�   2   $(��"----------------------------------��6<   $��Center=�6f   $��Center=�6�   5�   /   5�   +   5�   #   5�      � 5�      $��1��6#   
 5�   "   �� 5�   &   $��61 �67   6E   �� 5�   &   $	��225 �67   6F   	 5�   "   �� 5�   &   $��* �64   6B   �� 5�   &   $��* �64   6B   �� 5�   &   $��* �64   6B   �� 5�   &   $��* �64   6B   �� 5�   &   $��* �64   6B   �� 5�   &   $��* �64   6B   .+�5�   "   �� --   5        $��txbClave��5�   ,   $��Clave:��6<   $��0��6J   $��0��6Z   $
��Left=�6g   $��12(�6�   �� 5�   "   -.   5        $��	txbNombre��5�   ,   $��Nombre:��6=   $��12(�6L   $��0��6Z   $��1��6j   $
��Left=�6w   �� 5�   "   -/   5        $��txbRFC2��5�   ,   $
��RFC:��6;   $��12(�6G   $��0��6U   $��2��6e   $
��Left=�6r   �� 5�   "   -0   5        $��txbGiro��5�   ,   $��Giro:��6;   $��12(�6H   $��0��6V   $��3��6f   $
��Left=�6s   �� 5�   "   -1   5        $��txbTelefono��5�   ,   $��	Telefono:��6?   $��12(�6P   $��0��6^   $��4��6n   $
��Left=�6{   �� 5�   "   -2   5        $��txbEmail��5�   ,   $��E-mail:��6<   $��12(�6K   $��0��6Y   $��5��6i   $
��Left=�6v   �� 5�   "   -3   5        $��txbClaveBaseDatos��5�   ,   $��12(�6E   $��1��6S   $��0��6c   $
��Left=�6p   �� 5�   "   -4   5        $��txbNombreBaseDatos��5�   ,   $��12(�6F   $��1��6T   $��1��6d   $
��Left=�6q   �� 5�   "   -5   5        $��txbRFCBaseDatos��5�   ,   $��12(�6C   $��1��6Q   $��2��6a   $
��Left=�6n   �� 5�   "   -6   5        $��txbGiroBaseDatos��5�   ,   $��12(�6D   $��1��6R   $��3��6b   $
��Left=�6o   �� 5�   "   -7   5        $��txbTelefonoBaseDatos��5�   ,   $��12(�6H   $��1��6V   $��4��6f   $
��Left=�6s   �� 5�   "   -8   5        $��txbEmailBaseDatos��5�   ,   $��12(�6E   $��1��6S   $��5��6c   $
��Left=�6p   5�      5�      5�      5�      5�      5�      5�      5�      