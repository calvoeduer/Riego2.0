   M S B A M L   `   `   `  ����  SistemaDeRiegoAutomatico)    #SistemaDeRiegoAutomatico.MainWindow   5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Panel De Control��5   	   $��394.212��6"   $��602.448��63    � 
ResizeMode$ NoResize=�6C    � WindowStartupLocation$ CenterScreen=�6Y    � Icon$ Resources/ecologismo2.png��6~   .��5      � .+�5	   
   o� $
��Left=�6   $��24��6*   $	��Top=�66   $	��596��6N   .@�5
      m� -   5         m�Name$ 
menuInicio��5
      $��Inicio��6+   m� 5      -   5        $ menuConfiguracion��5      $��Configuración��62   .@�5      m� -   5        $ menuAutomatico��5      $��Automático��63   $	��151��6G   6S   m� 5      -   5        $ menuProgramado��5      $��
Programado��63   $	��151��6G   6S   5      m� 5      -   5        $ menuEstadisticas��5      $��Estadísticas��61   6G   m� 5      -   5        $ 	menuSalir��5      $��Salir��6*   69   5      �� 5   
   $�� ��6   $
��Left=�6   $��
385,41,0,0q�68   $	��Top=�6L   $��79��6d   $	��186��6p   .��5      � $��
0,0,-2,-12q�6   ��5      �� 5       �� ImageSource$ Resources/green.jpg��6!    j� Stretch$ UniformToFill=�6D   6^   .+�5      �� $��Hora:��6   $
��Left=�6(   $	��Top=�6C   $��13(�6[   $��8,0,0,0q�6i   �� 5      -   5         ��Name$ lblHora��5      $��-- : -- : --��6)   $
��Left=�6@   $	��Top=�6[   $��13(�6s   $��58,0,0,0q�6�   �� 5      $��Fecha:��6   $
��Left=�6)   $	��Top=�6D   $��13(�6\   $��8,26,0,0q�6j   �� 5      -   5        $ lblFecha��5      $��-- / -- / --��6*   $
��Left=�6A   $	��Top=�6\   $��13(�6t   $��	58,26,0,0q�6�   5      5      �� 5    
   $"��Variables de automatización��6   $
��Left=�68   $��385,136,0,0q�6S   $	��Top=�6h   $��88��6�   $	��186��6�   .��5!      � $
��Left=�6   $	��176��6.   $	��104��6:   .+�5"      � $��	8,9,10,10q�6   ��5#      �� 5$      $ Resources/green.jpg��6%   $ UniformToFill=�6H   6b   .+�5'      �� $��Temperatura:��6   $
��Left=�63   $	��Top=�6N   $��13(�6f   �� 5(      -	   5        $ lblTemperatura��5(      $��--��64   $
��Left=�6A   $	��Top=�6\   $��13(�6t   $��90,0,0,0q�6�   $
��Bold"�6�   �� 5)      $��Humedad:��6   $
��Left=�6/   $	��Top=�6J   $��13(�6b   $��0,26,0,0q�6p   �� 5*      -
   5        $ 
lblHumedad��5*      $��--��60   $
��Left=�6=   $	��Top=�6X   $��13(�6p   $��	90,26,0,0q�6~   $
��Bold"�6�   �� 5+      $	��°C��6   $
��Left=�6)   $	��Top=�6D   $��13(�6\   $��124,0,-10,0q�6j   �� 5,      $��--��6   $
��Left=�6)   $	��Top=�6D   $��13(�6\   $��125,26,-8,0q�6j    J� RenderTransformOrigin$ 0.783,1.926&�6   5.      50      52      �� 53   
   $��Modo de Funcionamiento��6   $
��Left=�63   $��385,266,0,0q�6N   $	��Top=�6c   $��72��6{   $	��186��6�   .��54      � $��
0,0,-2,-12q�6   ��55      �� 56      $ Resources/green.jpg��6!   $ UniformToFill=�6D   6^   .+�59      	� -   5        	 	�Name$	 rbtnAutomatico��59      $��Automático��66   $
��Left=�6K   $��	10,10,0,0q�6f   $	��Top=�6y   $��13(�6�   
 d� 	IsChecked$

 TrueY�6�   6�   	� 5:      -   5        $	 rbtnProgramado��5:      $��
Programado��66   $
��Left=�6K   $��	10,31,0,0q�6f   $	��Top=�6y   $��13(�6�   6�   5;      5<      5@      5C      