using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Mozo
    {

        public int Id { get; set; }
        public string NombreApellido { get; set; }
        public override string ToString()
        {
            return NombreApellido;
        }
    }
}
