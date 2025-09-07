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
    public partial class frmLogin : Form
    {
        public Usuario UsuarioLogueado { get; set; }

        public frmLogin()
        {
            InitializeComponent();
            txtUsuario.Text = " 👤 ";
            txtContrasena.Text = " 🔑 ";        
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    UsuarioNegocio negocio = new UsuarioNegocio();
                    UsuarioLogueado = negocio.validarCredenciales(txtUsuario.Text, txtContrasena.Text);

                    if (UsuarioLogueado != null)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error de Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtContrasena.Clear();
                        txtUsuario.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar un usuario", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return false;
            }

            return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
        }

        private void txtContrasena_Click(object sender, EventArgs e)
        {
            txtContrasena.Text = "";
            txtContrasena.UseSystemPasswordChar = true;
        }
    }
}