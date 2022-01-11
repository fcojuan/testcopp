using Rinku.Models;
using Rinku.Repository;
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
/// muestra la ayuda de empleados
/// </summary>
namespace Rinku.Presentacion
{
    public partial class AyudaEmp : Form
    {
        private string m_Cod;
        private readonly dRepository<Empleadoc> gRepo;
        public string MyProperty
        {
            //regresa el valor del codigo de empleado seleccionado en el grid
            get
            {
                return this.m_Cod;
            }
        }
        public AyudaEmp(string opc)
        {
            InitializeComponent();
            gRepo=new dRepository<Empleadoc>();
            CargarGrid(opc);
        }

        private void AyudaEmp_Load(object sender, EventArgs e)
        {
        }

        //-------FUNCIONES
        private void CargarGrid(string lopc)
        {
            SqlConnection dataConnection = new SqlConnection(gRepo.GetConnection()); //Llama a la coneccion

            SqlCommand cmd = new SqlCommand("c_spEmpleado", dataConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Opc", SqlDbType.VarChar, 10).Value = "6";
            cmd.Parameters.Add("@Filtro", SqlDbType.VarChar, 10).Value = lopc;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            bindingSource.DataSource = dt;
            dataGridView.DataSource = bindingSource;

            formatearGrid();


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
                //if (i > 1 && i < 9)
                //{
                //    dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                //}
            }
            //dataGridView.Columns[9].Visible = false;
            //dataGridView.Columns[11].Visible = false;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            var bd = (BindingSource)dataGridView.DataSource;
            var dt = (DataTable)bd.DataSource;
            dt.DefaultView.RowFilter = string.Format("Nombre like '%{0}%'", txtsearch.Text.Trim().Replace("'", "''"));
            dataGridView.Refresh();
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell Indcell = dataGridView.CurrentCell;
            m_Cod = dataGridView.Rows[Indcell.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }
    }
}
