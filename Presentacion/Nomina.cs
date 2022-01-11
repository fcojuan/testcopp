using Rinku.Models;
using Rinku.Repository;
using Rinku.Utileria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Realiza el calculo de la nomina en base a dos fechas
/// obtiene los datos de los movimientos y en base a los empleado sy configuracion 
/// aplica bonos o no
/// </summary>

namespace Rinku.Presentacion
{
    public partial class Nomina : Form
    {
        private readonly dRepository<Movimientoc> gRepo;
        MensageCaja mensaje = new MensageCaja();

        string[] lParam = { };
        string[] lVar = { };
        public Nomina()
        {
            InitializeComponent();
            gRepo=new dRepository<Movimientoc>();
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
            if (Validar())//Valida las fechas
            {
                LlenarGrid();
                mensaje.MensagesCaja("Nomina Calculada", "Information");
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

        private void txtFechaIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//solo acpeta numero
            {
                e.Handled = true;
            }

            if (e.KeyChar != ((char)(Keys.Back)))
            {
                if(txtFechaIni.Text.Length == 2 || txtFechaIni.Text.Length == 5) //agrega la / a la fecha
                {
                    txtFechaIni.Text = txtFechaIni.Text + "/";
                    txtFechaIni.SelectionStart = txtFechaIni.Text.Length;
                }
            }
        }

        private void txtFechaFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )//solo acpeta numero
            {
                e.Handled = true;
            }

            if (e.KeyChar != ((char)(Keys.Back)))
            {
                if (txtFechaFin.Text.Length == 2 || txtFechaFin.Text.Length == 5) //agrega la / a la fecha
                {
                    txtFechaFin.Text = txtFechaFin.Text + "/";
                    txtFechaFin.SelectionStart = txtFechaFin.Text.Length;
                }
            }
        }
        //-------FUNCIONES
        private void LlenarGrid()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            SqlConnection dataConnection = new SqlConnection(gRepo.GetConnection()); //Llama a la coneccion

            SqlCommand cmd = new SqlCommand("c_spCalculoNomina", dataConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FechaIni", SqlDbType.VarChar, 10).Value = Convert.ToDateTime(txtFechaIni.Text).ToString("yyyy/MM/dd");
            cmd.Parameters.Add("@FechaFin", SqlDbType.VarChar, 10).Value = Convert.ToDateTime(txtFechaFin.Text).ToString("yyyy/MM/dd");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bindingSource.DataSource = dt;
            dataGridView.DataSource = bindingSource;

            formatearGrid();

            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        private void formatearGrid()
        {
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //---------------Poner Encabezado en negritas
            cellStyle.Font = new Font(dataGridView.Font.Name, dataGridView.Font.Size, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle = cellStyle;
            //---------------Poner Color a los Renglones
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Wheat;
            dataGridView.DataSource = bindingSource;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].ReadOnly = true;
                if(i>1 && i < 9)
                {
                    dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            dataGridView.Columns[9].Visible = false;
            dataGridView.Columns[11].Visible = false;
        }

    }
}
