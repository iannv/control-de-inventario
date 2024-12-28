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
using negocio;

namespace winform_app
{
    public partial class frmNuevoArticulo : Form
    {
        Articulo articulo = new Articulo();
        ArticuloNegocio articuloNegocio = new ArticuloNegocio();

        public frmNuevoArticulo()
        {
            InitializeComponent();
        }

        private void frmNuevoArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                cmbCategoria.DataSource = categoriaNegocio.listar();
                cmbMarca.DataSource = marcaNegocio.listar();

                cmbCategoria.SelectedIndex = -1;
                cmbMarca.SelectedIndex = -1;
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.ImagenUrl = txtImagen.Text;
                articulo.IdCategoria = (Categoria)cmbCategoria.SelectedItem;
                articulo.IdMarca = (Marca)cmbMarca.SelectedItem;
                articulo.Precio = decimal.Parse(txtPrecio.Text);

                articuloNegocio.agregarArticulo(articulo);
                MessageBox.Show(articulo.Nombre + " agregado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // Cargar la imagen de cada articulo en el PictureBox
        public void cargarImagen(string img)
        {
            try
            {
                picArticulo.Load(img);
            }

            catch (Exception ex)
            {
                picArticulo.Load("https://i.ibb.co/rvgQKmz/no-product-image.jpg");
            }
        }

        // Se carga la url de la imagen en el PictureBox al salir del campo de texto
        private void txtImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagen.Text);   
        }


    }
}
