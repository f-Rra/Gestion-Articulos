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
    public partial class frmMarcas : Form
    {
        private List<Marca> listaMarcas;
        private MarcaNegocio negocio;

        public frmMarcas()
        {
            InitializeComponent();
            negocio = new MarcaNegocio();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargarMarcas();
            ocultarColumnas();
        }

        private void cargarMarcas()
        {
            try
            {
                listaMarcas = negocio.listar();
                dgvMarcas.DataSource = listaMarcas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar marcas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ocultarColumnas()
        {
            if (dgvMarcas.Columns.Count > 0)
            {
                dgvMarcas.Columns["Id"].HeaderText = "ID";
                dgvMarcas.Columns["Descripcion"].HeaderText = "Descripción";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmDatosMarca agregar = new frmDatosMarca();
            agregar.ShowDialog();
            cargarMarcas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                frmDatosMarca modificar = new frmDatosMarca(seleccionada);
                modificar.ShowDialog();
                cargarMarcas();
            }
            else
            {
                MessageBox.Show("Seleccione una marca de la lista", "Error");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMarcas.CurrentRow != null)
            {
                Marca seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                realizarBajaLogica(seleccionada);
            }
            else
            {
                MessageBox.Show("Seleccione una marca de la lista", "Error");
            }
        }

        private void realizarBajaLogica(Marca marca)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea eliminar la marca: " + marca.descripcion + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    negocio.eliminar(marca.id);
                    MessageBox.Show("Marca eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarMarcas();
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
                    cargarMarcas();
                }
                else
                {
                    string filtro = txtFiltro.Text.ToLower();
                    var marcasFiltradas = listaMarcas.Where(m => 
                        m.descripcion.ToLower().Contains(filtro)).ToList();
                    dgvMarcas.DataSource = marcasFiltradas;
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
