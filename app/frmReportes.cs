using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace app
{
    public partial class frmReportes : Form
    {
        private ReporteNegocio reporteNegocio;

        public frmReportes()
        {
            InitializeComponent();
            reporteNegocio = new ReporteNegocio();
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            try
            {
                // Configurar fechas por defecto (último mes)
                dtpFechaInicio.Value = DateTime.Now.AddMonths(-1);
                dtpFechaFin.Value = DateTime.Now;
                
                btnInventarioCompleto_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void btnInventarioCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable inventario = reporteNegocio.obtenerInventarioCompleto();
                dgvReportes.DataSource = inventario;
                lblTituloReporte.Text = "Inventario Completo";
                configurarDataGridView();
                resetearColoresBotones();
                btnInventarioCompleto.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el reporte de inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEstadisticasCategorias_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable estadisticasCategorias = reporteNegocio.obtenerInventarioPorCategoria();
                dgvReportes.DataSource = estadisticasCategorias;
                lblTituloReporte.Text = "Estadísticas por Categoría";
                configurarDataGridView();
                resetearColoresBotones();
                btnEstadisticasCategorias.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar estadísticas por categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBajoStock_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable articulosBajoStock = reporteNegocio.obtenerArticulosBajoStock(5);
                dgvReportes.DataSource = articulosBajoStock;
                lblTituloReporte.Text = "Artículos con Bajo Stock (≤ 5 unidades)";
                configurarDataGridView();
                resetearColoresBotones();
                btnBajoStock.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte de bajo stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSinStock_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable articulosSinStock = reporteNegocio.obtenerArticulosSinStock();
                dgvReportes.DataSource = articulosSinStock;
                lblTituloReporte.Text = "Artículos Sin Stock (0 unidades)";          
                configurarDataGridView();
                resetearColoresBotones();
                btnSinStock.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte sin stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStockCategorias_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable stockCategorias = reporteNegocio.obtenerEstadisticasStockPorCategoria();
                dgvReportes.DataSource = stockCategorias;
                lblTituloReporte.Text = "Estadísticas de Stock por Categoría";
                configurarDataGridView();
                resetearColoresBotones();
                btnStockCategorias.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar estadísticas de stock por categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStockMarcas_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable stockMarcas = reporteNegocio.obtenerEstadisticasStockPorMarca();
                dgvReportes.DataSource = stockMarcas;
                lblTituloReporte.Text = "Estadísticas de Stock por Marca";          
                configurarDataGridView();
                resetearColoresBotones();
                btnStockMarcas.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar estadísticas de stock por marca: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEstadisticasMarcas_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable estadisticasMarcas = reporteNegocio.obtenerInventarioPorMarca();
                dgvReportes.DataSource = estadisticasMarcas;
                lblTituloReporte.Text = "Estadísticas por Marca";
                configurarDataGridView();
                resetearColoresBotones();
                btnEstadisticasMarcas.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar estadísticas por marca: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportes.DataSource == null || dgvReportes.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar. Genere un reporte primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivos PDF|*.pdf";
                saveDialog.Title = "Guardar Reporte como PDF";
                saveDialog.FileName = $"Reporte_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    exportar(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportar(string rutaArchivo)
        {
            try
            {
                // Método ultra simple: solo guardar como imagen PNG
                string rutaImagen = rutaArchivo.Replace(".pdf", ".png");
                
                // Crear bitmap con espacio extra para títulos
                Bitmap bitmap = new Bitmap(dgvReportes.Width + 50, dgvReportes.Height + 150);
                Graphics g = Graphics.FromImage(bitmap);
                
                // Fondo blanco
                g.Clear(Color.White);
                
                // Títulos
                Font fontTitulo = new Font("Arial", 14, FontStyle.Bold);
                Font fontNormal = new Font("Arial", 10);
                
                g.DrawString("SISTEMA DE GESTIÓN DE ARTÍCULOS", fontTitulo, Brushes.Black, 10, 10);
                g.DrawString(lblTituloReporte.Text, fontNormal, Brushes.Black, 10, 35);
                g.DrawString($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}", fontNormal, Brushes.Black, 10, 55);
                
                // Capturar DataGridView
                dgvReportes.DrawToBitmap(bitmap, new Rectangle(10, 80, dgvReportes.Width, dgvReportes.Height));
                           
                // Guardar
                bitmap.Save(rutaImagen, ImageFormat.Png);
                
                // Limpiar recursos
                g.Dispose();
                bitmap.Dispose();
                
                MessageBox.Show($"Reporte guardado como imagen:\n{rutaImagen}\n\nPuede convertir a PDF desde cualquier visor de imágenes.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(rutaImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void configurarDataGridView()
        {
            dgvReportes.DefaultCellStyle.BackColor = Color.FromArgb(242, 227, 213);
            dgvReportes.DefaultCellStyle.ForeColor = Color.FromArgb(1, 46, 64);
            dgvReportes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(60, 166, 166);
            dgvReportes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(242, 227, 213);
            dgvReportes.DefaultCellStyle.Font = new Font("Verdana", 9.75F);
            
            dgvReportes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(1, 46, 64);
            dgvReportes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(242, 227, 213);
            dgvReportes.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9.75F, FontStyle.Bold);
            dgvReportes.EnableHeadersVisualStyles = false;

            foreach (DataGridViewColumn column in dgvReportes.Columns)
            {
                if (column.Name.ToLower().Contains("precio") || column.Name.ToLower().Contains("valor"))
                {
                    column.DefaultCellStyle.Format = "C2"; // Formato moneda
                }
            }
        }

        private void resetearColoresBotones()
        {
            btnInventarioCompleto.BackColor = Color.FromArgb(1, 46, 64);
            btnEstadisticasCategorias.BackColor = Color.FromArgb(1, 46, 64);
            btnEstadisticasMarcas.BackColor = Color.FromArgb(1, 46, 64);
            btnBajoStock.BackColor = Color.FromArgb(1, 46, 64);
            btnSinStock.BackColor = Color.FromArgb(1, 46, 64);
            btnStockCategorias.BackColor = Color.FromArgb(1, 46, 64);
            btnStockMarcas.BackColor = Color.FromArgb(1, 46, 64);
        }

        // =====================================================
        // EVENTOS DE REPORTES DE VENTAS
        // =====================================================

        private void btnVentasPorFecha_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable ventasPorFecha = reporteNegocio.obtenerVentasPorFecha(dtpFechaInicio.Value, dtpFechaFin.Value);
                dgvReportes.DataSource = ventasPorFecha;
                lblTituloReporte.Text = $"Ventas del {dtpFechaInicio.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy}";
                configurarDataGridView();
                resetearColoresBotones();
                btnVentasPorFecha.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte de ventas por fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTopVendedores_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable topVendedores = reporteNegocio.obtenerTopVendedores(dtpFechaInicio.Value, dtpFechaFin.Value);
                dgvReportes.DataSource = topVendedores;
                lblTituloReporte.Text = $"Top Vendedores del {dtpFechaInicio.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy}";
                configurarDataGridView();
                resetearColoresBotones();
                btnTopVendedores.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte de top vendedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnArticulosMasVendidos_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable articulosMasVendidos = reporteNegocio.obtenerArticulosMasVendidos(dtpFechaInicio.Value, dtpFechaFin.Value);
                dgvReportes.DataSource = articulosMasVendidos;
                lblTituloReporte.Text = $"Artículos Más Vendidos del {dtpFechaInicio.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy}";
                configurarDataGridView();
                resetearColoresBotones();
                btnArticulosMasVendidos.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte de artículos más vendidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResumenDiario_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable resumenDiario = reporteNegocio.obtenerResumenVentasDiarias(dtpFechaInicio.Value, dtpFechaFin.Value);
                dgvReportes.DataSource = resumenDiario;
                lblTituloReporte.Text = $"Resumen Diario de Ventas del {dtpFechaInicio.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy}";
                configurarDataGridView();
                resetearColoresBotones();
                btnResumenDiario.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar resumen diario de ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVentasDetalladas_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable ventasDetalladas = reporteNegocio.obtenerVentasDetalladas(dtpFechaInicio.Value, dtpFechaFin.Value);
                dgvReportes.DataSource = ventasDetalladas;
                lblTituloReporte.Text = $"Ventas Detalladas del {dtpFechaInicio.Value:dd/MM/yyyy} al {dtpFechaFin.Value:dd/MM/yyyy}";
                configurarDataGridView();
                resetearColoresBotones();
                btnVentasDetalladas.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte de ventas detalladas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
