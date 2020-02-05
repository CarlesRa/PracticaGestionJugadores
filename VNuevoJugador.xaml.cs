using DbManager;
using MySql.Data.MySqlClient;
using System;
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
using System.Windows.Shapes;

namespace PracticaGestionJugadores
{
    /// <summary>
    /// Lógica de interacción para VNuevoJugador.xaml
    /// </summary>
    public partial class VNuevoJugador : Window
    {
        DbManagment manager = DbManagment.Instance;
        public VNuevoJugador()
        {
            InitializeComponent();
            dpDate.SelectedDate = DateTime.Today;
        }

        private void btAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (tbIdJugador.Text != "" && tbNombre.Text != "" && tbApellido.Text != "" && cbPosicion.SelectedIndex > -1 
                && cbEquipo.SelectedIndex > -1 && tbSalario.Text != "" && tbAltura.Text != "")
            {
                int idEquipo = cbEquipo.SelectedIndex - 1;
                
                try
                {
                    manager.InsertarJugador(int.Parse(tbIdJugador.Text), tbNombre.Text, tbApellido.Text,
                        cbPosicion.Text, dpDate.SelectedDate.Value,int.Parse(tbSalario.Text), idEquipo,
                        float.Parse(tbAltura.Text));
                    MessageBoxResult result = MessageBox.Show("Jugador insertado correctamente!!\nDesea insertar otro jugador?",
                        "Enhorabuena!", MessageBoxButton.YesNo);
                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            //algo farem
                            break;
                        case MessageBoxResult.No:
                            Close();
                            break;
                    }
                    tbNombre.Text = "";
                    tbAltura.Text = "";
                    tbApellido.Text = "";
                    tbSalario.Text = "";
                    tbIdJugador.Text = "";
                    cbEquipo.SelectedIndex = -1;
                    cbPosicion.SelectedIndex = -1;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Los campos Altura y Salario\nDeben ser números...", "Error!", MessageBoxButton.OK);
                }
                           
            }
            else
            {
                MessageBox.Show("Los campos no pueden estar vacios", "Error!",MessageBoxButton.OK);
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
