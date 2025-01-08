namespace winform_app
{
    partial class frmListadoArticulos
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListadoArticulos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblFiltrarPor = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvListadoArticulos = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Ver = new System.Windows.Forms.DataGridViewImageColumn();
            this.picArticulo = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitulo.Font = new System.Drawing.Font("Yu Gothic UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.lblTitulo.Location = new System.Drawing.Point(419, 17);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(331, 45);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Control de Inventario";
            // 
            // lblFiltrarPor
            // 
            this.lblFiltrarPor.AutoSize = true;
            this.lblFiltrarPor.Font = new System.Drawing.Font("Tw Cen MT", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltrarPor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFiltrarPor.Location = new System.Drawing.Point(12, 178);
            this.lblFiltrarPor.Name = "lblFiltrarPor";
            this.lblFiltrarPor.Size = new System.Drawing.Size(84, 22);
            this.lblFiltrarPor.TabIndex = 2;
            this.lblFiltrarPor.Text = "Filtrar por";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtBuscar.Font = new System.Drawing.Font("Tw Cen MT", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.txtBuscar.Location = new System.Drawing.Point(427, 83);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(304, 28);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.Text = "Buscar";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlHeader.Controls.Add(this.txtBuscar);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Location = new System.Drawing.Point(-5, -4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1168, 132);
            this.pnlHeader.TabIndex = 4;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtPrecio.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(169, 176);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(136, 28);
            this.txtPrecio.TabIndex = 5;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPrecio.Location = new System.Drawing.Point(110, 179);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(58, 22);
            this.lblPrecio.TabIndex = 5;
            this.lblPrecio.Text = "Precio";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMarca.Location = new System.Drawing.Point(334, 180);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(59, 22);
            this.lblMarca.TabIndex = 6;
            this.lblMarca.Text = "Marca";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblCategoria.Location = new System.Drawing.Point(599, 180);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(86, 22);
            this.lblCategoria.TabIndex = 7;
            this.lblCategoria.Text = "Categoría";
            // 
            // cmbMarca
            // 
            this.cmbMarca.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(395, 177);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(180, 30);
            this.cmbMarca.TabIndex = 6;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(687, 177);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(180, 30);
            this.cmbCategoria.TabIndex = 7;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(138)))), ((int)(((byte)(66)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Tw Cen MT", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(976, 171);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAgregar.Size = new System.Drawing.Size(166, 43);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Nuevo Artículo";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(138)))), ((int)(((byte)(66)))));
            this.panel1.Location = new System.Drawing.Point(-5, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 10);
            this.panel1.TabIndex = 5;
            // 
            // dgvListadoArticulos
            // 
            this.dgvListadoArticulos.AllowUserToResizeColumns = false;
            this.dgvListadoArticulos.AllowUserToResizeRows = false;
            this.dgvListadoArticulos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListadoArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoArticulos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.dgvListadoArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvListadoArticulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListadoArticulos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvListadoArticulos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(160)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(160)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListadoArticulos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListadoArticulos.ColumnHeadersHeight = 46;
            this.dgvListadoArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvListadoArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar,
            this.Eliminar,
            this.Ver});
            this.dgvListadoArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListadoArticulos.EnableHeadersVisualStyles = false;
            this.dgvListadoArticulos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(152)))), ((int)(((byte)(175)))));
            this.dgvListadoArticulos.Location = new System.Drawing.Point(12, 241);
            this.dgvListadoArticulos.Margin = new System.Windows.Forms.Padding(10);
            this.dgvListadoArticulos.MultiSelect = false;
            this.dgvListadoArticulos.Name = "dgvListadoArticulos";
            this.dgvListadoArticulos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvListadoArticulos.RowHeadersVisible = false;
            this.dgvListadoArticulos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tw Cen MT", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(238)))), ((int)(((byte)(225)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvListadoArticulos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListadoArticulos.RowTemplate.Height = 40;
            this.dgvListadoArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoArticulos.Size = new System.Drawing.Size(923, 551);
            this.dgvListadoArticulos.TabIndex = 9;
            this.dgvListadoArticulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoArticulos_CellClick);
            this.dgvListadoArticulos.SelectionChanged += new System.EventHandler(this.dgvListadoArticulos_SelectionChanged);
            // 
            // Editar
            // 
            this.Editar.FillWeight = 7.614212F;
            this.Editar.HeaderText = "";
            this.Editar.Image = ((System.Drawing.Image)(resources.GetObject("Editar.Image")));
            this.Editar.Name = "Editar";
            // 
            // Eliminar
            // 
            this.Eliminar.FillWeight = 284.7716F;
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.Name = "Eliminar";
            // 
            // Ver
            // 
            this.Ver.FillWeight = 7.614212F;
            this.Ver.HeaderText = "";
            this.Ver.Image = ((System.Drawing.Image)(resources.GetObject("Ver.Image")));
            this.Ver.Name = "Ver";
            // 
            // picArticulo
            // 
            this.picArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picArticulo.Location = new System.Drawing.Point(940, 241);
            this.picArticulo.Name = "picArticulo";
            this.picArticulo.Size = new System.Drawing.Size(210, 199);
            this.picArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picArticulo.TabIndex = 17;
            this.picArticulo.TabStop = false;
            // 
            // frmListadoArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1154, 811);
            this.Controls.Add(this.picArticulo);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblFiltrarPor);
            this.Controls.Add(this.dgvListadoArticulos);
            this.Controls.Add(this.pnlHeader);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.MinimumSize = new System.Drawing.Size(1100, 850);
            this.Name = "frmListadoArticulos";
            this.ShowIcon = false;
            this.Text = "Control de inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListadoArticulos_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picArticulo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblFiltrarPor;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Panel panel1;
        #region Windows Form Designer generated code
        #endregion

        private System.Windows.Forms.DataGridView dgvListadoArticulos;
        private System.Windows.Forms.PictureBox picArticulo;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.DataGridViewImageColumn Ver;
    }
}