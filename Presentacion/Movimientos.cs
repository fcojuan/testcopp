using Rinku.Models;
using Rinku.Repository;
using Rinku.Utileria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rinku.Presentacion
{
    public partial class Movimientos : Form
    {
        private readonly dRepository<Movimientoc> gRepo;
        private readonly dRepository<Empleadoc> eRepo;
        MensageCaja mensaje = new MensageCaja();

        string[] lParamAdd = { "@Opc", "@Id", "@Codigo", "@Fecha", "@Entrega", "@Horas" };

        string[] lParam = { };
        string[] lVar = { };
        public Movimientos()
        {
            InitializeComponent();

            eRepo = new dRepository<Empleadoc>();
            gRepo = new dRepository<Movimientoc>();
        }

        private async void Movimientos_Load(object sender, EventArgs e)
        {
            LimpiezaTxt();
            await ActualizarGrid();
        }
        private async void txtCod_KeyDown(object sender, KeyEventArgs e)
        {
            //NumericUpDown textbox = (NumericUpDown)sender;
            //int index = Convert.ToInt32(textbox.Tag);

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtCod.Text= txtCod.Text.PadLeft(5,'0').Trim();

                    if (txtCod.Text != "00000")
                    {
                        if (await DatosEmpleado(txtCod.Text)==1)
                        {
                            //SendKeys.Send("{TAB}");
                        }
                    }
                    break;
                default:
                    //JuegoTeclas(e);
                    break;
            }
            //Evitar el pitido
            e.Handled = true;
        }
        private void checkCT_CheckedChanged(object sender, EventArgs e)
        {
            nHoras.Enabled = checkCT.Checked == true ? false : true;
            nHoras.Value = checkCT.Checked == true ? 8 : 1;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //valida los datos y si es correcto llena el array para gusrdar los datos
            if (Validar())
            {
                lVar = LlenarAray();
                //Llama a el procedmiento, se manda los array con los parametro del sp y los valores capturados en el form
                int ReturnTask = await Task.Run(() => gRepo.BDAddAsync("c_spMovimiento", lParamAdd, lVar));

                if (ReturnTask == 1)
                {
                    await ActualizarGrid();//muestra actualizado el grid
                    mensaje.MensagesCaja("DATOS GUARDADOS", "Success");

                    LimpiezaTxt();
                }
                else
                {
                    mensaje.MensagesCaja("NO SE GUARDARON LOS DATOS", "Error");
                }
            }
        }
        private async Task ActualizarGrid()
        {
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

            //------------agrega columnas al datatable
            DataTable dt = new DataTable();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Movimientoc));

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            //------------llama al procedimiento con la fecha actual  para traerse los datos con esa fecha
            lParam = new string[] { "@Opc","@Fecha" };
            lVar = new string[] { "4",DateTime.Now.ToString("yyyy-MM-dd") };

            var Lista = await Task.Run(() => gRepo.BDListaDatos("c_spMovimiento", lParam, lVar));
            //List<Empleadoc> lista1 = (List<Movimientoc>)Lista;

            //-----------vacia la lista en el datatable
            object[] values = new object[props.Count];
            foreach (Movimientoc item in Lista.Where(x => x.Situacion != "B"))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            //-----------asigna el datatable al biding para asignarlo al dataview
            bindingSourceMov.DataMember = "";
            bindingSourceMov.DataSource = null;

            bindingSourceMov.DataSource = dt;

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
            dataGridView.DataSource = bindingSourceMov;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].ReadOnly = true;
            }
            dataGridView.Columns[0].Visible = false;
            //dataGridView.Columns[5].Visible = false;
            dataGridView.Columns[6].Visible = false;
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].Visible = false;
            dataGridView.Columns[9].Visible = false;
            dataGridView.Columns[10].Visible = false;
        }
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            //controla el movieminto de las teclas en el grid y llama  la funcion para mostrar datos en pantalla
            int reng = 0;
            DataGridViewCell Indcell = dataGridView.CurrentCell;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    reng = Indcell.RowIndex > 0 ? Indcell.RowIndex - 1 : Indcell.RowIndex;
                    CargarDatos(reng);
                    break;
                case Keys.Down:
                    reng = Indcell.RowIndex < dataGridView.RowCount - 1 ? Indcell.RowIndex + 1 : Indcell.RowIndex;
                    CargarDatos(reng);
                    break;
            }
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell Indcell = dataGridView.CurrentCell;
            CargarDatos(Indcell.RowIndex);

        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            lParam = new string[] { "@Opc", "@ID" };
            lVar = new string[] { "3", lblID.Text.Trim() };
            //llama al sp para realizar el proceso de borrado
            int valor = gRepo.BDAccionReg("c_spMovimiento", lParam, lVar);
            if (valor == 1)
            {
                _ = ActualizarGrid();
                mensaje.MensagesCaja("EL REGISTRO SE ACTUALIZO", "Success");

                LimpiezaTxt();
            }
            else
            {
                mensaje.MensagesCaja("EL REGISTRO NO SE ACTUALIZO", "Error");
            }
        }

        //-------------------FUNCIONES NECESARIAS
        private void LimpiezaTxt()
        {
            lblID.Visible = false;
            lblID.Text = "0";
            txtCod.Text = "";
            lblNombre.Text = "";
            lblRol.Text = "";
            lblTipo.Text = "";
            txtFecha.Text = "";
            nEntrega.Value = 1;
            nHoras.Value = 1;
            checkCT.Checked = false;
            txtCod.Enabled = true;
            btnBorrar.Enabled = false;
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtCod.SelectAll();
        }
        private async Task<int> DatosEmpleado(string Cod)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            //------------llama al procedimiento
            lParam = new string[] { "@Opc", "@Codigo" };
            lVar = new string[] { "2", Cod };
            var Lista = await eRepo.BDListaDatos("c_spEmpleado", lParam, lVar);
            if (Lista.Count == 0)
            {
                mensaje.MensagesCaja("CODIGO DE EMPLEADO NO EXISTE", "Error");
            }
            else
            {
                txtCod.Enabled = false;
                txtCod.Text = Lista[0].Codigo;
                lblNombre.Text = Lista[0].Nombre.Trim();
                lblRol.Text = Lista[0].Rol.Trim();
                lblTipo.Text = Lista[0].Tipo.Trim();
                txtFecha.SelectAll();

            }
            this.Cursor = System.Windows.Forms.Cursors.Default;

            return 1;
        }
        private async void CargarDatos(int Renglon)
        {
            //Muestra los datos en pantalla
            btnBorrar.Enabled = true;
            lblID.Text = dataGridView.Rows[Renglon].Cells[0].Value.ToString();
            txtCod.Text = dataGridView.Rows[Renglon].Cells[1].Value.ToString();
            nEntrega.Value = Convert.ToInt32(dataGridView.Rows[Renglon].Cells[3].Value);
            nHoras.Value = Convert.ToInt32(dataGridView.Rows[Renglon].Cells[4].Value);
            checkCT.Checked = Convert.ToInt32(dataGridView.Rows[Renglon].Cells[4].Value) == 8 ? true : false;
            txtFecha.Text = dataGridView.Rows[Renglon].Cells[5].Value.ToString();
            btnBorrar.Text = dataGridView.Rows[Renglon].Cells[11].Value.ToString() == "Borrado" ? "Activar" : "Borrado";
            await DatosEmpleado(txtCod.Text);
        }
        private bool Validar()
        {
            bool regreso = true;
            DateTime temp;
            if (!DateTime.TryParse(txtFecha.Text.Trim(), out temp) && regreso)
            {
                regreso = false;
                mensaje.MensagesCaja("FECHA ES INCORRECTA", "Information");
            }
            if (txtCod.Text.Length <= 0 && regreso)
            {
                regreso = false;
                mensaje.MensagesCaja("ERROR EN CODIGO DE EMPLEADO", "Information");
            }

            return regreso;
        }
        string[] LlenarAray()
        {
            string[] lcampos = {
            "1",lblID.Text.Trim(),txtCod.Text.Trim(),Convert.ToDateTime(txtFecha.Text).ToString("yyyy-MM-dd"),nEntrega.Value.ToString(),nHoras.Value.ToString()
            };
            return lcampos;
        }


    }
}
