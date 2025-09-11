using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace app
{
    public partial class frmVentas : Form
    {
        private VentaNegocio ventaNegocio;
        private List<DetalleVenta> carrito;
        private string vendedorActual;

        public frmVentas(string vendedor)
        {
            InitializeComponent();
            vendedorActual = vendedor;
            ventaNegocio = new VentaNegocio();
            carrito = new List<DetalleVenta>();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cargarArticulos();
            calcularTotal();
            configurarDataGridViews();
            configurarCarritoEditable();
            
        }

        private void configurarDataGridViews()
        {
            if (dgvArticulos.Columns.Contains("Id"))
                dgvArticulos.Columns["Id"].Visible = false;
            if (dgvArticulos.Columns.Contains("Descripcion"))
                dgvArticulos.Columns["Descripcion"].Visible = false;
            if (dgvArticulos.Columns.Contains("EstadoStock"))
                dgvArticulos.Columns["EstadoStock"].Visible = false;
            
            if (dgvArticulos.Columns.Contains("Precio"))
            {
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvArticulos.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            
            foreach (DataGridViewColumn column in dgvArticulos.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void configurarCarrito()
        {
            if (dgvCarrito.Columns.Contains("Id"))
                dgvCarrito.Columns["Id"].Visible = false;
            if (dgvCarrito.Columns.Contains("IdVenta"))
                dgvCarrito.Columns["IdVenta"].Visible = false;
            if (dgvCarrito.Columns.Contains("IdArticulo"))
                dgvCarrito.Columns["IdArticulo"].Visible = false;
            if (dgvCarrito.Columns.Contains("CodigoArticulo"))
                dgvCarrito.Columns["CodigoArticulo"].Visible = false;
            if (dgvCarrito.Columns.Contains("StockDisponible"))
                dgvCarrito.Columns["StockDisponible"].Visible = false;
            
            if (dgvCarrito.Columns.Contains("PrecioUnitario"))
            {
                dgvCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvCarrito.Columns["PrecioUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvCarrito.Columns.Contains("Subtotal"))
            {
                dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Format = "$ #,##0.00";
                dgvCarrito.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            
            foreach (DataGridViewColumn column in dgvCarrito.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void cargarArticulos(string filtro = "")
        {
            try
            {
                dgvArticulos.DataSource = ventaNegocio.buscarArticulosParaVenta(filtro);
                dgvArticulos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar artículos: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarArticulos(txtBuscar.Text.Trim());
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            cargarArticulos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null) return;

            DataGridViewRow fila = dgvArticulos.CurrentRow;
            int idArticulo = (int)fila.Cells["Id"].Value;
            string codigo = fila.Cells["Codigo"].Value.ToString();
            string nombre = fila.Cells["Nombre"].Value.ToString();
            decimal precio = (decimal)fila.Cells["Precio"].Value;
            int stock = (int)fila.Cells["Stock"].Value;

            // Calcular cuántas unidades de este artículo ya están en el carrito
            int cantidadEnCarrito = 0;
            foreach (var item in carrito)
            {
                if (item.IdArticulo == idArticulo)
                {
                    cantidadEnCarrito += item.Cantidad;
                }
            }

            // Verificar si hay stock disponible considerando lo que ya está en el carrito
            int stockDisponible = stock - cantidadEnCarrito;
            if (stockDisponible <= 0)
            {
                MessageBox.Show($"Stock insuficiente. Ya tienes {cantidadEnCarrito} unidades en el carrito de un stock total de {stock}.");
                return;
            }

            DetalleVenta detalle = new DetalleVenta
            {
                IdArticulo = idArticulo,
                CodigoArticulo = codigo,
                NombreArticulo = nombre,
                PrecioUnitario = precio,
                Cantidad = 1,
                StockDisponible = stockDisponible
            };

            detalle.CalcularSubtotal();
            carrito.Add(detalle);

            refrescarCarrito();
            calcularTotal();
            
            if (dgvCarrito.Rows.Count > 0)
            {
                int ultimaFila = dgvCarrito.Rows.Count - 1;
                int columnaCantidad = dgvCarrito.Columns["Cantidad"].Index;
                
                dgvCarrito.CurrentCell = dgvCarrito.Rows[ultimaFila].Cells[columnaCantidad];
                dgvCarrito.BeginEdit(true);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow == null) return;

            int index = dgvCarrito.CurrentRow.Index;
            carrito.RemoveAt(index);

            refrescarCarrito();
            calcularTotal();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            carrito.Clear();
            refrescarCarrito();
            calcularTotal();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            Venta venta = new Venta
            {
                NumeroVenta = new Venta().GenerarNumeroVenta(),
                Vendedor = vendedorActual,
                Cliente = "",
                Detalles = carrito
            };

            venta.CalcularTotal();

            try
            {
                ventaNegocio.registrarVenta(venta);
                MessageBox.Show("Venta registrada correctamente.");
                btnLimpiar.PerformClick();
                cargarArticulos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar venta: " + ex.Message);
            }
        }

        private void refrescarCarrito()
        {
            actualizarCarrito();
        }

        private void actualizarCarrito()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;
            dgvCarrito.ClearSelection();
            configurarCarrito();
            configurarCarritoEditable();
        }

        private void calcularTotal()
        {
            decimal total = 0;
            foreach (var d in carrito)
                total += d.Subtotal;

            lblTotal.Text = $"TOTAL: ${total:#,##0.00}";
        }

        private void configurarCarritoEditable()
        {
            if (dgvCarrito.Columns.Contains("Cantidad"))
            {
                dgvCarrito.Columns["Cantidad"].ReadOnly = false;
                dgvCarrito.ReadOnly = false;
            }

            dgvCarrito.CellValidating += dgvCarrito_CellValidating;
            dgvCarrito.CellEndEdit += dgvCarrito_CellEndEdit;
        }

        private void dgvCarrito_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvCarrito.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                int nuevaCantidad;
                if (!int.TryParse(e.FormattedValue.ToString(), out nuevaCantidad) || nuevaCantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número entero mayor a 0.");
                    e.Cancel = true;
                    return;
                }

                DetalleVenta detalleActual = carrito[e.RowIndex];
                
                // Calcular stock real disponible considerando otros productos del mismo tipo en el carrito
                int cantidadOtrosEnCarrito = 0;
                for (int i = 0; i < carrito.Count; i++)
                {
                    if (i != e.RowIndex && carrito[i].IdArticulo == detalleActual.IdArticulo)
                    {
                        cantidadOtrosEnCarrito += carrito[i].Cantidad;
                    }
                }
                
                // Obtener stock original del artículo
                int stockOriginal = 0;
                foreach (DataGridViewRow fila in dgvArticulos.Rows)
                {
                    if ((int)fila.Cells["Id"].Value == detalleActual.IdArticulo)
                    {
                        stockOriginal = (int)fila.Cells["Stock"].Value;
                        break;
                    }
                }
                
                int stockDisponibleReal = stockOriginal - cantidadOtrosEnCarrito;
                
                if (nuevaCantidad > stockDisponibleReal)
                {
                    MessageBox.Show($"La cantidad no puede ser mayor al stock disponible ({stockDisponibleReal}). Ya tienes {cantidadOtrosEnCarrito} unidades de este artículo en otras líneas del carrito.");
                    e.Cancel = true;
                }
            }
        }

        private void dgvCarrito_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCarrito.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                DetalleVenta detalle = carrito[e.RowIndex];
                int nuevaCantidad = Convert.ToInt32(dgvCarrito.Rows[e.RowIndex].Cells["Cantidad"].Value);
                
                detalle.Cantidad = nuevaCantidad;
                detalle.CalcularSubtotal();
                
                // Actualizar la celda del subtotal
                dgvCarrito.Rows[e.RowIndex].Cells["Subtotal"].Value = detalle.Subtotal;
                
                // Restaurar colores normales después de editar
                dgvCarrito.Rows[e.RowIndex].Cells["Cantidad"].Style.BackColor = Color.Empty;
                dgvCarrito.Rows[e.RowIndex].Cells["Cantidad"].Style.SelectionBackColor = Color.Empty;
                
                calcularTotal();
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cerrar la sesión?", 
                "Cerrar Sesión", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Close();
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
