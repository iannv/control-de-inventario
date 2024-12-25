using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_app
{
    public partial class frmVerDetalleArticulo : Form
    {
        public frmVerDetalleArticulo()
        {
            InitializeComponent();
        }

        private void VerDetalleArticulo_Load(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Form listado = new frmListadoArticulos();
            listado.Show();
            this.Hide();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }

}
