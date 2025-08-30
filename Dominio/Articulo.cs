using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int id { get; set; }

        [DisplayName("Codigo")]
        public string codigo { get; set;}

        [DisplayName(" Nombre")]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        [DisplayName(" Categoria")]
        public Categoria categoria { get; set; }

        [DisplayName(" Marca")]
        public Marca marca { get; set; }

        public string urlImagen { get; set; }

        private decimal _precio;

        public decimal precio 
        {
            get { return _precio; }
            set { _precio = value; }
        }

        [DisplayName(" Precio")]
        public string precioF
        {
            get { return _precio.ToString("C", CultureInfo.CreateSpecificCulture("es-AR"));}
        }
    }
}
