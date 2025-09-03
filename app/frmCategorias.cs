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
    public partial class frmCategorias : Form
    {
        private List<Categoria> listaCategorias;
        private CategoriaNegocio negocio;

        public frmCategorias()
        {
            InitializeComponent();
            negocio = new CategoriaNegocio();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargarCategorias();
            ocultarColumnas();
        }

        private void cargarCategorias()
        {
            try
            {
                listaCategorias = negocio.listar();
                dgvCategorias.DataSource = listaCategorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ocultarColumnas()
        {
            if (dgvCategorias.Columns.Count > 0)
            {
                dgvCategorias.Columns["Id"].HeaderText = "ID";
                dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDatosCategoria agregar = new frmDatosCategoria();
            agregar.ShowDialog();
            cargarCategorias();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                frmDatosCategoria modificar = new frmDatosCategoria(seleccionada);
                modificar.ShowDialog();
                cargarCategorias();
            }
            else
            {
                MessageBox.Show("Seleccione una categoría de la lista", "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow != null)
            {
                Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                realizarBajaLogica(seleccionada);
            }
            else
            {
                MessageBox.Show("Seleccione una categoría de la lista", "Error");
            }
        }

        private void realizarBajaLogica(Categoria categoria)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar la categoría: " + categoria.descripcion + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    negocio.eliminar(categoria.id);
                    MessageBox.Show("Categoría eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFiltro.Text))
                {
                    cargarCategorias();
                }
                else
                {
                    string filtro = txtFiltro.Text.ToLower();
                    var categoriasFiltradas = listaCategorias.Where(c => 
                        c.descripcion.ToLower().Contains(filtro)).ToList();
                    dgvCategorias.DataSource = categoriasFiltradas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            btnBuscar_Click(sender, e);
        }
    }
}
