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
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.btnVentasPorFecha = new System.Windows.Forms.Button();
            this.btnTopVendedores = new System.Windows.Forms.Button();
            this.btnArticulosMasVendidos = new System.Windows.Forms.Button();
            this.btnResumenDiario = new System.Windows.Forms.Button();
            this.btnVentasDetalladas = new System.Windows.Forms.Button();
            this.gbxFiltros = new System.Windows.Forms.GroupBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportes)).BeginInit();
            this.gbxFiltros.SuspendLayout();
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
            this.panel.Size = new System.Drawing.Size(1200, 90);
            this.panel.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 24F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTitulo.Location = new System.Drawing.Point(90, 28);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(390, 38);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Reportes y Estadísticas";
            // 
            // pbxLogo
            // 
            this.pbxLogo.Image = global::app.Properties.Resources.logo;
            this.pbxLogo.Location = new System.Drawing.Point(15, 15);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(65, 65);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 0;
            this.pbxLogo.TabStop = false;
            // 
            // btnInventarioCompleto
            // 
            this.btnInventarioCompleto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnInventarioCompleto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventarioCompleto.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventarioCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnInventarioCompleto.Location = new System.Drawing.Point(20, 274);
            this.btnInventarioCompleto.Name = "btnInventarioCompleto";
            this.btnInventarioCompleto.Size = new System.Drawing.Size(201, 45);
            this.btnInventarioCompleto.TabIndex = 1;
            this.btnInventarioCompleto.Text = "📋 Inventario Completo";
            this.btnInventarioCompleto.UseVisualStyleBackColor = false;
            this.btnInventarioCompleto.Click += new System.EventHandler(this.btnInventarioCompleto_Click);
            // 
            // btnEstadisticasCategorias
            // 
            this.btnEstadisticasCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnEstadisticasCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadisticasCategorias.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticasCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnEstadisticasCategorias.Location = new System.Drawing.Point(20, 117);
            this.btnEstadisticasCategorias.Name = "btnEstadisticasCategorias";
            this.btnEstadisticasCategorias.Size = new System.Drawing.Size(201, 45);
            this.btnEstadisticasCategorias.TabIndex = 2;
            this.btnEstadisticasCategorias.Text = "📊 Por Categorías";
            this.btnEstadisticasCategorias.UseVisualStyleBackColor = false;
            this.btnEstadisticasCategorias.Click += new System.EventHandler(this.btnEstadisticasCategorias_Click);
            // 
            // btnEstadisticasMarcas
            // 
            this.btnEstadisticasMarcas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnEstadisticasMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadisticasMarcas.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadisticasMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnEstadisticasMarcas.Location = new System.Drawing.Point(260, 117);
            this.btnEstadisticasMarcas.Name = "btnEstadisticasMarcas";
            this.btnEstadisticasMarcas.Size = new System.Drawing.Size(201, 45);
            this.btnEstadisticasMarcas.TabIndex = 3;
            this.btnEstadisticasMarcas.Text = "🏷️ Por Marcas";
            this.btnEstadisticasMarcas.UseVisualStyleBackColor = false;
            this.btnEstadisticasMarcas.Click += new System.EventHandler(this.btnEstadisticasMarcas_Click);
            // 
            // btnBajoStock
            // 
            this.btnBajoStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnBajoStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajoStock.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajoStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnBajoStock.Location = new System.Drawing.Point(260, 193);
            this.btnBajoStock.Name = "btnBajoStock";
            this.btnBajoStock.Size = new System.Drawing.Size(201, 45);
            this.btnBajoStock.TabIndex = 12;
            this.btnBajoStock.Text = "⚠️ Bajo Stock";
            this.btnBajoStock.UseVisualStyleBackColor = false;
            this.btnBajoStock.Click += new System.EventHandler(this.btnBajoStock_Click);
            // 
            // btnSinStock
            // 
            this.btnSinStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnSinStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinStock.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnSinStock.Location = new System.Drawing.Point(20, 193);
            this.btnSinStock.Name = "btnSinStock";
            this.btnSinStock.Size = new System.Drawing.Size(201, 45);
            this.btnSinStock.TabIndex = 13;
            this.btnSinStock.Text = "❌ Sin Stock";
            this.btnSinStock.UseVisualStyleBackColor = false;
            this.btnSinStock.Click += new System.EventHandler(this.btnSinStock_Click);
            // 
            // btnStockCategorias
            // 
            this.btnStockCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnStockCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockCategorias.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnStockCategorias.Location = new System.Drawing.Point(740, 117);
            this.btnStockCategorias.Name = "btnStockCategorias";
            this.btnStockCategorias.Size = new System.Drawing.Size(201, 45);
            this.btnStockCategorias.TabIndex = 14;
            this.btnStockCategorias.Text = "📦 Stock por Categorías";
            this.btnStockCategorias.UseVisualStyleBackColor = false;
            this.btnStockCategorias.Click += new System.EventHandler(this.btnStockCategorias_Click);
            // 
            // btnStockMarcas
            // 
            this.btnStockMarcas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnStockMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockMarcas.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnStockMarcas.Location = new System.Drawing.Point(500, 117);
            this.btnStockMarcas.Name = "btnStockMarcas";
            this.btnStockMarcas.Size = new System.Drawing.Size(201, 45);
            this.btnStockMarcas.TabIndex = 15;
            this.btnStockMarcas.Text = "🏭 Stock por Marcas";
            this.btnStockMarcas.UseVisualStyleBackColor = false;
            this.btnStockMarcas.Click += new System.EventHandler(this.btnStockMarcas_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(103)))), ((int)(((byte)(115)))));
            this.btnExportarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarPDF.Font = new System.Drawing.Font("Verdana", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnExportarPDF.Location = new System.Drawing.Point(500, 274);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(201, 45);
            this.btnExportarPDF.TabIndex = 4;
            this.btnExportarPDF.Text = "📄 Exportar";
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
            this.dgvReportes.Location = new System.Drawing.Point(20, 360);
            this.dgvReportes.Name = "dgvReportes";
            this.dgvReportes.ReadOnly = true;
            this.dgvReportes.RowHeadersVisible = false;
            this.dgvReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReportes.Size = new System.Drawing.Size(1160, 357);
            this.dgvReportes.TabIndex = 10;
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTituloReporte.Location = new System.Drawing.Point(20, 330);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(0, 18);
            this.lblTituloReporte.TabIndex = 11;
            // 
            // btnVentasPorFecha
            // 
            this.btnVentasPorFecha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnVentasPorFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasPorFecha.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasPorFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnVentasPorFecha.Location = new System.Drawing.Point(979, 193);
            this.btnVentasPorFecha.Name = "btnVentasPorFecha";
            this.btnVentasPorFecha.Size = new System.Drawing.Size(201, 45);
            this.btnVentasPorFecha.TabIndex = 16;
            this.btnVentasPorFecha.Text = "💰 Ventas por Fecha";
            this.btnVentasPorFecha.UseVisualStyleBackColor = false;
            this.btnVentasPorFecha.Click += new System.EventHandler(this.btnVentasPorFecha_Click);
            // 
            // btnTopVendedores
            // 
            this.btnTopVendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnTopVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopVendedores.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTopVendedores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnTopVendedores.Location = new System.Drawing.Point(740, 193);
            this.btnTopVendedores.Name = "btnTopVendedores";
            this.btnTopVendedores.Size = new System.Drawing.Size(201, 45);
            this.btnTopVendedores.TabIndex = 17;
            this.btnTopVendedores.Text = "🏆 Top Vendedores";
            this.btnTopVendedores.UseVisualStyleBackColor = false;
            this.btnTopVendedores.Click += new System.EventHandler(this.btnTopVendedores_Click);
            // 
            // btnArticulosMasVendidos
            // 
            this.btnArticulosMasVendidos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnArticulosMasVendidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArticulosMasVendidos.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArticulosMasVendidos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnArticulosMasVendidos.Location = new System.Drawing.Point(500, 193);
            this.btnArticulosMasVendidos.Name = "btnArticulosMasVendidos";
            this.btnArticulosMasVendidos.Size = new System.Drawing.Size(201, 45);
            this.btnArticulosMasVendidos.TabIndex = 18;
            this.btnArticulosMasVendidos.Text = "🔥 Más Vendidos";
            this.btnArticulosMasVendidos.UseVisualStyleBackColor = false;
            this.btnArticulosMasVendidos.Click += new System.EventHandler(this.btnArticulosMasVendidos_Click);
            // 
            // btnResumenDiario
            // 
            this.btnResumenDiario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnResumenDiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumenDiario.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumenDiario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnResumenDiario.Location = new System.Drawing.Point(260, 275);
            this.btnResumenDiario.Name = "btnResumenDiario";
            this.btnResumenDiario.Size = new System.Drawing.Size(201, 45);
            this.btnResumenDiario.TabIndex = 19;
            this.btnResumenDiario.Text = "📅 Resumen Diario";
            this.btnResumenDiario.UseVisualStyleBackColor = false;
            this.btnResumenDiario.Click += new System.EventHandler(this.btnResumenDiario_Click);
            // 
            // btnVentasDetalladas
            // 
            this.btnVentasDetalladas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnVentasDetalladas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentasDetalladas.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentasDetalladas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnVentasDetalladas.Location = new System.Drawing.Point(979, 118);
            this.btnVentasDetalladas.Name = "btnVentasDetalladas";
            this.btnVentasDetalladas.Size = new System.Drawing.Size(201, 45);
            this.btnVentasDetalladas.TabIndex = 20;
            this.btnVentasDetalladas.Text = "📋 Ventas Detalladas";
            this.btnVentasDetalladas.UseVisualStyleBackColor = false;
            this.btnVentasDetalladas.Click += new System.EventHandler(this.btnVentasDetalladas_Click);
            // 
            // gbxFiltros
            // 
            this.gbxFiltros.Controls.Add(this.dtpFechaFin);
            this.gbxFiltros.Controls.Add(this.dtpFechaInicio);
            this.gbxFiltros.Controls.Add(this.lblFechaFin);
            this.gbxFiltros.Controls.Add(this.lblFechaInicio);
            this.gbxFiltros.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxFiltros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.gbxFiltros.Location = new System.Drawing.Point(740, 255);
            this.gbxFiltros.Name = "gbxFiltros";
            this.gbxFiltros.Size = new System.Drawing.Size(440, 77);
            this.gbxFiltros.TabIndex = 21;
            this.gbxFiltros.TabStop = false;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(289, 29);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(130, 22);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(89, 29);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(130, 22);
            this.dtpFechaInicio.TabIndex = 2;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.Location = new System.Drawing.Point(239, 32);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(49, 14);
            this.lblFechaFin.TabIndex = 1;
            this.lblFechaFin.Text = "Hasta:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.Location = new System.Drawing.Point(19, 32);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(52, 14);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Desde:";
            // 
            // frmReportes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(73)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.gbxFiltros);
            this.Controls.Add(this.btnVentasDetalladas);
            this.Controls.Add(this.btnInventarioCompleto);
            this.Controls.Add(this.btnResumenDiario);
            this.Controls.Add(this.btnArticulosMasVendidos);
            this.Controls.Add(this.btnTopVendedores);
            this.Controls.Add(this.btnVentasPorFecha);
            this.Controls.Add(this.lblTituloReporte);
            this.Controls.Add(this.dgvReportes);
            this.Controls.Add(this.btnStockMarcas);
            this.Controls.Add(this.btnStockCategorias);
            this.Controls.Add(this.btnSinStock);
            this.Controls.Add(this.btnBajoStock);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.btnEstadisticasMarcas);
            this.Controls.Add(this.btnEstadisticasCategorias);
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
            this.gbxFiltros.ResumeLayout(false);
            this.gbxFiltros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.Button btnBajoStock;
        private System.Windows.Forms.Button btnSinStock;
        private System.Windows.Forms.Button btnStockCategorias;
        private System.Windows.Forms.Button btnStockMarcas;
        private System.Windows.Forms.Button btnVentasPorFecha;
        private System.Windows.Forms.Button btnTopVendedores;
        private System.Windows.Forms.Button btnArticulosMasVendidos;
        private System.Windows.Forms.Button btnResumenDiario;
        private System.Windows.Forms.Button btnVentasDetalladas;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.GroupBox gbxFiltros;
    }
}
