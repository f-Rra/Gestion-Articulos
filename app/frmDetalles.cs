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
    public partial class frmDetalles : Form
    {
        private Articulo articulo = null;
        private ArticuloNegocio neg = new ArticuloNegocio();

        public frmDetalles()
        {
            InitializeComponent();
        }

        public frmDetalles(Articulo aux)
        {
            InitializeComponent();
            this.articulo = aux;
            cargarDetalles(aux);
        }

        private void cargarDetalles(Articulo aux)
        {
            lblID.Text = " " + aux.id.ToString();
            lblCodigo.Text = " " + aux.codigo;
            lblNombre.Text = " " + aux.nombre;
            lblDescripcion.Text = " " + aux.descripcion;
            lblPrecio.Text = " " + aux.precio.ToString("C", CultureInfo.CreateSpecificCulture("es-AR"));
            lblURL.Text = " " + aux.urlImagen;
            acortarURL(lblURL.Text);
            cargarImagen(aux.urlImagen);
            lblCategoria.Text = " " + aux.categoria.descripcion;
            lblMarca.Text = " " + aux.marca.descripcion;
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

        private void acortarURL(string URL)
        {
            int maxLength = 50; 
            if (URL.Length > maxLength)
            {
                lblURL.Text = URL.Substring(0, maxLength) + "...";
            }
            else
            {
                lblURL.Text = URL;
            }
        }
        private void btnListado_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
