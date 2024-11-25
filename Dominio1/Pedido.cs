using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int Id { get; set; }
        public int IdMozo { get; set; }
        public int IdMesa { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public List<ProductoPedido> Productos { get; set; }

    }
}
