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
            try
            {
                // Crear controles dinámicos para entrada inline
                TextBox txtNuevaCategoria = new TextBox();
                txtNuevaCategoria.Location = new System.Drawing.Point(620, 200);
                txtNuevaCategoria.Size = new System.Drawing.Size(200, 23);
                txtNuevaCategoria.Font = new System.Drawing.Font("Verdana", 9.75F);
                txtNuevaCategoria.BackColor = System.Drawing.Color.FromArgb(242, 227, 213);
                txtNuevaCategoria.ForeColor = System.Drawing.Color.FromArgb(1, 46, 64);
                txtNuevaCategoria.Name = "txtNuevaCategoria";

                Label lblNuevaCategoria = new Label();
                lblNuevaCategoria.Text = "Nueva Categoría:";
                lblNuevaCategoria.Location = new System.Drawing.Point(620, 180);
                lblNuevaCategoria.Size = new System.Drawing.Size(150, 16);
                lblNuevaCategoria.Font = new System.Drawing.Font("Verdana", 9.75F);
                lblNuevaCategoria.ForeColor = System.Drawing.Color.FromArgb(242, 227, 213);
                lblNuevaCategoria.BackColor = System.Drawing.Color.Transparent;
                lblNuevaCategoria.Name = "lblNuevaCategoria";

                Button btnGuardar = new Button();
                btnGuardar.Text = "Guardar";
                btnGuardar.Location = new System.Drawing.Point(620, 235);
                btnGuardar.Size = new System.Drawing.Size(90, 28);
                btnGuardar.Font = new System.Drawing.Font("Verdana", 9.75F);
                btnGuardar.BackColor = System.Drawing.Color.FromArgb(1, 46, 64);
                btnGuardar.ForeColor = System.Drawing.Color.FromArgb(242, 227, 213);
                btnGuardar.FlatStyle = FlatStyle.Flat;
                btnGuardar.Name = "btnGuardar";

                Button btnCancelarInline = new Button();
                btnCancelarInline.Text = "Cancelar";
                btnCancelarInline.Location = new System.Drawing.Point(720, 235);
                btnCancelarInline.Size = new System.Drawing.Size(90, 28);
                btnCancelarInline.Font = new System.Drawing.Font("Verdana", 9.75F);
                btnCancelarInline.BackColor = System.Drawing.Color.FromArgb(2, 103, 115);
                btnCancelarInline.ForeColor = System.Drawing.Color.FromArgb(242, 227, 213);
                btnCancelarInline.FlatStyle = FlatStyle.Flat;
                btnCancelarInline.Name = "btnCancelarInline";

                // Agregar controles al formulario
                this.Controls.Add(txtNuevaCategoria);
                this.Controls.Add(lblNuevaCategoria);
                this.Controls.Add(btnGuardar);
                this.Controls.Add(btnCancelarInline);

                // Eventos
                btnGuardar.Click += (s, ev) => {
                    try
                    {
                        if (!string.IsNullOrWhiteSpace(txtNuevaCategoria.Text))
                        {
                            Categoria nueva = new Categoria();
                            nueva.descripcion = txtNuevaCategoria.Text.Trim();
                            negocio.agregar(nueva);
                            cargarCategorias();
                            
                            // Remover controles
                            this.Controls.Remove(txtNuevaCategoria);
                            this.Controls.Remove(lblNuevaCategoria);
                            this.Controls.Remove(btnGuardar);
                            this.Controls.Remove(btnCancelarInline);
                            
                            MessageBox.Show("Categoría agregada correctamente", "Éxito");
                        }
                        else
                        {
                            MessageBox.Show("Ingrese una descripción para la categoría", "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                };

                btnCancelarInline.Click += (s, ev) => {
                    // Remover controles
                    this.Controls.Remove(txtNuevaCategoria);
                    this.Controls.Remove(lblNuevaCategoria);
                    this.Controls.Remove(btnGuardar);
                    this.Controls.Remove(btnCancelarInline);
                };

                txtNuevaCategoria.Focus();
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
                if (dgvCategorias.CurrentRow != null)
                {
                    Categoria seleccionado = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    
                    // Crear controles dinámicos para edición inline
                    TextBox txtEditarCategoria = new TextBox();
                    txtEditarCategoria.Location = new System.Drawing.Point(620, 200);
                    txtEditarCategoria.Size = new System.Drawing.Size(200, 23);
                    txtEditarCategoria.Font = new System.Drawing.Font("Verdana", 9.75F);
                    txtEditarCategoria.BackColor = System.Drawing.Color.FromArgb(242, 227, 213);
                    txtEditarCategoria.ForeColor = System.Drawing.Color.FromArgb(1, 46, 64);
                    txtEditarCategoria.Text = seleccionado.descripcion;
                    txtEditarCategoria.Name = "txtEditarCategoria";

                    Label lblEditarCategoria = new Label();
                    lblEditarCategoria.Text = "Editar Categoría:";
                    lblEditarCategoria.Location = new System.Drawing.Point(620, 180);
                    lblEditarCategoria.Size = new System.Drawing.Size(150, 16);
                    lblEditarCategoria.Font = new System.Drawing.Font("Verdana", 9.75F);
                    lblEditarCategoria.ForeColor = System.Drawing.Color.FromArgb(242, 227, 213);
                    lblEditarCategoria.BackColor = System.Drawing.Color.Transparent;
                    lblEditarCategoria.Name = "lblEditarCategoria";

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
                    this.Controls.Add(txtEditarCategoria);
                    this.Controls.Add(lblEditarCategoria);
                    this.Controls.Add(btnGuardarEdicion);
                    this.Controls.Add(btnCancelarEdicion);

                    // Eventos
                    btnGuardarEdicion.Click += (s, ev) => {
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(txtEditarCategoria.Text))
                            {
                                seleccionado.descripcion = txtEditarCategoria.Text.Trim();
                                negocio.modificar(seleccionado);
                                cargarCategorias();
                                
                                // Remover controles
                                this.Controls.Remove(txtEditarCategoria);
                                this.Controls.Remove(lblEditarCategoria);
                                this.Controls.Remove(btnGuardarEdicion);
                                this.Controls.Remove(btnCancelarEdicion);
                                
                                MessageBox.Show("Categoría modificada correctamente", "Éxito");
                            }
                            else
                            {
                                MessageBox.Show("Ingrese una descripción para la categoría", "Error");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    };

                    btnCancelarEdicion.Click += (s, ev) => {
                        // Remover controles
                        this.Controls.Remove(txtEditarCategoria);
                        this.Controls.Remove(lblEditarCategoria);
                        this.Controls.Remove(btnGuardarEdicion);
                        this.Controls.Remove(btnCancelarEdicion);
                    };

                    txtEditarCategoria.Focus();
                    txtEditarCategoria.SelectAll();
                }
                else
                {
                    MessageBox.Show("Seleccione una categoría para editar", "Editar Categoría");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
