﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rinku.Models
{
    public class Movimientoc
    {
        public int ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Cargador { get; set; }
        public string NomCargador { get; set; }
        public string Entregas { get; set; }
        public string Horas { get; set; }
        public string Fecha { get; set; }
        public string Situacion { get; set; }
    }
}
