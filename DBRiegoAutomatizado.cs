﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeRiegoAutomatico
{
    public class DBRiegoAutomatizado
    {
        
        static SqlConnection conexion;
        public static void DBConectar()
        {
            
            conexion = new SqlConnection("Data Source=LAPTOP-OF-EDUER\\SQLEXPRESS;Initial Catalog=Riego;Integrated Security=True");
            conexion.Open();
        }

        public static void listaProgramadoRiego()
        {
            string consulta = "SELECT Id, HActivar, HDesactivar FROM ProgramadoRiego";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                MainWindow.listaProgramadoRiego.Add(new ConfiguracionProgramado(reader.GetInt32(0), reader.GetString(1), reader.GetString(1)));
            }
            reader.Close();
        }

        

        public static void GuardarConfiguracionRiego()
        {
            string query = string.Format("DELETE FROM ProgramadoRiego");
            SqlCommand comando1 = new SqlCommand(query, conexion);
            comando1.ExecuteNonQuery();

            int cont = 0;
            foreach (ConfiguracionProgramado aux in MainWindow.listaProgramadoRiego)
            {
                query = string.Format("INSERT INTO ProgramadoRiego (Id, HActivar, HDesactivar) VALUES ({0}, '{1}', '{2}')", cont, aux.HActivar, aux.HDesactivar);
                SqlCommand comando2 = new SqlCommand(query, conexion);
                comando2.ExecuteNonQuery();
                cont++;
            }
        }

      
        

    }
}
