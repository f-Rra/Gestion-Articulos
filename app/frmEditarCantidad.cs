using System;
using System.Windows.Forms;
using Dominio;

namespace app
{
    public partial class frmEditarCantidad : Form
    {
        public int NuevaCantidad { get; private set; }
        private DetalleVenta detalle;

        public frmEditarCantidad(DetalleVenta detalleVenta)
        {
            InitializeComponent();
            detalle = detalleVenta;
            
            // Configurar valores iniciales
            lblProducto.Text = $"Producto: {detalle.NombreArticulo}";
            lblStock.Text = $"Stock disponible: {detalle.StockDisponible}";
            lblPrecio.Text = $"Precio unitario: ${detalle.PrecioUnitario:0.00}";
            
            nudCantidad.Value = detalle.Cantidad;
            nudCantidad.Minimum = 1;
            nudCantidad.Maximum = detalle.StockDisponible;
            
            actualizarSubtotal();
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            actualizarSubtotal();
        }

        private void actualizarSubtotal()
        {
            decimal subtotal = (decimal)nudCantidad.Value * detalle.PrecioUnitario;
            lblSubtotal.Text = $"Subtotal: ${subtotal:0.00}";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            NuevaCantidad = (int)nudCantidad.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
