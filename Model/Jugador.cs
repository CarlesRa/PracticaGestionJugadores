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
        private readonly int ID;
        private string NOMBRE;
        private string APELLIDO;
        private Posiciones POSICION;
        private DateTime FECHA_ALTA;
        private float SALARIO;
        private int EQUIPO;
        private float ALTURA;

        public Jugador(int id, string nombre, string apellido, Posiciones posicion,
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
        }

        public string Nombre
        {
            get { return NOMBRE;  }
            set { NOMBRE = value; }
        }

        public string Apellido
        {
            get { return APELLIDO; }
            set { APELLIDO = value; }
        }

        public Posiciones Posicion
        {
            get { return POSICION; }
            set { POSICION = value; }
        }

        public DateTime FechaAlta
        {
            get { return FECHA_ALTA; }
            set { FECHA_ALTA = value; }
        }

        public float Salario
        {
            get { return SALARIO; }
            set { SALARIO = value; }
        }

        public int IdEquipo
        {
            get { return EQUIPO; }
            set { EQUIPO = value; }
        }

        public float Altura
        {
            get { return ALTURA; }
            set { ALTURA = value; }
        }
    }
}
