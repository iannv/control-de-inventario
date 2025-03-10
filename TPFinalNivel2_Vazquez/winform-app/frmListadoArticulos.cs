﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmListadoArticulos : Form
    {
        private List<Articulo> listaArticulo;

        public frmListadoArticulos()
        {
            InitializeComponent();

            // Iniciar los ComboBox cargados
            cmbCampo.Items.Add("Código");
            cmbCampo.Items.Add("Precio");
            cmbCampo.Items.Add("Nombre");
            cmbCampo.Items.Add("Categoría");
            cmbCampo.Items.Add("Marca");
        }

        private void frmListadoArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                cargarListado();
                cargarImagen(listaArticulo[0].ImagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }


        // Carga el listado en el DataGridView
        private void cargarListado()
        {
            ArticuloNegocio articulo = new ArticuloNegocio();

            try
            {
                listaArticulo = articulo.listar();
                dgvListadoArticulos.DataSource = listaArticulo;
                ocultarColumnas();

                //dgvListadoArticulos.Columns["Nombre"].Width = 250;
                dgvListadoArticulos.Columns["Descripcion"].Width = 280;
                dgvListadoArticulos.Columns["Editar"].Width = 70;
                dgvListadoArticulos.Columns["Eliminar"].Width = 70;
                dgvListadoArticulos.Columns["Ver"].Width = 70;

                dgvListadoArticulos.Columns["Editar"].DisplayIndex = 11;
                dgvListadoArticulos.Columns["Eliminar"].DisplayIndex = 11;
                dgvListadoArticulos.Columns["Ver"].DisplayIndex = 11;
            }
            catch (Exception ex) { throw ex; }
        }


        // Ocultar las columnas del DataGridView
        private void ocultarColumnas()
        {
            dgvListadoArticulos.Columns["Id"].Visible = false;
            dgvListadoArticulos.Columns["ImagenUrl"].Visible = false;
            dgvListadoArticulos.Columns["Precio"].Visible = false;
        }


        // Cargar la imagen de cada articulo en el PictureBox
        public void cargarImagen(string img)
        {
            try { 
                picArticulo.Load(img); 
            }
            
            catch (Exception ex) { 
                picArticulo.Load("https://i.ibb.co/rvgQKmz/no-product-image.jpg"); 
            }
        }

        private void dgvListadoArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo articuloSeleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;
            cargarImagen(articuloSeleccionado.ImagenUrl);
        }


        // Form para cargar un nuevo artículo
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Form nuevoArticulo = new frmNuevoArticulo();
            nuevoArticulo.ShowDialog();
            cargarListado();
        }


        // Método para eliminar
        private void eliminar(int id)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articuloSeleccionado;

            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea eliminar definitivamente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes) {
                    articuloSeleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;
                    articuloNegocio.eliminarArticulo(articuloSeleccionado.Id);
                    cargarListado();
                }
            }
            catch (Exception ex) { throw ex; }            
        }


        // Método para actualizar
        private void actualizar(int id)
        {
            Articulo articuloSeleccionado;
            try
            {
                articuloSeleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                frmNuevoArticulo modificar = new frmNuevoArticulo(articuloSeleccionado);
                modificar.ShowDialog();
                
                cargarListado();
            }
            catch (Exception ex) { throw ex; }
        }


        // Método para ver el detalle del artículo
        private void ver(int id)
        {
            Articulo articuloSeleccionado;
            try
            {
                articuloSeleccionado = (Articulo)dgvListadoArticulos.CurrentRow.DataBoundItem;

                Form verArticulo = new frmVerDetalleArticulo(articuloSeleccionado);
                verArticulo.ShowDialog();
            }
            catch (Exception ex) { throw ex; }
        }


        // Editar, eliminar y ver detalle del artículo apretando los íconos del DataGridView
        private void dgvListadoArticulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvListadoArticulos.Columns[e.ColumnIndex].Name == "Editar")
            {
                actualizar(e.RowIndex);
            }

            if (dgvListadoArticulos.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                eliminar(e.RowIndex);
            }

            if (dgvListadoArticulos.Columns[e.ColumnIndex].Name == "Ver")
            {
                ver(e.RowIndex);
            }
        }


        // Filtra en el buscador
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string buscar = txtBuscar.Text;

            if (buscar != null)
            {
                listaFiltrada = listaArticulo.FindAll(a=>
                a.Nombre.ToUpper().Contains(buscar.ToUpper()) || 
                a.Codigo.ToUpper().Contains(buscar.ToUpper()) ||
                a.Descripcion.ToUpper().Contains(buscar.ToUpper()) ||
                a.IdCategoria.ToString().ToUpper().Contains(buscar.ToUpper()) ||
                a.IdMarca.ToString().ToUpper().Contains(buscar.ToUpper()) ||
                a.Precio.ToString().ToUpper().Contains(buscar.ToUpper())
               );
            }
            else
            {
                listaFiltrada = listaArticulo;
            }
            dgvListadoArticulos.DataSource = null;
            dgvListadoArticulos.DataSource = listaFiltrada;
            ocultarColumnas();

            dgvListadoArticulos.Columns["Editar"].DisplayIndex = 11;
            dgvListadoArticulos.Columns["Eliminar"].DisplayIndex = 11;
            dgvListadoArticulos.Columns["Ver"].DisplayIndex = 11;
        }


        // Filtro avanzado con opciones en ComboBox
        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarSelectedItem();
  
            string opcion = cmbCampo.SelectedItem.ToString();

            if (opcion == "Precio") {
                txtFiltro.Text = "";
                cmbCriterio.Items.Clear();
                cmbCriterio.Items.Add("Menor a");
                cmbCriterio.Items.Add("Igual a");
                cmbCriterio.Items.Add("Mayor a");
            }
            else
            {
                txtFiltro.Text = "";
                cmbCriterio.Items.Clear();
                cmbCriterio.Items.Add("Comienza con");
                cmbCriterio.Items.Add("Termina con");
                cmbCriterio.Items.Add("Contiene");
            }
        }

        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarSelectedItem();
        }



        // Método para buscar en la base de datos el filtro avanzado
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articulo = new ArticuloNegocio();

            try
            {
                if (cmbCampo.SelectedIndex == -1 || cmbCriterio.SelectedIndex == -1)
                {
                    txtFiltro.Enabled = false;
                    MessageBox.Show("Debe seleccionar un campo y un criterio antes de filtrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
                    txtFiltro.Enabled = true;
                }

                string campo = cmbCampo.SelectedItem.ToString();
                string criterio = cmbCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;

                dgvListadoArticulos.DataSource = articulo.filtrarArticulos(campo, criterio, filtro);

                if (cmbCampo.SelectedIndex == -1 && cmbCriterio.SelectedIndex == -1)
                {
                }
                else
                {
                    txtFiltro.Enabled = true;
                }


                // Valida si no se encontraron registros luego de filtrar para mostrar un mensaje
                if (dgvListadoArticulos.Rows.Count == 0)
                {
                    lblSinRegistro.Visible = true;
                }
                else {
                    lblSinRegistro.Visible = false;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        // Valida si está seleccionado un item del ComboBox
        private void validarSelectedItem()
        {
            if (cmbCampo.SelectedIndex == -1 || cmbCriterio.SelectedIndex == -1)
            {
                txtFiltro.Enabled = false;
            }
            else
            {
                txtFiltro.Enabled = true;
            }
        }
    }
}
