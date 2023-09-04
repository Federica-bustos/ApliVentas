using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApliVentas.BD.Data.Entity
{
    public class PrecioFinal
    {
        public int id { get; set; }

        public Producto Producto { get; set; }

        public DateTime fecha { get; set; }

        public int precioFinal { get; set; }

    }
}
