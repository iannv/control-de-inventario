using dominio;
using negocio;
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
        Articulo articulo;
        AccesoDatos datos = new AccesoDatos();
        public frmVerDetalleArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }


        private void VerDetalleArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                if (articulo != null) {
                    lblTitulo.Text = articulo.Nombre.ToUpper();
                    lblCodigoA.Text = articulo.Codigo;
                    lblNombreA.Text = articulo.Nombre;
                    lblDescripcionA.Text = articulo.Descripcion;
                    lblPrecioA.Text = articulo.Precio.ToString("C");
                    lblMarcaA.Text = articulo.IdMarca.Descripcion;
                    lblCategoriaA.Text = articulo.IdCategoria.Descripcion;

                    try
                    {
                        if (articulo.ImagenUrl != null)
                        {
                            picArticulo.Load(articulo.ImagenUrl);
                        }
                        else
                        {
                            picArticulo.Image = Properties.Resources.no_product_image;
                        }
                    }
                    catch (Exception ex)
                    {
                        picArticulo.Image = Properties.Resources.no_product_image;
                    }
                }
            }
            catch (Exception ex) { throw ex; }
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
