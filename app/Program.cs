using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Mostrar login primero
            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                // Si el login es exitoso, abrir formulario según rol
                if (login.UsuarioLogueado.EsAdministrador)
                {
                    // Admin: Panel administrativo
                    Application.Run(new frmAdmin(login.UsuarioLogueado));
                }
                else
                {
                    // Vendedor: Sistema de ventas
                   Application.Run(new frmVentas(login.UsuarioLogueado.NombreUsuario));
                }
            }

            // Si cancela login, la aplicación se cierra
        }
    }
}