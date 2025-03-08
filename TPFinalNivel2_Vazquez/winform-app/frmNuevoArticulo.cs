﻿using dominio;
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

                // Precargamos los datos para el form de actualización
                if (articulo != null) {
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
                if (articulo == null){
                    articulo = new Articulo();
                }

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.ImagenUrl = txtImagen.Text;
                articulo.IdCategoria = (Categoria)cmbCategoria.SelectedItem;
                articulo.IdMarca = (Marca)cmbMarca.SelectedItem;
                articulo.Precio = Math.Round(decimal.Parse(txtPrecio.Text), 2);

                if (decimal.TryParse(txtPrecio.Text, out decimal precio))
                    articulo.Precio = Math.Round(precio, 2);
                else
                    MessageBox.Show("Ingrese un precio válido.");


                if (articulo.Id != 0)
                {
                    articuloNegocio.modificarArticulo(articulo);
                    MessageBox.Show(articulo.Nombre + " modificado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (validarCampos())
                    {
                        MessageBox.Show("SOLO NUMEROS");
                    }
                    else
                    {
                        // Los ComboBox se inicializan sin selección
                        cmbCategoria.SelectedIndex = -1;
                        cmbMarca.SelectedIndex = -1;
                        validarCampos();

                        articuloNegocio.agregarArticulo(articulo);
                        MessageBox.Show(articulo.Nombre + " agregado exitosamente", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
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
        private bool validarCamposNull(string param)
        {
            if (string.IsNullOrEmpty(param))
            {
                lblMjeError.Visible = true;
                lblMjeError.Text = "No puede haber campos vacíos";
                return true;
            }

            lblMjeError.Visible = false;
            return false;
        }


        // Validar campo numérico
        private bool validarIsNumber(string param)
        {
            return param.All(char.IsDigit);
        }


        // Validar el filtro avanzado
        private bool validarCampos()
        {
            // Campo PRECIO
            if (txtPrecio.Text != null)
            {
                if (validarCamposNull(txtPrecio.Text))
                {
                    return false;
                }

                if (!validarIsNumber(txtPrecio.Text))
                {
                    lblMjeError.Visible = true;
                    lblMjeError.Text = "Deben ser sólo números";
                    txtPrecio.Clear();
                    return false;
                }
            }
            return true;
        }
    }
}
