using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorBDA
{
    public partial class Nuevo_Nombre : Form
    {
        public Nuevo_Nombre()
        {
            InitializeComponent();
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string dameNombre()
        {
            return txtBoxNombre.Text;
        }
    }
}
