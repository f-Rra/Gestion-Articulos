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
    public partial class frmStock : Form
    {
        private List<Articulo> listadoArticulos;
        private ArticuloNegocio neg = new ArticuloNegocio();

        public frmStock()
        {
            InitializeComponent();
        }

        private void frmStock_Load(object sender, EventArgs e)
        {
            cargarArticulos();
            limpiarCampos();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                txtArticuloSeleccionado.Text = $"{seleccionado.codigo} - {seleccionado.nombre}";
                txtStockActual.Text = seleccionado.stock.ToString();
                txtCantidad.Text = "";
                txtCantidad.Focus();
            }
        }

        private void cboTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTipoOperacion.SelectedItem.ToString())
            {
                case "Sumar":
                    lblDescripcionOperacion.Text = "Agregar stock al inventario";
                    break;
                case "Restar":
                    lblDescripcionOperacion.Text = "Reducir stock del inventario";
                    break;
                case "Ajustar":
                    lblDescripcionOperacion.Text = "Establecer stock exacto";
                    break;
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarOperacion()) return;

                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                int cantidad = int.Parse(txtCantidad.Text);
                string tipoOperacion = cboTipoOperacion.SelectedItem.ToString();

                switch (tipoOperacion)
                {
                    case "Sumar":
                        neg.sumarStock(seleccionado.id, cantidad);
                        MessageBox.Show("Stock Agregado Correctamente", "");
                        break;
                    case "Restar":
                        neg.restarStock(seleccionado.id, cantidad);
                        MessageBox.Show("Stock Restado Correctamente", "");
                        break;
                    case "Ajustar":
                        neg.actualizarStock(seleccionado.id, cantidad);
                        MessageBox.Show("Stock Ajustado Correctamente", "");
                        break;
                }

                cargarArticulos();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en la operación");
            }
        }

        private void btnBajoStock_Click(object sender, EventArgs e)
        {
            try
            {
                int stockMinimo = (int)nudStockMinimo.Value;
                var articulosBajoStock = neg.obtenerArticulosBajoStock(stockMinimo);
                dgvArticulos.DataSource = articulosBajoStock;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSinStock_Click(object sender, EventArgs e)
        {
            try
            {
                var articulosSinStock = neg.obtenerArticulosSinStock();
                dgvArticulos.DataSource = articulosSinStock;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            cargarArticulos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void cargarArticulos()
        {
            try
            {
                listadoArticulos = neg.listar();
                dgvArticulos.DataSource = listadoArticulos;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["UrlImagen"].Visible = false;
            dgvArticulos.Columns["Precio"].Visible = false;

            if (dgvArticulos.Columns["Stock"] != null)
            {
                dgvArticulos.Columns["Stock"].Width = 80;
                dgvArticulos.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvArticulos.Columns["EstadoStock"] != null)
            {
                dgvArticulos.Columns["EstadoStock"].Width = 100;
                dgvArticulos.Columns["EstadoStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void limpiarCampos()
        {
            txtArticuloSeleccionado.Text = "";
            txtStockActual.Text = "";
            txtCantidad.Text = "";
            cboTipoOperacion.SelectedIndex = 0;
        }

        private bool validarOperacion()
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo de la lista", "Error");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Ingrese la cantidad", "Error");
                return false;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Ingrese una cantidad válida mayor a 0", "Error");
                return false;
            }

            return true;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!char.IsDigit(caracter))
                    return false;
            }
            return true;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
