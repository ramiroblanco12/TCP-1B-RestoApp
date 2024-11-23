using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacionResto
{
    public class ProductoPedido
    {
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal => Precio * Cantidad;

    }
}