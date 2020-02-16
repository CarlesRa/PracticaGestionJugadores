using Dapper;
using DbManager;
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
    /// Lógica de interacción para VNewPlayer.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        private DbManagment manager;
        private ligaDataSet dsTodaLaLiga;
        public MainWindow()
        {
            InitializeComponent();
            manager = DbManagment.Instance;                   
            //InsertarJugador(131, "'Manolo'", "'Perez'", "'Alero'", format ,1200, 1, 2);
            //borrarJugador(131);
            dgListaJugadores.DataContext = manager.MostrarJugadores();
        }

        private void miNuevoJugador_Click(object sender, RoutedEventArgs e)
        {

            VNuevoJugador vNuevoJugador = new VNuevoJugador();
            vNuevoJugador.Owner = this;
            vNuevoJugador.HorizontalAlignment = this.HorizontalAlignment;
            vNuevoJugador.VerticalAlignment = this.VerticalAlignment;
            vNuevoJugador.ShowDialog();
        }

        private void miModificarJugador_Click(object sender, RoutedEventArgs e)
        {
            VModificarJugador vModificar = new VModificarJugador();
            vModificar.Owner = this;
            vModificar.ShowDialog();
        }

        private void miBorrarJugador_Click(object sender, RoutedEventArgs e)
        {
            VBorrarJugador vBorrarJugador = new VBorrarJugador();
            vBorrarJugador.Owner = this;
            vBorrarJugador.ShowDialog();
        }

        private void btActualizar_Click(object sender, RoutedEventArgs e)
        {
            dgListaJugadores.DataContext = manager.MostrarJugadores();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void miVerInforme_Click(object sender, RoutedEventArgs e)
        {
            /* MessageBoxResult result = MessageBox.Show("ONLY FOR PREMIUM USERS!!",
                      "Error", MessageBoxButton.OK);*/
            informeDatos.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource = new Microsoft.Reporting.WinForms.ReportDataSource();
            dsTodaLaLiga = new ligaDataSet();
            dsTodaLaLiga.BeginInit();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dsTodaLaLiga.jugador; 
            informeDatos.LocalReport.DataSources.Add(reportDataSource);
            informeDatos.LocalReport.ReportPath = "InformeJugadores.rdlc";
            dsTodaLaLiga.EndInit();

            try
            {
                String conexion = ConfigurationManager.
                 ConnectionStrings["PracticaGestionJugadores.Properties.Settings.ligaConnectionString"].ConnectionString;
                MySql.Data.MySqlClient.MySqlDataAdapter JugadorTableAdapter = new MySql.Data.MySqlClient.
                    MySqlDataAdapter("Select * from jugador", conexion);
                dsTodaLaLiga.Clear();
                JugadorTableAdapter.Fill(dsTodaLaLiga.jugador);
                informeDatos.RefreshReport();
            }
            catch (Exception exception) { Console.Error.WriteLine(exception); }
        }
    }
}
