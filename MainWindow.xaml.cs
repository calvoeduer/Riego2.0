﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;
using System.Windows.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace SistemaDeRiegoAutomatico
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<ConfiguracionProgramado> listaProgramadoRiego = new List<ConfiguracionProgramado>();
        public static List<ConfiguracionProgramado> listaProgramadoIluminacion = new List<ConfiguracionProgramado>();

        SerialPort puerto = new SerialPort("COM1", 9600, Parity.None, 8);
        DispatcherTimer tiempo = new DispatcherTimer();                       // TIMER DE TIEMPO HORA Y FECHA DEL SISTEMA.
        Chart figura = new Chart();
        private string datosRecibidos = "";
        long temperatura = 0;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                DBRiegoAutomatizado.DBConectar();
                
            }
            catch (Exception) { MessageBox.Show("NO SE PUDO CONECTAR A LA BASE DE DATOS", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
            DBRiegoAutomatizado.listaProgramadoRiego();
           
       

            /* --- CONFIGURACIÓN DE TIMERS --- */
            tiempo.Interval = TimeSpan.FromSeconds(1);  /* --- CADA 1s --- */
            tiempo.Tick += new EventHandler(tiempo_Tick);
            tiempo.Start();
        }

        void tiempo_Tick(object sender, EventArgs e)
        {
            string horaActual;
            horaActual = DateTime.Now.ToString("HH:mm:ss");
            lblHora.Content = DateTime.Now.ToString("hh:mm:ss tt");
            lblFecha.Content = DateTime.Now.ToString("ddd dd/MMM/yyyy");

            if (puerto.IsOpen)
                puerto.Write("T");  // PETICIÓN DE TEMPERATURA.

            if (rbtnAutomatico.IsChecked == true)  //MODO AUTOMÁTICO
            {
                if (temperatura > 30)
                    puerto.Write("0");
            }
            else                                   //MODO PROGRAMADO
            {
                ConfiguracionProgramado configA = MainWindow.listaProgramadoRiego.Find(x => x.HActivar == horaActual);
                if (configA != null)
                {
                    MessageBox.Show("A");
                    //puerto.Write("0");  //PETICIÓN DE ACTIVAR BOMBA
                }
                    
                ConfiguracionProgramado configD = MainWindow.listaProgramadoRiego.Find(x => x.HDesactivar == horaActual);
                if (configD != null)
                {
                    MessageBox.Show("D");
                    //puerto.Write("1");  //PETICIÓN DE DESACTIVAR BOMBA
                }
            }
            
        }

        delegate void ActualizaDatos();
        void puerto_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                datosRecibidos = puerto.ReadLine();
                Dispatcher.Invoke(new ActualizaDatos(actualiza));
            }
            catch (Exception) { MessageBox.Show("Error Al Recibir Datos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        void actualiza()
        {
            temperatura = Convert.ToInt64(datosRecibidos);
            lblTemperatura.Content = temperatura.ToString();
            //long humedad = Convert.ToInt64(datosRecibidos);
            //long luminosidad = Convert.ToInt64(datosRecibidos);
        }

        private void menuSalir_Click(object sender, RoutedEventArgs e)
        {
            puerto.Close();
            Close();
        }

        private void menuAutomatico_Click(object sender, RoutedEventArgs e)
        {
            (new wAutomatico()).Show();
        }

        private void menuProgramado_Click(object sender, RoutedEventArgs e)
        {
            (new wProgramado()).Show();
        }

        private void menuEstadisticas_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbtnAutomatico_Click(object sender, RoutedEventArgs e)
        {
                MessageBoxResult result = MessageBox.Show("¿Cambiar Al Modo Automático?", "", MessageBoxButton.OKCancel, MessageBoxImage.None);
                if (result == MessageBoxResult.Cancel)
                {
                    rbtnProgramado.IsChecked = true;
                }
        }

        private void rbtnProgramado_Click(object sender, RoutedEventArgs e)
        {
                MessageBoxResult result = MessageBox.Show("¿Cambiar Al Modo Programado?", "", MessageBoxButton.OKCancel, MessageBoxImage.None);
                if (result == MessageBoxResult.Cancel)
                {
                    rbtnAutomatico.IsChecked = true;
                }
        }
    }
}
