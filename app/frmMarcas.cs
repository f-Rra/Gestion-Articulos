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
            try
            {
                Marca nueva = new Marca();
                nueva.descripcion = txtAgregar.Text.Trim();
                negocio.agregar(nueva);
                cargarMarcas();
                MessageBox.Show("Marca agregada correctamente", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMarcas.CurrentRow != null)
                {
                    Marca seleccionado = (Marca)dgvMarcas.CurrentRow.DataBoundItem;
                    
                    // Crear controles dinámicos para edición inline
                    TextBox txtEditarMarca = new TextBox();
                    txtEditarMarca.Location = new System.Drawing.Point(620, 200);
                    txtEditarMarca.Size = new System.Drawing.Size(200, 23);
                    txtEditarMarca.Font = new System.Drawing.Font("Verdana", 9.75F);
                    txtEditarMarca.BackColor = System.Drawing.Color.FromArgb(242, 227, 213);
                    txtEditarMarca.ForeColor = System.Drawing.Color.FromArgb(1, 46, 64);
                    txtEditarMarca.Text = seleccionado.descripcion;
                    txtEditarMarca.Name = "txtEditarMarca";

                    Label lblEditarMarca = new Label();
                    lblEditarMarca.Text = "Editar Marca:";
                    lblEditarMarca.Location = new System.Drawing.Point(620, 180);
                    lblEditarMarca.Size = new System.Drawing.Size(150, 16);
                    lblEditarMarca.Font = new System.Drawing.Font("Verdana", 9.75F);
                    lblEditarMarca.ForeColor = System.Drawing.Color.FromArgb(242, 227, 213);
                    lblEditarMarca.BackColor = System.Drawing.Color.Transparent;
                    lblEditarMarca.Name = "lblEditarMarca";

                    Button btnGuardarEdicion = new Button();
                    btnGuardarEdicion.Text = "Guardar";
                    btnGuardarEdicion.Location = new System.Drawing.Point(620, 235);
                    btnGuardarEdicion.Size = new System.Drawing.Size(90, 28);
                    btnGuardarEdicion.Font = new System.Drawing.Font("Verdana", 9.75F);
                    btnGuardarEdicion.BackColor = System.Drawing.Color.FromArgb(1, 46, 64);
                    btnGuardarEdicion.ForeColor = System.Drawing.Color.FromArgb(242, 227, 213);
                    btnGuardarEdicion.FlatStyle = FlatStyle.Flat;
                    btnGuardarEdicion.Name = "btnGuardarEdicion";

                    Button btnCancelarEdicion = new Button();
                    btnCancelarEdicion.Text = "Cancelar";
                    btnCancelarEdicion.Location = new System.Drawing.Point(720, 235);
                    btnCancelarEdicion.Size = new System.Drawing.Size(90, 28);
                    btnCancelarEdicion.Font = new System.Drawing.Font("Verdana", 9.75F);
                    btnCancelarEdicion.BackColor = System.Drawing.Color.FromArgb(2, 103, 115);
                    btnCancelarEdicion.ForeColor = System.Drawing.Color.FromArgb(242, 227, 213);
                    btnCancelarEdicion.FlatStyle = FlatStyle.Flat;
                    btnCancelarEdicion.Name = "btnCancelarEdicion";

                    // Agregar controles al formulario
                    this.Controls.Add(txtEditarMarca);
                    this.Controls.Add(lblEditarMarca);
                    this.Controls.Add(btnGuardarEdicion);
                    this.Controls.Add(btnCancelarEdicion);

                    // Eventos
                    btnGuardarEdicion.Click += (s, ev) => {
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(txtEditarMarca.Text))
                            {
                                seleccionado.descripcion = txtEditarMarca.Text.Trim();
                                negocio.modificar(seleccionado);
                                cargarMarcas();
                                
                                // Remover controles
                                this.Controls.Remove(txtEditarMarca);
                                this.Controls.Remove(lblEditarMarca);
                                this.Controls.Remove(btnGuardarEdicion);
                                this.Controls.Remove(btnCancelarEdicion);
                                
                                MessageBox.Show("Marca modificada correctamente", "Éxito");
                            }
                            else
                            {
                                MessageBox.Show("Ingrese una descripción para la marca", "Error");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    };

                    btnCancelarEdicion.Click += (s, ev) => {
                        // Remover controles
                        this.Controls.Remove(txtEditarMarca);
                        this.Controls.Remove(lblEditarMarca);
                        this.Controls.Remove(btnGuardarEdicion);
                        this.Controls.Remove(btnCancelarEdicion);
                    };

                    txtEditarMarca.Focus();
                    txtEditarMarca.SelectAll();
                }
                else
                {
                    MessageBox.Show("Seleccione una marca para editar", "Editar Marca");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
