using Rinku.Utileria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rinku.Presentacion
{
    public partial class Nomina : Form
    {
        MensageCaja mensaje = new MensageCaja();
        public Nomina()
        {
            InitializeComponent();
        }

        private void Nomina_Load(object sender, EventArgs e)
        {
            txtFechaIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaIni.SelectAll();
        }

        private void txtFechaIni_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DateTime temp;
                    if (!DateTime.TryParse(txtFechaIni.Text.Trim(), out temp))
                    {
                        mensaje.MensagesCaja("FECHA ES INCORRECTA", "Information");
                    }
                    else
                    {
                        //convierte el text en fecha
                        DateTime ldate = Convert.ToDateTime(txtFechaIni.Text);
                        //obtiene el primer dia del mes
                        DateTime oPrimerDiaDelMes = new DateTime(ldate.Year, ldate.Month, 1);
                        //obtiene el ultimo dia del mes
                        txtFechaFin.Text = oPrimerDiaDelMes.AddMonths(1).AddDays(-1).ToString("dd/MM/yyyy");
                    }
                    break;
                default:
                    //JuegoTeclas(e);
                    break;
            }
            //Evitar el pitido
            e.Handled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                mensaje.MensagesCaja("ejecutar", "Information");
            }
        }

        //-------------FUNCIONES
        private bool Validar()
        {
            bool regreso = true;
            DateTime temp;
            if (!DateTime.TryParse(txtFechaIni.Text.Trim(), out temp) && regreso)
            {
                regreso = false;
                mensaje.MensagesCaja("FECHA INICIAL ES INCORRECTA", "Information");
            }
            if (!DateTime.TryParse(txtFechaFin.Text.Trim(), out temp) && regreso)
            {
                regreso = false;
                mensaje.MensagesCaja("FECHA FINAL ES INCORRECTA", "Information");
            }

            return regreso;
        }
    }
}
