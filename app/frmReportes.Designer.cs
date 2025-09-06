namespace app
{
    partial class frmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.btnInventarioCompleto = new System.Windows.Forms.Button();
            this.btnEstadisticasCategorias = new System.Windows.Forms.Button();
            this.btnEstadisticasMarcas = new System.Windows.Forms.Button();
            this.btnBajoStock = new System.Windows.Forms.Button();
            this.btnSinStock = new System.Windows.Forms.Button();
            this.btnStockCategorias = new System.Windows.Forms.Button();
            this.btnStockMarcas = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.dgvReportes = new System.Windows.Forms.DataGridView();
            this.lblTotalArticulos = new System.Windows.Forms.Label();
            this.lblTotalCategorias = new System.Windows.Forms.Label();
            this.lblTotalMarcas = new System.Windows.Forms.Label();
            this.lblPrecioPromedio = new System.Windows.Forms.Label();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel.Controls.Add(this.lblTitulo);
            this.panel.Controls.Add(this.pbxLogo);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
<<<<<<< HEAD
            this.panel.Size = new System.Drawing.Size(854, 76);
=======
            this.panel.Size = new System.Drawing.Size(1200, 90);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.panel.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
<<<<<<< HEAD
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 20F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTitulo.Location = new System.Drawing.Point(74, 22);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(331, 32);
=======
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 24F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTitulo.Location = new System.Drawing.Point(90, 28);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(390, 38);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Reportes y Estadísticas";
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::app.Properties.Resources.logo;
<<<<<<< HEAD
            this.pbxLogo.Location = new System.Drawing.Point(12, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(50, 50);
=======
            this.pbxLogo.Location = new System.Drawing.Point(15, 15);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(65, 65);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // btnInventarioCompleto
            // 
            this.btnInventarioCompleto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnInventarioCompleto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
<<<<<<< HEAD
            this.btnInventarioCompleto.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventarioCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnInventarioCompleto.Location = new System.Drawing.Point(12, 100);
            this.btnInventarioCompleto.Name = "btnInventarioCompleto";
            this.btnInventarioCompleto.Size = new System.Drawing.Size(180, 35);
=======
            this.btnInventarioCompleto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventarioCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnInventarioCompleto.Location = new System.Drawing.Point(20, 120);
            this.btnInventarioCompleto.Name = "btnInventarioCompleto";
            this.btnInventarioCompleto.Size = new System.Drawing.Size(220, 45);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.btnInventarioCompleto.TabIndex = 1;
            this.btnInventarioCompleto.Text = "📋 Inventario Completo";
            this.btnInventarioCompleto.UseVisualStyleBackColor = false;
            this.btnInventarioCompleto.Click += new System.EventHandler(this.btnInventarioCompleto_Click);
            // 
            // btnEstadisticasCategorias
            // 
            this.btnEstadisticasCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnEstadisticasCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
<<<<<<< HEAD
            this.btnEstadisticasCategorias.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticasCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnEstadisticasCategorias.Location = new System.Drawing.Point(210, 100);
            this.btnEstadisticasCategorias.Name = "btnEstadisticasCategorias";
            this.btnEstadisticasCategorias.Size = new System.Drawing.Size(180, 35);
=======
            this.btnEstadisticasCategorias.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticasCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnEstadisticasCategorias.Location = new System.Drawing.Point(260, 120);
            this.btnEstadisticasCategorias.Name = "btnEstadisticasCategorias";
            this.btnEstadisticasCategorias.Size = new System.Drawing.Size(220, 45);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.btnEstadisticasCategorias.TabIndex = 2;
            this.btnEstadisticasCategorias.Text = "📊 Por Categorías";
            this.btnEstadisticasCategorias.UseVisualStyleBackColor = false;
            this.btnEstadisticasCategorias.Click += new System.EventHandler(this.btnEstadisticasCategorias_Click);
            // 
            // btnEstadisticasMarcas
            // 
            this.btnEstadisticasMarcas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnEstadisticasMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
<<<<<<< HEAD
            this.btnEstadisticasMarcas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticasMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnEstadisticasMarcas.Location = new System.Drawing.Point(408, 100);
            this.btnEstadisticasMarcas.Name = "btnEstadisticasMarcas";
            this.btnEstadisticasMarcas.Size = new System.Drawing.Size(180, 35);
=======
            this.btnEstadisticasMarcas.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticasMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnEstadisticasMarcas.Location = new System.Drawing.Point(500, 120);
            this.btnEstadisticasMarcas.Name = "btnEstadisticasMarcas";
            this.btnEstadisticasMarcas.Size = new System.Drawing.Size(220, 45);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.btnEstadisticasMarcas.TabIndex = 3;
            this.btnEstadisticasMarcas.Text = "🏷️ Por Marcas";
            this.btnEstadisticasMarcas.UseVisualStyleBackColor = false;
            this.btnEstadisticasMarcas.Click += new System.EventHandler(this.btnEstadisticasMarcas_Click);
            // 
            // btnBajoStock
            // 
            this.btnBajoStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnBajoStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
<<<<<<< HEAD
            this.btnBajoStock.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajoStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnBajoStock.Location = new System.Drawing.Point(606, 100);
            this.btnBajoStock.Name = "btnBajoStock";
            this.btnBajoStock.Size = new System.Drawing.Size(180, 35);
=======
            this.btnBajoStock.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajoStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnBajoStock.Location = new System.Drawing.Point(740, 120);
            this.btnBajoStock.Name = "btnBajoStock";
            this.btnBajoStock.Size = new System.Drawing.Size(220, 45);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.btnBajoStock.TabIndex = 12;
            this.btnBajoStock.Text = "⚠️ Bajo Stock";
            this.btnBajoStock.UseVisualStyleBackColor = false;
            this.btnBajoStock.Click += new System.EventHandler(this.btnBajoStock_Click);
            // 
            // btnSinStock
            // 
            this.btnSinStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnSinStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
<<<<<<< HEAD
            this.btnSinStock.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnSinStock.Location = new System.Drawing.Point(12, 140);
            this.btnSinStock.Name = "btnSinStock";
            this.btnSinStock.Size = new System.Drawing.Size(180, 35);
=======
            this.btnSinStock.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnSinStock.Location = new System.Drawing.Point(20, 180);
            this.btnSinStock.Name = "btnSinStock";
            this.btnSinStock.Size = new System.Drawing.Size(220, 45);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.btnSinStock.TabIndex = 13;
            this.btnSinStock.Text = "❌ Sin Stock";
            this.btnSinStock.UseVisualStyleBackColor = false;
            this.btnSinStock.Click += new System.EventHandler(this.btnSinStock_Click);
            // 
            // btnStockCategorias
            // 
            this.btnStockCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnStockCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
<<<<<<< HEAD
            this.btnStockCategorias.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnStockCategorias.Location = new System.Drawing.Point(210, 140);
            this.btnStockCategorias.Name = "btnStockCategorias";
            this.btnStockCategorias.Size = new System.Drawing.Size(180, 35);
=======
            this.btnStockCategorias.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnStockCategorias.Location = new System.Drawing.Point(260, 180);
            this.btnStockCategorias.Name = "btnStockCategorias";
            this.btnStockCategorias.Size = new System.Drawing.Size(220, 45);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.btnStockCategorias.TabIndex = 14;
            this.btnStockCategorias.Text = "📦 Stock por Categorías";
            this.btnStockCategorias.UseVisualStyleBackColor = false;
            this.btnStockCategorias.Click += new System.EventHandler(this.btnStockCategorias_Click);
            // 
            // btnStockMarcas
            // 
            this.btnStockMarcas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnStockMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
<<<<<<< HEAD
            this.btnStockMarcas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnStockMarcas.Location = new System.Drawing.Point(408, 140);
            this.btnStockMarcas.Name = "btnStockMarcas";
            this.btnStockMarcas.Size = new System.Drawing.Size(180, 35);
=======
            this.btnStockMarcas.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnStockMarcas.Location = new System.Drawing.Point(500, 180);
            this.btnStockMarcas.Name = "btnStockMarcas";
            this.btnStockMarcas.Size = new System.Drawing.Size(220, 45);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.btnStockMarcas.TabIndex = 15;
            this.btnStockMarcas.Text = "🏭 Stock por Marcas";
            this.btnStockMarcas.UseVisualStyleBackColor = false;
            this.btnStockMarcas.Click += new System.EventHandler(this.btnStockMarcas_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(103)))), ((int)(((byte)(115)))));
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
<<<<<<< HEAD
            this.btnExportarPDF.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnExportarPDF.Location = new System.Drawing.Point(12, 180);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(180, 35);
