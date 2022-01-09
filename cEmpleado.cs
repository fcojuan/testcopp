using Rinku.Models;
using Rinku.Repository;
using Rinku.Utileria;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// contiene toda la indformacion requerida del trabajo para poder realizar su funcion de entrega de paquetes
/// asi como el sueldo y jornada de trabajo
/// </summary>
namespace Rinku
{
    public partial class cEmpleado : Form
    {
        private readonly dRepository<Empleadoc> gRepo;
        private readonly dRepository<Rolc> RepoRol;
        private readonly dRepository<Tipoc> RepoTipo;

        MensageCaja mensaje = new MensageCaja();
        //Este array contiene los parametros que ocupa el sp para poder realizar los procesos,insertar buscar modificar
        string[] lParamAdd = { "@Opc", "@Id","@Codigo","@Nombre","@IdRol","@IdTipo", "@Sueldo","@Jornada" };

        string[] lParam = { };
        string[] lVar = { };


        public cEmpleado()
        {
            InitializeComponent();

            gRepo = new dRepository<Empleadoc>();
            RepoRol = new dRepository<Rolc>();
            RepoTipo = new dRepository<Tipoc>();
        }

        private void cEmpleado_Load(object sender, EventArgs e)
        {
            LimpiezaTxt();

            _ = GetCombo(cBoxRol, "4");
            _ = GetCombo(cBoxTipo, "4");
            LlenarHoras();
            _ = ActualizarGrid();
        }
        private void LimpiezaTxt()
        {
            txtID.Visible = false;
            txtID.Text = "0";
            txtCod.Text = "";
            txtNombre.Text = "";
            numSueldo.Value = 0;
            cBoxJornada.Text = "8";
            txtCod.Enabled = false;
            btnBorrar.Enabled = false;

            lParam = new string[] { "@Opc", "@Id" };
            lVar = new string[] { "5", "0" };
            txtCod.Text = gRepo.BuscarReg("c_spEmpleado", lParam, lVar);

            txtNombre.Select();

        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            LimpiezaTxt();
        }
        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int index = Convert.ToInt32(textbox.Tag);

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
        private async void button1_Click(object sender, EventArgs e)
        {
            //valida los datos y si es correcto llena el array para gusrdar los datos
            if (Validar())
            {
                lVar = LlenarAray();
                //Llama a el procedmiento, se manda los array con los parametro del sp y los valores capturados en el form
                int ReturnTask = await Task.Run(() => gRepo.BDAddAsync("c_spEmpleado", lParamAdd, lVar));

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
            lParam = new string[] { "@Opc", "@ID" };
            lVar = new string[] { "3", txtID.Text.Trim() };
            //llama al sp para realizar el proceso de borrado
            int valor = gRepo.BDAccionReg("c_spEmpleado", lParam, lVar);
            if (valor == 1)
            {
                _ = ActualizarGrid();
                mensaje.MensagesCaja("EL DATOS FUE BORRADO", "Success");

                LimpiezaTxt();
            }
            else
            {
                mensaje.MensagesCaja("NO SE BORRO EL DATO", "Error");
            }
        }
        private void numSueldo_KeyPress(object sender, KeyPressEventArgs e)
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
        private void numSueldo_KeyDown(object sender, KeyEventArgs e)
        {
            NumericUpDown textbox = (NumericUpDown)sender;
            int index = Convert.ToInt32(textbox.Tag);

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SendKeys.Send("{TAB}");
                    //Evitar el pitido
                    e.Handled = true;
                    break;
                default:
                    //JuegoTeclas(e);
                    break;
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
        private async Task GetCombo(ComboBox NomBox, string opc)
        {
            lParam = new string[] { "@Opc" };
            lVar = new string[] { "4" };

            var Lista = new object();
            NomBox.DisplayMember = "Nombre";
            NomBox.ValueMember = "ID";

            switch (NomBox.Name)
            {
                case "cBoxRol":
                    Lista = await RepoRol.BDListaCombo("c_spRol", lParam, lVar);
                    List<Rolc> lista1 = (List<Rolc>)Lista;
                    NomBox.DataSource = lista1;
                    break;
                case "cBoxTipo":
                    Lista = await RepoTipo.BDListaCombo("c_spTipo", lParam, lVar);
                    List<Tipoc> lista2 = (List<Tipoc>)Lista;
                    NomBox.DataSource = lista2;
                    break;
            }

        }
        string[] LlenarAray()
        {
            string[] lcampos = {
            "1",txtID.Text.Trim(),txtCod.Text.Trim(),txtNombre.Text.ToUpper().Trim(),cBoxRol.SelectedValue.ToString(),
                cBoxTipo.SelectedValue.ToString(),numSueldo.Value.ToString(),cBoxJornada.Text.Trim()
            };
            return lcampos;
        }

        private async Task  ActualizarGrid()
        {
            DataGridViewCellStyle cellStyle=new DataGridViewCellStyle();

            //------------agrega columnas al datatable
            DataTable dt = new DataTable();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(Empleadoc));

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                dt.Columns.Add(prop.Name, prop.PropertyType);
            }
            //------------llama al procedimiento
            lParam = new string[] { "@Opc" };
            lVar = new string[] { "4" };

            var Lista = await Task.Run(() => gRepo.BDListaDatos("c_spEmpleado", lParam, lVar));
            List<Empleadoc> lista1 = (List<Empleadoc>)Lista;

            //-----------vacia la lista en el datatable
            object[] values = new object[props.Count];
            foreach (Empleadoc item in lista1.Where(x => x.Situacion != "B"))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            //-----------asigna el datatable al biding para asignarlo al dataview
            bindingSourceEmp.DataMember = "";
            bindingSourceEmp.DataSource = null;

            bindingSourceEmp.DataSource = dt;

            dataGridView.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.SelectionMode= DataGridViewSelectionMode.FullRowSelect;
            //---------------Poner Encabezado en negritas
            cellStyle.Font = new Font(dataGridView.Font.Name, dataGridView.Font.Size, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle = cellStyle;
            //---------------Poner Color a los Renglones
            dataGridView.RowsDefaultCellStyle.BackColor = Color.White;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.Wheat;
            dataGridView.DataSource = bindingSourceEmp;

            for(int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].ReadOnly=true;
            }
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[5].Visible = false;

            lblTotal.Text = "Empleado Totales: " + lista1.Count.ToString();
        }
        private bool Validar()
        {
            bool regreso = true;
            if (txtNombre.Text.Length <= 0 && regreso)
            {
                regreso = false;
                mensaje.MensagesCaja("SE NECESITA NOMBRE DE EMPLEADO", "Information");
            }
            if (txtNombre.Text.Length > 150 && regreso)
            {
                regreso = false;
                mensaje.MensagesCaja("NOMBRE DE EMPLEADO ES MUY LARGO", "Information");
            }

            return regreso;
        }

