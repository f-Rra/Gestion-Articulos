
namespace app
{
    partial class frmAdmin
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
            this.lblResumen = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnMarcas = new System.Windows.Forms.Button();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
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
            this.panel.TabIndex = 8;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Verdana", 24F);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblTitulo.Location = new System.Drawing.Point(90, 28);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(500, 38);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Sistema de Gestión Comercial";
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
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.BackColor = System.Drawing.Color.Transparent;
            this.lblResumen.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.lblResumen.Location = new System.Drawing.Point(200, 400);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(253, 23);
            this.lblResumen.TabIndex = 14;
            this.lblResumen.Text = "📈 Resumen: Cargando...";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(103)))), ((int)(((byte)(115)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(750, 400);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(180, 50);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.Location = new System.Drawing.Point(450, 280);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnStock.Size = new System.Drawing.Size(200, 50);
            this.btnStock.TabIndex = 12;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(700, 200);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(200, 50);
            this.btnReportes.TabIndex = 11;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnMarcas
            // 
            this.btnMarcas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnMarcas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarcas.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarcas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnMarcas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMarcas.Location = new System.Drawing.Point(450, 200);
            this.btnMarcas.Name = "btnMarcas";
            this.btnMarcas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnMarcas.Size = new System.Drawing.Size(200, 50);
            this.btnMarcas.TabIndex = 10;
            this.btnMarcas.Text = "Marcas";
            this.btnMarcas.UseVisualStyleBackColor = false;
            this.btnMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
            // 
            // btnCategorias
            // 
            this.btnCategorias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.btnCategorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategorias.Font = new System.Drawing.Font("Verdana", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategorias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(227)))), ((int)(((byte)(213)))));
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(200, 200);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCategorias.Size = new System.Drawing.Size(200, 50);
            this.btnCategorias.TabIndex = 9;
            this.btnCategorias.Text = "Categorias";
            this.btnCategorias.UseVisualStyleBackColor = false;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(73)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.lblResumen);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnMarcas);
            this.Controls.Add(this.btnCategorias);
            this.Controls.Add(this.panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Administración";
            this.Load += new System.EventHandler(this.frmAdmin_Load);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnMarcas;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblResumen;
    }
}