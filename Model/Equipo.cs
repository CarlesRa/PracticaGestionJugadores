using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Equipo
    {
        private int idEquipo;
        private string nombre;

        public Equipo(int idEquipo, string nombre)
        {
            this.idEquipo = idEquipo;
            this.nombre = nombre;
        }

        public int IdEquipo
        {
            get
            {
                return idEquipo;
            }
            set
            {
                idEquipo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
    }
}
