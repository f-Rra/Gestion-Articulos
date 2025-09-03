using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace app
{
    public partial class frmDatosCategoria : Form
    {
        private Categoria categoria = null;
        private CategoriaNegocio negocio = new CategoriaNegocio();

        public frmDatosCategoria()
        {
            InitializeComponent();
        }

        public frmDatosCategoria(Categoria aux)
        {
            InitializeComponent();
            this.categoria = aux;
            Text = "Modificar Categoría";
            btnAgregar.Text = "Modificar Categoría";
        }

        private void frmDatosCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                if (categoria != null)
                {
                    cargarCategoria();
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
                    MessageBox.Show("Complete todos los campos", "Error");
                    return;
                }

                if (categoria == null)
                {
                    categoria = new Categoria();
                }

                asignarDatos();

                if (categoria.id != 0)
                {
                    negocio.modificar(categoria);
                    MessageBox.Show("Categoría modificada exitosamente");
                }
                else
                {
                    negocio.agregar(categoria);
                    MessageBox.Show("Categoría agregada exitosamente");
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
            Close();
        }

        private void cargarCategoria()
        {
            txtDescripcion.Text = categoria.descripcion;
        }

        private void asignarDatos()
        {
            categoria.descripcion = txtDescripcion.Text;
        }

        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                return false;
            }
            return true;
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text.Length > 50)
            {
                MessageBox.Show("La descripción no puede superar los 50 caracteres", "Error");
                txtDescripcion.Focus();
            }
        }
    }
}
