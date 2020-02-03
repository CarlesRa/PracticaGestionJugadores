using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Posiciones
    {
        ESCOLTA, PIVOT, ALERO, ALA_PIVOT, BASE
    }

    public class Jugador
    {
        private int ID { get; set; }
        private string NOMBRE { get; set; }
        private string APELLIDO { get; set; }
        private Posiciones POSICION { get; set; }
        private DateTime FECHA_ALTA { get; set; }
        private float SALARIO { get; set; }
        private int EQUIPO { get; set; }
        private float ALTURA { get; set; }

        /*public Jugador(int id, string nombre, string apellido, Posiciones posicion,
            DateTime fechaAlta, float salario, int idEquipo, float altura)
        {
            this.ID = id;
            this.NOMBRE = nombre;
            this.APELLIDO = apellido;
            this.POSICION = posicion;
            this.FECHA_ALTA = fechaAlta;
            this.SALARIO = salario;
            this.EQUIPO = idEquipo;
            this.ALTURA = altura;
        }*/

 
    }
}
