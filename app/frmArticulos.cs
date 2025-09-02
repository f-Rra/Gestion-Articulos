using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Dominio;
using Negocio;

namespace app
{
    public partial class frmArticulos : Form
    {
        private List<Articulo> listadoArticulos;
        private ArticuloNegocio neg = new ArticuloNegocio();
        private MarcaNegocio negM = new MarcaNegocio();
        private CategoriaNegocio negC = new CategoriaNegocio();

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargarArticulos();
            cargarCBOs();
            ocultarColumnas();
            cargarImagen(listadoArticulos[0].urlImagen);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDatos agregar = new frmDatos();
            agregar.ShowDialog();
            cargarArticulos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmDatos modificar = new frmDatos(seleccionado);
                modificar.ShowDialog();
                cargarArticulos();
            }
            else
            {
                MessageBox.Show("Seleccione un articulo de la lista", "Error");
            }
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmDetalles detalles = new frmDetalles(seleccionado);
                detalles.ShowDialog();
                cargarArticulos();
            }
            else
            {
                MessageBox.Show("Seleccione un articulo de la lista", "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null) 
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                realizarBajaLogica(seleccionado);
            }
            else
            {
                MessageBox.Show("Seleccione un articulo de la lista", "Error");
            }

        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.urlImagen);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarFiltro()) return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltro.Text;

                if (campo == "Precio" && !soloNumeros(filtro))
                {
                    MessageBox.Show("Solo se permiten numeros", "Error en la busqueda");
                    return;
                }
                var resultados = neg.filtrar(campo, criterio, filtro);
                if (resultados == null || !resultados.Any())
                {
                    MessageBox.Show("No se encontraron articulos","Error en la busqueda");
                    dgvArticulos.DataSource = new List<Articulo>(); // Mostrar lista vacía
                }
                else
                {
                    dgvArticulos.DataSource = resultados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            cboCriterio.Items.Clear();

            if (opcion == "Precio")
            {
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
            if (cboCriterio.Items.Count > 0)
            {
                cboCriterio.SelectedIndex = 0;
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtFiltro.Text))
                {
                    cargarArticulos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void realizarBajaLogica(Articulo aux)
        {
            try
            {
                DialogResult res = MessageBox.Show("¿Realizar eliminacion fisica?", "Eliminando", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                   neg.bajaLogica(aux.id);
                   cargarArticulos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarArticulos()
        {
            try
            {
                listadoArticulos = neg.listar();
                dgvArticulos.DataSource = listadoArticulos;
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
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxArticulo.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulo.Image = Properties.Resources.not_available;
            }
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un campo para filtrar", "Error en la busqueda");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un criterio para filtrar", "Error en la busqueda");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltro.Text))
                {
                    MessageBox.Show("Ingrese un precio en el filtro","Error en la busqueda");
                    return true;
                }
                if (!soloNumeros(txtFiltro.Text))
                {
                    MessageBox.Show("Solo se permiten numeros en el filtro", "Error en la busqueda");
                    return true;
                }
            }
            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void cargarCBOs()
        {
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Precio");
            cboCriterio.Items.Add("Comienza con");
            cboCriterio.Items.Add("Termina con");
            cboCriterio.Items.Add("Contiene");
            cboCampo.SelectedIndex = 0;
            cboCriterio.SelectedIndex = 0;
        }
    }
}
