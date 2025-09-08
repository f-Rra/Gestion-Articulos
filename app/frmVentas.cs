using System;
using System.Collections.Generic;
using System.Data;
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
        }

        private void configurarDataGridViews()
        {
            // Ocultar columnas en dgvArticulos
            if (dgvArticulos.Columns.Contains("Id"))
                dgvArticulos.Columns["Id"].Visible = false;
            if (dgvArticulos.Columns.Contains("Descripcion"))
                dgvArticulos.Columns["Descripcion"].Visible = false;
            if (dgvArticulos.Columns.Contains("EstadoStock"))
                dgvArticulos.Columns["EstadoStock"].Visible = false;
        }

        private void configurarCarrito()
        {
            // Ocultar columnas en dgvCarrito después de cargar datos
            if (dgvCarrito.Columns.Contains("Id"))
                dgvCarrito.Columns["Id"].Visible = false;
            if (dgvCarrito.Columns.Contains("IdVenta"))
                dgvCarrito.Columns["IdVenta"].Visible = false;
            if (dgvCarrito.Columns.Contains("IdArticulo"))
                dgvCarrito.Columns["IdArticulo"].Visible = false;
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

            DetalleVenta detalle = new DetalleVenta
            {
                IdArticulo = idArticulo,
                CodigoArticulo = codigo,
                NombreArticulo = nombre,
                PrecioUnitario = precio,
                Cantidad = 1,
                StockDisponible = stock
            };

            if (!detalle.StockSuficiente())
            {
                MessageBox.Show("Stock insuficiente.");
                return;
            }

            detalle.CalcularSubtotal();
            carrito.Add(detalle);

            refrescarCarrito();
            calcularTotal();
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


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
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
        }

        private void calcularTotal()
        {
            decimal total = 0;
            foreach (var d in carrito)
                total += d.Subtotal;

            lblTotal.Text = $"TOTAL: ${total:0.00}";
        }
    }
}