=======
            this.btnExportarPDF.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnExportarPDF.Location = new System.Drawing.Point(740, 180);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(220, 45);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.btnExportarPDF.TabIndex = 4;
            this.btnExportarPDF.Text = "📄 Exportar a PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = false;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // dgvReportes
            // 
            this.dgvReportes.AllowUserToAddRows = false;
            this.dgvReportes.AllowUserToDeleteRows = false;
            this.dgvReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReportes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.dgvReportes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
<<<<<<< HEAD
            this.dgvReportes.Location = new System.Drawing.Point(12, 225);
=======
            this.dgvReportes.Location = new System.Drawing.Point(20, 280);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.RowHeadersVisible = false;
            this.dgvReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
<<<<<<< HEAD
            this.dgvReportes.Size = new System.Drawing.Size(830, 250);
            this.dgvReportes.TabIndex = 10;
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTituloReporte.Location = new System.Drawing.Point(12, 200);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(0, 17);
            this.lblTituloReporte.TabIndex = 11;
            // 
            // lblTotalArticulos
            // 
            this.lblTotalArticulos.AutoSize = true;
            this.lblTotalArticulos.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalArticulos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTotalArticulos.Location = new System.Drawing.Point(12, 480);
            this.lblTotalArticulos.Name = "lblTotalArticulos";
            this.lblTotalArticulos.Size = new System.Drawing.Size(150, 16);
