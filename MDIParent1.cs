using Rinku.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rinku
{
    public partial class MDIMenu : Form
    {
        public MDIMenu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Movimientos childForm = new Movimientos();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            cEmpleado childForm = new cEmpleado();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nomina childForm = new Nomina();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            //Cierra los formularios hijos en caso de que alguno este abierto
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            //cierra la aplicacion
            this.Close();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracion childForm = new Configuracion();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cRol childForm = new cRol();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cTipo childForm = new cTipo();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
