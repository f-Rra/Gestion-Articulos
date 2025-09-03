using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace app
{
    public partial class frmDatosMarca : Form
    {
        private Marca marca = null;
        private MarcaNegocio negocio = new MarcaNegocio();

        public frmDatosMarca()
        {
            InitializeComponent();
        }

        public frmDatosMarca(Marca aux)
        {
            InitializeComponent();
            this.marca = aux;
            Text = "Modificar Marca";
            btnAgregar.Text = "Modificar Marca";
        }

        private void frmDatosMarca_Load(object sender, EventArgs e)
        {
            try
            {
                if (marca != null)
                {
                    cargarMarca();
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

                if (marca == null)
                {
                    marca = new Marca();
                }

                asignarDatos();

                if (marca.id != 0)
                {
                    negocio.modificar(marca);
                    MessageBox.Show("Marca modificada exitosamente");
                }
                else
                {
                    negocio.agregar(marca);
                    MessageBox.Show("Marca agregada exitosamente");
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

        private void cargarMarca()
        {
            txtDescripcion.Text = marca.descripcion;
        }

        private void asignarDatos()
        {
            marca.descripcion = txtDescripcion.Text;
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
