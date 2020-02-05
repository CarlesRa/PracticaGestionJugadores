using DbManager;
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
    /// Lógica de interacción para VBorrarJugador.xaml
    /// </summary>
    public partial class VBorrarJugador : Window
    {
        private DbManagment manager = DbManagment.Instance;
        public VBorrarJugador()
        {
            InitializeComponent();
        }

        private void btLocalizar_Click(object sender, RoutedEventArgs e)
        {
            if (tbIdJugador.Text != "")
            {
                try
                {
                    tbNombre.Text = manager.obtenerNombre(int.Parse(tbIdJugador.Text));
                    if(tbNombre.Text == " ")
                    {
                        MessageBoxResult result = MessageBox.Show("Ningun Jugador con ese ID",
                        "Error", MessageBoxButton.OK);
                    }
                }
                catch (FormatException)
                {
                    MessageBoxResult result = MessageBox.Show("El campo id Jugador solo acepta números",
                                     "Error", MessageBoxButton.OK);
                }
                
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("El campo id Jugador no puede estar vacio",
                                 "Error", MessageBoxButton.OK);
            }
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            
            if(tbIdJugador.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("El campo id Jugador no puede estar vacio",
                                  "Error", MessageBoxButton.OK);
            }
            else
            {
                try
                {
                    manager.borrarJugador(int.Parse(tbIdJugador.Text));
                    MessageBoxResult result = MessageBox.Show("Jugador Eliminado con èxito!!",
                                      "Enhorabuena!!", MessageBoxButton.OK);
                }
                catch (FormatException)
                {
                    MessageBoxResult result = MessageBox.Show("El campo id Jugador solo acepta números",
                                      "Error", MessageBoxButton.OK);
                }
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
