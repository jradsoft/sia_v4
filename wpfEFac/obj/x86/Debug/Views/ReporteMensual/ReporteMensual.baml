   M S B A M L   `   `   `  ����  wpfEFac1    +wpfEFac.Views.ReporteMensual.ReporteMensual   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          N� Title$  ReporteMensual��5      .��5
      �  � RowDefinitions 5   
   �� 5      $	��60* �6   �� 5      $
��100* �6   �� 5      $
��630* �6   .+�5   
   �� -   5        $��grbReporteMensual��5   ;   $��1��6   $��1��6    $�� ��61   .��5      �  5      �� 5      $	��60* �6$   �� 5      $
��100* �6$    � ColumnDefinitions 5      �� 5      $
��145* �6'   �� 5      $
��145* �6'   �� 5      $
��145* �6'   �� 5      $
��145* �6'   .+�5      	� -   5         	�Name$ 
repMensual��5   .   $��0��6   $y�	Collapsed=�6B   .��6Y   Reporte Mensual6j   	� 5       -   5        $ 	repVentas��5    .   $��1��6    d� 	IsChecked$
 TrueY�6A   .��6R   Reporte Ventas Mensual6j   �� 5!      -   5         ��Name$ chkEnviarMail��5!      $��2��62   $ FalseY�6B   .��6T   Enviar e-Mail6c   �� 5"      -   5        $��txbFechaReporte��5"   =   $��1��6   $��1��6)   $��Fecha de reporte ��6T   $��Center=�6m   $��Right=�6�   (  "System.Windows.Controls.DatePicker  5#      -   5        $��dtpFechaReporte��5#   :   $��1��6   $��1��6*   $��Center=�6Q   6l   �� 5$      -   5        $��
bttGenerar��5$   T   $��1��6   $��Generar��6&   $��2��68   $��23��6H   $��Center=�6f   $��75��6�   6�   5%      5&      5'      5(      