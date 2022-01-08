using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinku.Models
{
    public class Empleadoc
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string IdRol { get; set; }
        public string Rol{ get; set; }
        public string IdTipo { get; set; }
        public string Tipo { get; set; }
        public decimal SueldoHora { get; set; }
        public int Jornada { get; set; }
        public string Situacion { get; set; }
    }
}
