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
                mostrarEstadisticasGenerales();
                // Cargar inventario completo por defecto
                btnInventarioCompleto_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mostrarEstadisticasGenerales()
        {
            try
            {
                DataTable estadisticas = reporteNegocio.obtenerEstadisticasGenerales();
                if (estadisticas.Rows.Count > 0)
                {
                    DataRow row = estadisticas.Rows[0];
                    lblTotalArticulos.Text = $"Total Artículos: {row["TotalArticulos"]}";
                    lblTotalCategorias.Text = $"Total Categorías: {row["TotalCategorias"]}";
                    lblTotalMarcas.Text = $"Total Marcas: {row["TotalMarcas"]}";
                    
                    if (row["PrecioPromedio"] != DBNull.Value)
                    {
                        decimal precioPromedio = Convert.ToDecimal(row["PrecioPromedio"]);
                        lblPrecioPromedio.Text = $"Precio Promedio: ${precioPromedio:F2}";
                    }
                    else
                    {
                        lblPrecioPromedio.Text = "Precio Promedio: $0.00";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estadísticas generales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInventarioCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable inventario = reporteNegocio.obtenerInventarioCompleto();
                dgvReportes.DataSource = inventario;
                lblTituloReporte.Text = "Inventario Completo";
                
                // Configurar DataGridView
                configurarDataGridView();
                
                // Cambiar color del botón activo
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
                
                // Configurar DataGridView
                configurarDataGridView();
                
                // Cambiar color del botón activo
                resetearColoresBotones();
                btnEstadisticasCategorias.BackColor = Color.FromArgb(2, 103, 115);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar estadísticas por categoría: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEstadisticasMarcas_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable estadisticasMarcas = reporteNegocio.obtenerInventarioPorMarca();
                dgvReportes.DataSource = estadisticasMarcas;
                lblTituloReporte.Text = "Estadísticas por Marca";
                
                // Configurar DataGridView
                configurarDataGridView();
                
                // Cambiar color del botón activo
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
                    exportarAPDF(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportarAPDF(string rutaArchivo)
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
                
                // Estadísticas
                int yPos = dgvReportes.Height + 90;
                g.DrawString(lblTotalArticulos.Text, fontNormal, Brushes.Black, 10, yPos);
                g.DrawString(lblTotalCategorias.Text, fontNormal, Brushes.Black, 200, yPos);
                g.DrawString(lblTotalMarcas.Text, fontNormal, Brushes.Black, 400, yPos);
                g.DrawString(lblPrecioPromedio.Text, fontNormal, Brushes.Black, 10, yPos + 20);
                
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

            // Formatear columnas de precio si existen
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
        }
    }
}
