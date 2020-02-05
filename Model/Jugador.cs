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
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public Posiciones POSICION { get; set; }
        public DateTime FECHA_ALTA { get; set; }
        public float SALARIO { get; set; }
        public int EQUIPO { get; set; }
        public float ALTURA { get; set; }

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
