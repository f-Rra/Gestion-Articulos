using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using Dominio;
using Negocio;

namespace app
{
    public partial class frmDatos : Form
    {
        private Articulo articulo = null;
        private ArticuloNegocio neg = new ArticuloNegocio();
        private MarcaNegocio negM = new MarcaNegocio();
        private CategoriaNegocio negC = new CategoriaNegocio();

        public frmDatos()
        {
            InitializeComponent();
        }

        public frmDatos(Articulo aux)
        {
            InitializeComponent();
            this.articulo = aux;
            Text = "Modificar Articulo";
            btnAgregar.Text = "Modificar Articulo";
        }

        private void frmAgregar_Load(object sender, EventArgs e)
        {
            try
            {
                cargarMarcas();
                cargarCategorias();
                txtID.Text = neg.ultimoID().ToString();
                if (articulo != null)
                {
                    cargarArticulo();
                }
                else
                {
                    // Inicializar Stock con valor por defecto para artículos nuevos
                    txtStock.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarCampos())
                {
                    MessageBox.Show("Complete todos los campos","Error");
                    return;
                }
                if (articulo == null)
                {
                    articulo = new Articulo();
                    asignarDatos();
                }
                asignarDatos();
                if (articulo.id != 0)
                {
                    neg.modificar(articulo);
                    MessageBox.Show("Articulo modificado exitosamente");
                }
                else
                {
                    neg.agregar(articulo);
                    MessageBox.Show("Articulo agregado exitosamente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            cargarImagen(txtURL.Text);
        }

        private void asignarDatos()
        {
            
            articulo.codigo = txtCodigo.Text;
            articulo.nombre = txtNombre.Text;
            articulo.descripcion = txtDescripcion.Text;
            articulo.urlImagen = txtURL.Text;
            articulo.marca = (Marca)cboMarca.SelectedItem;
            articulo.categoria = (Categoria)cboCategoria.SelectedItem;
            articulo.precio = decimal.Parse(txtPrecio.Text, CultureInfo.InvariantCulture);
            articulo.stock = int.Parse(txtStock.Text);
        }

        private void cargarArticulo()
        {
            txtCodigo.Text = articulo.codigo;
            txtNombre.Text = articulo.nombre;
            txtDescripcion.Text = articulo.descripcion;
            txtURL.Text = articulo.urlImagen;
            cboMarca.SelectedValue = articulo.marca.id;
            cboCategoria.SelectedValue = articulo.categoria.id;
            txtPrecio.Text = articulo.precio.ToString(CultureInfo.InvariantCulture);
            txtStock.Text = articulo.stock.ToString();
            cargarImagen(articulo.urlImagen);
            txtID.Text = articulo.id.ToString();
        }

        private void cargarMarcas()
        {
            cboMarca.DataSource = negM.listar();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Descripcion";
        }

        private void cargarCategorias()
        {
            cboCategoria.DataSource = negC.listar();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Descripcion";
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagen.Image = Properties.Resources.not_available;
            }
        }
        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
                return false;
            if (!soloPrecio(txtPrecio.Text))
            {
                MessageBox.Show("Solo se permiten numeros y puntos(.) en el campo precio", "Error en el ingreso");
                return false;
            }
            if (!soloNumeros(txtStock.Text))
            {
                MessageBox.Show("Solo se permiten numeros enteros en el campo stock", "Error en el ingreso");
                return false;
            }
            int stock = int.Parse(txtStock.Text);
            if (stock < 0)
            {
                MessageBox.Show("El stock no puede ser negativo", "Error en el ingreso");
                return false;
            }
            return true;
        }

        private bool soloPrecio(string cadena)
        {
            bool encontrado = false;
            foreach (char caracter in cadena)
            {
                if (char.IsDigit(caracter))
                {
                    continue;
                }
                if (caracter == '.')
                {
                    if (encontrado) return false;
                    encontrado = true;
                    continue;
                }
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permitir números y teclas de control (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
