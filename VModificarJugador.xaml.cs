using Model;
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
using System.Windows.Shapes;
using Dapper;
using DbManager;
using MySql.Data.MySqlClient;

namespace PracticaGestionJugadores
{
    /// <summary>
    /// Lógica de interacción para VModificarJugador.xaml
    /// </summary>
    public partial class VModificarJugador : Window
    {
        private DbManagment manager;
        private string positionName;
        private DateTime fechaAlta;
        public VModificarJugador()
        {
            InitializeComponent();
            manager = DbManagment.Instance;
        }

        public List<Jugador> ReadAll()
        {
            using (IDbConnection db = new SqlConnection(ConfigurationManager.
                ConnectionStrings["PracticaGestionJugadores.Properties.Settings.ligaConnectionString"]
                .ConnectionString))
            {
                return db.Query<Jugador>("SELECT * FROM jugador").ToList();
            }
        }

        //Listener Boton Localizar
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(tbIdJugador.Text != "")
            {
                try
                {
                    obtenerDatosJugador(int.Parse(tbIdJugador.Text));
                }
                catch (FormatException)
                {
                    MessageBoxResult result = MessageBox.Show("El campo id Jugador solo acepta números",
                   "Error", MessageBoxButton.OK);
                    tbIdJugador.Text = "";
                }
                

            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Introduce el ID del jugador\n para localizarlo",
                    "Error" ,MessageBoxButton.OK);
            }
        }



        public void obtenerDatosJugador(int idJugador)
        {
           
            int positionInComboBox = -1;

            MySqlCommand query = new MySqlCommand("SELECT * FROM jugador WHERE ID = " + idJugador, manager.Connection());
            manager.Connection().Open();
            var reader = query.ExecuteReader();
            while (reader.Read())
            {
                tbNombre.Text = reader["NOMBRE"].ToString();
                tbApellido.Text = reader["APELLIDO"].ToString();
                //Averiguo que posición muestro en el combo box de posiciones
                positionName = reader["POSICION"].ToString();
                positionInComboBox = findPositionInComboBox(positionName);
                cbPosiciones.SelectedIndex = positionInComboBox;
                fechaAlta = (DateTime)reader["FECHA_ALTA"];
                calendario.SelectedDate = fechaAlta;
                tbSalario.Text = reader["SALARIO"].ToString();
                cbEquipos.SelectedIndex = int.Parse(reader["EQUIPO"].ToString())-1;
                tbAltura.Text = reader["ALTURA"].ToString();   
            }
            if(tbNombre.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("Ningun Jugador con ese ID",
                    "Error", MessageBoxButton.OK);
            }
            manager.Connection().Close();
        }

        //Boton Modificar
        private void modificarClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(tbIdJugador.Text);
            string nombreJug = tbNombre.Text;
            string apellidos = tbApellido.Text;
            string posicion = findPositionByPos(cbPosiciones.SelectedIndex);
            DateTime fecha = calendario.SelectedDate.Value;
            string fechaFormat = fecha.ToString("yyyy/MM/dd HH:mm:ss");
            int salario = int.Parse(tbSalario.Text);
            string nomEquipo = cbEquipos.SelectedIndex.ToString();
            int equipo = cbEquipos.SelectedIndex + 1;
            float altura = float.Parse(tbAltura.Text);
            manager.updateJugador(id, nombreJug, apellidos, posicion, fechaFormat, salario, equipo, altura);
            MessageBoxResult result = MessageBox.Show("Jugador modificado\ncon éxito!!",
                    "Enhorabuena!!", MessageBoxButton.OK);

        }
        public int findPositionInComboBox(string posicion)
        {
            switch (posicion)
            {
                case "Escolta": 
                    {
                        return 0;
                    }
                case "Pivot":
                    {
                        return 1;
                    }
                case "Alero":
                    {
                        return 2;
                    }
                case "Ala_Pivot": 
                    {
                        return 3;
                    }
                case "Base":
                    {
                        return 4;
                    }
                default: return -1;
            }
        }

       
        public string findPositionByPos(int positionInComboBox)
        {
            switch (positionInComboBox)
            {
                case 0:
                    {
                        return "Escolta";
                    }
                case 1 :
                    
                    {
                        return "Pivot";
                    }
                case 2:
                    {
                        return "Alero";
                    }
                case 3:
                    {
                        return "Ala_Pivot";
                    }
                case 4:
                    {
                        return "Base";
                    }
                default: return "Sin Posicion";
            }
            


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }


        /*
         * int.Parse(tbIdJugador.ToString()), tbNombre.ToString(), tbApellido.Text,
                positionName, calendario.ToString(), int.Parse(tbSalario.ToString()),
                int.Parse(cbEquipos.SelectedItem.ToString()), float.Parse(tbAltura.ToString())

         manager.updateJugador(1111, "jlaf", "kljad", "Alero", fechaAlta.ToString("yyyy/MM/dd HH:mm:ss"),
                1, 1, 1);
         */
    }
}