        private void CargarDatos(int Renglon)
        {
            //Muestra los datos en pantalla
            btnBorrar.Enabled = true;
            txtID.Text = dataGridView.Rows[Renglon].Cells[0].Value.ToString();
            txtCod.Text = dataGridView.Rows[Renglon].Cells[1].Value.ToString();
            txtNombre.Text = dataGridView.Rows[Renglon].Cells[2].Value.ToString();
            cBoxRol.SelectedValue = Convert.ToInt32(dataGridView.Rows[Renglon].Cells[3].Value.ToString());
            cBoxTipo.SelectedValue = Convert.ToInt32(dataGridView.Rows[Renglon].Cells[5].Value.ToString());
        }

        private void LlenarHoras()
        {
            for(int i = 1; i <= 12; i++)
            {
                cBoxJornada.Items.Add(i);
            }
            cBoxJornada.Text = "8";
        }



        //private void JuegoTeclas(KeyEventArgs Tecla)
        //{
        //    switch (Tecla.KeyCode)
        //    {
        //        case Keys.Up:
        //            if 
        //            txtNombre.Text = txtNombre.Text.ToUpper();
        //            SendKeys.Send("{TAB}");
        //            //Evitar el pitido
        //            e.Handled = true;
        //            break;
        //        default:
        //            JuegoTeclas(e);
        //            break;
        //    }
        //}

    }
}
