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
using System.Globalization;

namespace winform_app
{
    public partial class frmNuevoArticulo : Form
    {
        private Articulo articulo = null;
        ArticuloNegocio articuloNegocio = new ArticuloNegocio();

        // Constructor para el alta
        public frmNuevoArticulo()
        {
            InitializeComponent();
        }

        // Constructor para la modificación
        public frmNuevoArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar artículo";
            lblTitulo.Text = "Modificar artículo";
        }


        private void frmNuevoArticulo_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcaNegocio marcaNegocio = new MarcaNegocio();

            try
            {
                cmbCategoria.DataSource = categoriaNegocio.listar();
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Descripcion";

                cmbMarca.DataSource = marcaNegocio.listar();
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "Descripcion";

                // Los ComboBox se inicializan sin selección
                cmbCategoria.SelectedIndex = -1;
                cmbMarca.SelectedIndex = -1;

                // Precargar los datos para el form de actualización
                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;

                    txtImagen.Text = articulo.ImagenUrl;
                    cargarImagen(articulo.ImagenUrl);

                    cmbCategoria.SelectedValue = articulo.IdCategoria.Id;
                    cmbMarca.SelectedValue = articulo.IdMarca.Id;
                    txtPrecio.Text = articulo.Precio.ToString();
                }

            }
            catch (Exception ex) { MessageBox.Show("Error al cargar los ComboBox", ex.Message); }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarCampos()) return;

                if (articulo == null)
                {
                    articulo = new Articulo();
                }

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.ImagenUrl = txtImagen.Text;
                articulo.IdCategoria = (Categoria)cmbCategoria.SelectedItem;
                articulo.IdMarca = (Marca)cmbMarca.SelectedItem;

                // Asegurarse que sean 2 decimales (se ingresen por el usuario o no) con punto o coma
                string precioTxt = txtPrecio.Text.Trim();
                precioTxt = precioTxt.Replace(',', '.');
                if (decimal.TryParse(precioTxt, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal precio))
                {
                    if (precio > 0)
                    {
                        precio = Math.Round(precio, 2);
                        articulo.Precio = precio;
                        txtPrecio.Text = precio % 1 == 0 ? precio.ToString("0") : precio.ToString("0.00");
                    }
                    else
                    {
                        MessageBox.Show("El precio debe ser mayor a cero", "Ingreso inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPrecio.Clear();
                        txtPrecio.Focus();
                        return;
                    }
                }
                else
                {
                    lblMjeError.Visible = true;
                    lblMjeError.Text = "El campo precio debe contener sólo números";
                    txtPrecio.Clear();
                    txtPrecio.Focus();
                    return;
                }


                // Modificar o agregar artículo
                if (articulo.Id != 0)
                {
                    if (!validarCampos()) return;
                    articuloNegocio.modificarArticulo(articulo);
                    MessageBox.Show(articulo.Nombre + " modificado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmbCategoria.SelectedIndex = -1;
                    cmbMarca.SelectedIndex = -1;
                    
                    articuloNegocio.agregarArticulo(articulo);
                    MessageBox.Show(articulo.Nombre + " agregado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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



        // ///////////////////////////////////////////////////////////////////////////////////////
        // ///////////////////////////////////////////////////////////////////////////////////////
        // //////////////////////////////////// VALIDACIONES /////////////////////////////////////

        // Validar campos nulos o vacíos
        private bool validarCampos()
        {
            TextBox[] textBox = { txtCodigo, txtNombre, txtDescripcion, txtImagen, txtPrecio };
            ComboBox[] comboBox = { cmbCategoria, cmbMarca };

            foreach (TextBox txt in textBox)
            {
                if (string.IsNullOrEmpty(txt.Text))
                {
                    lblMjeError.Visible = true;
                    lblMjeError.Text = "Los campos marcados (*) son obligatorios";
                    txt.Focus();
                    return false;
                }
            }

            foreach (ComboBox cb in comboBox)
            {
                if (cb.SelectedIndex == -1)
                {
                    lblMjeError.Visible = true;
                    lblMjeError.Text = "Seleccione la categoría y marca del artículo";
                    cb.Focus();
                    return false;
                }
            }
            lblMjeError.Visible = false;
            return true;
        }
    }
}
