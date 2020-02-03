using Dapper;
using Model;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace PracticaGestionJugadores
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly string connectionString = "SERVER=localhost;" +
            "DATABASE=liga;UID=root;PASSWORD=interfaces";
        //private List<Jugador> jugadores;
        private MySqlConnection connection;
        private MySqlCommand query;
        private DataTable dataTable;
        public MainWindow()
        {
            InitializeComponent();
            connection = new MySqlConnection(connectionString);
            DateTime time = DateTime.Today;
            String format = time.ToString("yyyy/MM/dd HH:mm:ss");
            MySqlDateTime fechaDt = new MySqlDateTime();
           
            query = new MySqlCommand();
            //InsertarJugador(131, "'Manolo'", "'Perez'", "'Alero'", format ,1200, 1, 2);
            //borrarJugador(131);
            MostrarJugadores();
        }

        public void MostrarJugadores()
        {
            query = new MySqlCommand("SELECT * from jugador", connection);
            connection.Open();
            dataTable = new DataTable();
            dataTable.Load(query.ExecuteReader());
            connection.Close();
            dgListaJugadores.DataContext = dataTable;
        }

        public void InsertarJugador(int id, string nombre, string apellido, string posicion
            , string fechaDt,int salario, int equipo, float altura)
        {
            query = new MySqlCommand("INSERT INTO jugador VALUES("+id  + "," + nombre
                + "," + apellido + "," + posicion + ",'" + fechaDt + "'," +  salario + "," + equipo +
                "," + altura +");",connection);
          
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        public void borrarJugador(int idJugador)
        {
            query = new MySqlCommand("DELETE FROM jugador WHERE ID = " + idJugador, connection);
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

        public void updateJugador(int idJugador, string nombre, string apellido, string posicion
            , string fechaDt, int salario, int equipo, float altura)
        {
            query = new MySqlCommand("UPDATE  jugador SET(NOMBRE=" + nombre
                + ",APELLIDO=" + apellido + ",POSICION=" + posicion + ",FECHA_ALTA'" + fechaDt + "',SALARIO=" + salario + ",EQUIPO=" + equipo +
                ",ALTURA=" + altura + " WHERE ID = " + idJugador + ");", connection);

            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }

       /* public void getJugadores()
        {
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.
                ConnectionStrings["PracticaGestionJugadores.Properties.Settings.ligaConnectionString"]
                .ConnectionString))
            {
               db.Query<Jugador>
                    ("select * from jugador");
            }
        }*/
    }
}
