using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rinku.Utileria
{
    public class MensageCaja
    {
        public void MensagesCaja(string mensajetxt, string Tipo)
        {
            switch (Tipo)
            {
                case "Information":
                    MessageBox.Show(mensajetxt, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                case "Warning":
                    MessageBox.Show(mensajetxt, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case "Error":
                    MessageBox.Show(mensajetxt, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case "Success":
                    MessageBox.Show(mensajetxt, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
            }
        }
    }
}
