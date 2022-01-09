using Rinku.Models;
using Rinku.Repository;
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
/// <summary>
/// ES DONDE CONFIGURAMOS LOS BONOS Y COMISIONES QUE LE SISTEMA VA A CALCULAR A LOS TRABAJADORES
/// ASI COMO LOS DESCUENTO DE ISR
/// </summary>

namespace Rinku.Presentacion
{
    public partial class Configuracion : Form
    {
        private readonly dRepository<Configuracionc> gRepo;
        MensageCaja mensaje = new MensageCaja();
        //Este array contiene los parametros que ocupa el sp para poder realizar los procesos,insertar buscar modificar
        string[] lParamAdd = { "@Opc", "@AComiJL", "@ComiJL", "@ABonoCh", "@BonoCh", "@ABonoCarga", "@BonoCarga", "@ISR", "@ISRSobrePorc", "@ISRSobrePasa" };

        string[] lParam = { };
        string[] lVar = { };
        public Configuracion()
        {
            InitializeComponent();

            gRepo = new dRepository<Configuracionc>();

        }
        private void Configuracion_Load(object sender, EventArgs e)
        {
            //busca los datos de configuracion
            MostrarDatos();

            nComiEnt.Enabled = false;
            nBonoHrs.Enabled = false;
            nComiCarga.Enabled = false;
        }
        private void nComiEnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo acepta numeros 
            if (ChecarNumero(sender, e))
            {
                e.Handled = true;
            }
        }

        private void nBonoHrs_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo acepta numeros 
            if (ChecarNumero(sender, e))
            {
                e.Handled = true;
            }
        }

        private void nComiCarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo acepta numeros 
            if (ChecarNumero(sender, e))
            {
                e.Handled = true;
            }
        }

        private void nISR_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo acepta numeros 
            if (ChecarNumero(sender, e))
            {
                e.Handled = true;
            }
        }
        private void nSueldoSobrepasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo acepta numeros 
            if (ChecarNumero(sender, e))
            {
                e.Handled = true;
            }
        }
        private void nISRSobrapasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo acepta numeros 
            if (ChecarNumero(sender, e))
            {
                e.Handled = true;
            }
        }

        //--------------------------
        private bool ChecarNumero(object obj,KeyPressEventArgs Tecla)
        {
            bool valor = false;
            //valida si son numeros 
            if (!char.IsControl(Tecla.KeyChar) && !char.IsDigit(Tecla.KeyChar) && (Tecla.KeyChar != '.'))
            {
                valor = true;
            }
            if ((Tecla.KeyChar == '.') && ((obj as NumericUpDown).Text.IndexOf('.') > -1))
            {
                valor = true;
            }

            return valor;
        }

        private void checkComEntrega_CheckedChanged(object sender, EventArgs e)
        {
            nComiEnt.Enabled = checkComEntrega.Checked == true ? true : false;
        }

        private void checkBonoHrs_CheckedChanged(object sender, EventArgs e)
        {
            nBonoHrs.Enabled = checkBonoHrs.Checked == true ? true : false;
        }

        private void checkComiCarga_CheckedChanged(object sender, EventArgs e)
        {
            nComiCarga.Enabled = checkComiCarga.Checked == true ? true : false;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            //Llenas el array con los campos necesarios para guardar
            lVar = LlenarAray();
            //Llama a el procedmiento, se manda los array con los parametro del sp y los valores capturados en el form
            int ReturnTask = await Task.Run(() => gRepo.BDAddAsync("c_spConfiguracion", lParamAdd, lVar));

            if (ReturnTask == 1)
            {
                mensaje.MensagesCaja("DATOS GUARDADOS", "Success");
            }
            else
            {
                mensaje.MensagesCaja("NO SE GUARDARON LOS DATOS", "Error");
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //---------------------------FUNCIONES


        string[] LlenarAray()
        {
            string[] lcampos = {
            "1",checkComEntrega.Checked==true?"1":"0",nComiEnt.Value.ToString(),
            checkBonoHrs.Checked==true?"1":"0",nBonoHrs.Value.ToString(),
            checkComiCarga.Checked==true?"1":"0",nComiCarga.Value.ToString(),
            nISR.Value.ToString(),nISRSobrapasa.Value.ToString(),nSueldoSobrepasa.Value.ToString()
            };
            return lcampos;
        }
        private async void MostrarDatos()
        {
            //------------llama al procedimiento
            lParam = new string[] { "@Opc", };
            lVar = new string[] { "2", };
            var Lista = await gRepo.BDListaDatos("c_spConfiguracion", lParam, lVar);
            if(Lista.Count == 0)
            {
                nComiEnt.Enabled = false;
                nBonoHrs.Enabled = false;
                nComiCarga.Enabled = false;
            }
            else
            {
                checkComEntrega.Checked = Lista[0].AComiJL;
                nComiEnt.Value = Convert.ToDecimal(Lista[0].ComiJL);
                checkBonoHrs.Checked = Lista[0].ABonoCh;
                nBonoHrs.Value = Convert.ToDecimal(Lista[0].BonoCh);
                checkComiCarga.Checked = Lista[0].ABonoCarga;
                nComiCarga.Value = Convert.ToDecimal(Lista[0].BonoCarga);

                nISR.Value = Convert.ToDecimal(Lista[0].ISR);
                nISRSobrapasa.Value = Convert.ToDecimal(Lista[0].ISRSobrePorc);
                nSueldoSobrepasa.Value = Convert.ToDecimal(Lista[0].ISRSobrePasa);
            }


        }



    }
}
