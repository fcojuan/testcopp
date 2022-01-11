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
/// Catalgo de rol y bonos por autorizar y algunos con importes aplicar a los empleados
/// </summary>
namespace Rinku.Presentacion
{
    public partial class cRol : Form
    {
        private readonly dRepository<Rolc> gRepo;

        MensageCaja mensaje = new MensageCaja();
        //Este array contiene los parametros que ocupa el sp para poder realizar los procesos,insertar buscar modificar
        string[] lParamAdd = { "@Opc", "@Id", "@Nombre", "@Bono", "@BonoPaq" };

        string[] lParam = { };
        string[] lVar = { };
        public cRol()
        {
            InitializeComponent();

            gRepo = new dRepository<Rolc>();
        }

        private void cRol_Load(object sender, EventArgs e)
        {
            LimpiezaTxt();
            _=ActualizarGrid();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            LimpiezaTxt();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    txtNombre.Text = txtNombre.Text.ToUpper();
                    SendKeys.Send("{TAB}");
                    //Evitar el pitido
                    e.Handled = true;
                    break;
                default:
                    //JuegoTeclas(e);
                    break;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //valida los datos y si es correcto llena el array para gusrdar los datos
            if (Validar())
            {
                lVar = LlenarAray();
                //Llama a el procedmiento, se manda los array con los parametro del sp y los valores capturados en el form
                int ReturnTask = await Task.Run(() => gRepo.BDAddAsync("c_spRol", lParamAdd, lVar));

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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult d;
            d = MessageBox.Show("Desea " + btnBorrar.Text.Trim() + " El Registro?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (d == DialogResult.Yes)
            {
                lParam = new string[] { "@Opc", "@ID" };
                lVar = new string[] { "3", txtID.Text.Trim() };
                //llama al sp para realizar el proceso de borrado
                int valor = gRepo.BDAccionReg("c_spRol", lParam, lVar);
                if (valor == 1)
                {
                    _ = ActualizarGrid();
                    mensaje.MensagesCaja("EL DATOS FUE AFECTADO", "Success");

                    LimpiezaTxt();
                }
                else
                {
                    mensaje.MensagesCaja("NO SE AFECTO EL DATO", "Error");
                }
            }
        }

        private void nBono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo acepta numeros 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as NumericUpDown).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
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
        //----------------------------------------
        //--------------------FUNCIONES NECESARIAS
        string[] LlenarAray()
        {
            string[] lcampos = {
            "1",txtID.Text.Trim(),txtNombre.Text.ToUpper().Trim(),nBono.Value.ToString(),checkBPaq.Checked==true?"1":"0"
            };
            return lcampos;
        }

        private async Task ActualizarGrid()
        {
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

            //------------agrega columnas al datatable
            DataTable dt = new DataTable();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Rolc));

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            //------------llama al procedimiento
            lParam = new string[] { "@Opc" };
            lVar = new string[] { "4" };

            var Lista = await Task.Run(() => gRepo.BDListaDatos("c_spRol", lParam, lVar));
            //List<Empleadoc> lista1 = (List<Empleadoc>)Lista;

            //-----------vacia la lista en el datatable
            object[] values = new object[props.Count];
            foreach (Rolc item in Lista.Where(x => x.Situacion != "B"))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            //-----------asigna el datatable al biding para asignarlo al dataview
            bindingSourceRol.DataMember = "";
            bindingSourceRol.DataSource = null;

            bindingSourceRol.DataSource = dt;

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
            dataGridView.DataSource = bindingSourceRol;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].ReadOnly = true;
            }
            //dataGridView.Columns[0].Visible = false;
            //dataGridView.Columns[3].Visible = false;
            //dataGridView.Columns[5].Visible = false;
        }
        private bool Validar()
        {
            bool regreso = true;
            if (txtNombre.Text.Length <= 0 && regreso)
            {
                regreso = false;
                mensaje.MensagesCaja("SE NECESITA NOMBRE DE ROL", "Information");
            }
            if (txtNombre.Text.Length > 80 && regreso)
            {
                regreso = false;
                mensaje.MensagesCaja("NOMBRE DE ROL ES MUY LARGO", "Information");
            }

            return regreso;
        }

        private void CargarDatos(int Renglon)
        {
            //Muestra los datos en pantalla
            btnBorrar.Enabled = true;
            txtID.Text = dataGridView.Rows[Renglon].Cells[0].Value.ToString();
            txtNombre.Text = dataGridView.Rows[Renglon].Cells[1].Value.ToString();
            nBono.Value = Convert.ToDecimal(dataGridView.Rows[Renglon].Cells[2].Value.ToString());
            checkBPaq.Checked = dataGridView.Rows[Renglon].Cells[3].Value.ToString()=="SI"?true:false;
            btnBorrar.Text = dataGridView.Rows[Renglon].Cells[4].Value.ToString() == "Borrado" ? "Activar" : "Borrar";
        }
        private void LimpiezaTxt()
        {
            txtID.Visible = false;
            txtID.Text = "0";
            txtNombre.Text = "";
            nBono.Value = 0;
            checkBPaq.Checked = true;
            txtID.Enabled = false;
            btnBorrar.Enabled = false;

            txtNombre.Select();

        }

    }
}
