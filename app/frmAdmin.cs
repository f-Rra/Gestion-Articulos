using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace app
{
    public partial class frmAdmin : Form
    {
        private Usuario usuarioActual;

        public frmAdmin(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            cargarEstadisticas();
        }

        private void cargarEstadisticas()
        {
            try
            {
                // Primero mostrar que el método se ejecuta
                lblResumen.Text = "📈 Obteniendo datos...";
                this.Refresh();

                ArticuloNegocio artNeg = new ArticuloNegocio();
                CategoriaNegocio catNeg = new CategoriaNegocio();
                MarcaNegocio marNeg = new MarcaNegocio();

                int totalArticulos = artNeg.listar().Count;
                int totalCategorias = catNeg.listar().Count;
                int totalMarcas = marNeg.listar().Count;

                lblResumen.Text = $"📈 Resumen: {totalCategorias} Categorías | {totalMarcas} Marcas | {totalArticulos} artículos";
                this.Refresh();
            }
            catch (Exception ex)
            {
                lblResumen.Text = "❌ Error: " + ex.Message;
                this.Refresh();
            }
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias ventana = new frmCategorias();
            ventana.ShowDialog();
            cargarEstadisticas(); // Actualizar estadísticas al volver
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas ventana = new frmMarcas();
            ventana.ShowDialog();
            cargarEstadisticas(); // Actualizar estadísticas al volver
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            // Por ahora mostrar mensaje, luego crear frmMarcas
            MessageBox.Show("Reportes - Próximamente", "En desarrollo");
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro que desea salir?",
                "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}