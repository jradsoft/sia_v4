   M S B A M L   `   `   `  ����B  >wpfEFac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:wpfEFac.ViewModelwpfEFac.ViewModel  5   	       wpfEFac.Views.EMail.Email   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .vmclr-namespace:wpfEFac.ViewModel     5   	     � Title$  Email��5   	   $	��500��6   $	��600��6$    � Icon$2 ,/wpfEFac;component/Images/Icons/emailCFD.ico��5   	    � 	Resources 5      &    wpfEFac.ViewModel.EmailViewModel   EmailViewModel��%   &	          5	   
   6   5
      .��5      � -   5         �Name$ 
LayoutRoot��5       � DataContext# [  6   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FF6693D1��6    � Offset$ 1Q�61   � 5      $ White��6   $ 0.098Q�6-   � 5      $ 	#FFEBF0F7��6   $ 0.607Q�61   5      	 � ColumnDefinitions	 5   
   �� 5      $	��90* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $	��70* �6   �� 5      $
��100* �6   �� 5      $
��100* �6   
 � RowDefinitions
 5   
   �� 5      $	��32* �6   �� 5      $	��32* �6   �� 5       $	��32* �6   �� 5!      $	��34* �6   �� 5"      $
��294* �6   �� 5#      $	��37* �6   .+�5&   
   �� $��Right=�6   $��Center=�60   $y�	Collapsed=�6K   De:6g   �� 5(   
   $��1��6   $��4��6$   $��Center=�68    � ToolTip$E ?Direccion de correo con la que se enviara el correo electronico��5)      $��5q�5*      ��6   ��  �� Path$ 	FromEmail��� 5,   
   $��Para:��6   $��1��6!   $��Right=�6.   $��Center=�6J   $` ZPresione para elegir de las cuentas de correos de clientes almacenadas en la base de datos��5-      �� 5/   
   -   5         ��Name$ txtEmailCliente��50   B   $��1��5/      $��1��6"   $��5��6/   $��Center=�6C   $��5q�50      $ �� HorizontalScrollBarVisibility$
 Auto=�6   $A ;Ingrese cuentas de correo electronico separadas por una ';'��51      �� 53   
   $��2��6   $��Right=�6!   $��Center=�6=   	Asunto:6b   �� 55   
   -   5        $ 	txtAsunto��56   B   $��1��55      $��2��6"   $��5��6/   $��Center=�6C   $��5q�56      $
 Auto=�6   $. (Escriba el asunto del correo electronico��57      ��6E   �� $ Subject� �� UpdateSourceTrigger$ PropertyChanged=��� 59   
   $��3��6   $��Right=�6   $��Center=�6:   $��5q�6U   $ Archivos adjuntos��5:      ._�5;      ��  �� Orientation$ 
Horizontal=�6   .+�5<      �� 
Adjuntos6&   �� 5=      $��Center=�6   $
��Fill=�65   $/��)/wpfEFac;component/Images/attachement.ico��6D   5>      5?      �� 5A   
   $ 
Horizontal=�6   $��1��6.   $��3��6>   $��6��6K   .+�5B      �� -   5        $��stpXmlAttachment��5B      $ 
Horizontal=�61   $ Archivo XML a ser enviado��5C      .+�5D      �� $6��0/wpfEFac;component/Images/Icons/doc_xml_icon.png��6   $��1��6R   $��3��6b   �� 5E      $��Center=�6A   ��6   �� $ XMLAttachement�6A   5F      �� 5H      $ 
Horizontal=�6   $ Archivo PDF a ser enviado��5I      .+�5J      �� $1��+/wpfEFac;component/Images/Icons/pdfIcon.png��6   $��1��6M   $��3��6]   �� 5K      $��Center=�6A   ��6   �� $ PDFAttachement�6A   5L      5M      �� 5O   
   -   5        $ 
txtMensaje��5O      $��4��6&   $��7��63   $��5q�6G    �� TextWrapping$
 Wrap=�6R    �� 
AcceptsTab .  �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5P   9   $�� ��5Q      $/ )Escriba el mensaje del correo electronico��5R      �� 5T   
   $��Enviar��6   $��5��6"   $��4��6/   $��Center=�6?   $y�	Collapsed=�6Z   $��5q�5U      $a [Presione para enviar el correo electronico a las direcciones de correo electronico escritas��6   ��5V      �� $ SendEmailCommand��� 5X   
   -   5        $��Cancelar��5X      $��5��6$   $��6��61   $��Center=�6A   $��5q�5Y      $> 8Presione para cancelar y no enviar el correo electronico��6   6_   �� 5Z   
   -   5        $��cmdEnviarEmail��5Z   �   $��Enviar Email��6   $��5��6(   $��2��68   $��5��6L   $��23��6Y   $
��Left=�6e   $��5q�6�   $	��Top=�6�   $��75��6�   6�   5[      5\      