=======
            this.dgvReportes.Size = new System.Drawing.Size(1160, 350);
            this.dgvReportes.TabIndex = 10;
            // 
            // lblTotalArticulos
            // 
            this.lblTotalArticulos.AutoSize = true;
            this.lblTotalArticulos.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalArticulos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTotalArticulos.Location = new System.Drawing.Point(20, 650);
            this.lblTotalArticulos.Name = "lblTotalArticulos";
            this.lblTotalArticulos.Size = new System.Drawing.Size(147, 18);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.lblTotalArticulos.TabIndex = 6;
            this.lblTotalArticulos.Text = "Total Artículos: 0";
            // 
            // lblTotalCategorias
            // 
            this.lblTotalCategorias.AutoSize = true;
<<<<<<< HEAD
            this.lblTotalCategorias.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTotalCategorias.Location = new System.Drawing.Point(210, 480);
            this.lblTotalCategorias.Name = "lblTotalCategorias";
            this.lblTotalCategorias.Size = new System.Drawing.Size(160, 16);
=======
            this.lblTotalCategorias.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTotalCategorias.Location = new System.Drawing.Point(300, 650);
            this.lblTotalCategorias.Name = "lblTotalCategorias";
            this.lblTotalCategorias.Size = new System.Drawing.Size(164, 18);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.lblTotalCategorias.TabIndex = 7;
            this.lblTotalCategorias.Text = "Total Categorías: 0";
            // 
            // lblTotalMarcas
            // 
            this.lblTotalMarcas.AutoSize = true;
<<<<<<< HEAD
            this.lblTotalMarcas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTotalMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTotalMarcas.Location = new System.Drawing.Point(408, 480);
            this.lblTotalMarcas.Name = "lblTotalMarcas";
            this.lblTotalMarcas.Size = new System.Drawing.Size(130, 16);
=======
            this.lblTotalMarcas.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTotalMarcas.Location = new System.Drawing.Point(580, 650);
            this.lblTotalMarcas.Name = "lblTotalMarcas";
            this.lblTotalMarcas.Size = new System.Drawing.Size(134, 18);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.lblTotalMarcas.TabIndex = 8;
            this.lblTotalMarcas.Text = "Total Marcas: 0";
            // 
            // lblPrecioPromedio
            // 
            this.lblPrecioPromedio.AutoSize = true;
<<<<<<< HEAD
            this.lblPrecioPromedio.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblPrecioPromedio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblPrecioPromedio.Location = new System.Drawing.Point(606, 480);
            this.lblPrecioPromedio.Name = "lblPrecioPromedio";
            this.lblPrecioPromedio.Size = new System.Drawing.Size(160, 16);
            this.lblPrecioPromedio.TabIndex = 9;
            this.lblPrecioPromedio.Text = "Precio Promedio: $0";
            // 
=======
            this.lblPrecioPromedio.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrecioPromedio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblPrecioPromedio.Location = new System.Drawing.Point(860, 650);
            this.lblPrecioPromedio.Name = "lblPrecioPromedio";
            this.lblPrecioPromedio.Size = new System.Drawing.Size(174, 18);
            this.lblPrecioPromedio.TabIndex = 9;
            this.lblPrecioPromedio.Text = "Precio Promedio: $0";
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTituloReporte.Location = new System.Drawing.Point(20, 250);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(0, 18);
            this.lblTituloReporte.TabIndex = 11;
            // 
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            // frmReportes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(73)))), ((int)(((byte)(89)))));
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(854, 520);
=======
            this.ClientSize = new System.Drawing.Size(1200, 750);
>>>>>>> 965eb23 (Correcciones en todos los formularios)
            this.Controls.Add(this.lblTituloReporte);
            this.Controls.Add(this.lblPrecioPromedio);
            this.Controls.Add(this.lblTotalMarcas);
            this.Controls.Add(this.lblTotalCategorias);
            this.Controls.Add(this.lblTotalArticulos);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.btnStockMarcas);
            this.Controls.Add(this.btnStockCategorias);
            this.Controls.Add(this.btnSinStock);
            this.Controls.Add(this.btnBajoStock);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.btnEstadisticasMarcas);
            this.Controls.Add(this.btnEstadisticasCategorias);
            this.Controls.Add(this.btnInventarioCompleto);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Reportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
<<<<<<< HEAD
=======

>>>>>>> 965eb23 (Correcciones en todos los formularios)
        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Button btnInventarioCompleto;
        private System.Windows.Forms.Button btnEstadisticasCategorias;
        private System.Windows.Forms.Button btnEstadisticasMarcas;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.DataGridView dgvReportes;
        private System.Windows.Forms.Label lblTotalArticulos;
        private System.Windows.Forms.Label lblTotalCategorias;
        private System.Windows.Forms.Label lblTotalMarcas;
        private System.Windows.Forms.Label lblPrecioPromedio;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.Button btnBajoStock;
        private System.Windows.Forms.Button btnSinStock;
        private System.Windows.Forms.Button btnStockCategorias;
        private System.Windows.Forms.Button btnStockMarcas;
    }
}
