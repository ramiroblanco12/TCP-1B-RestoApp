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
<<<<<<< HEAD
        public string NombreApellido { get; set; }

        public string NombreCompleto { get; set; }
=======

        public string NombreCompleto { get; set; }
       
>>>>>>> 6d33f27840a1f3353da348a33df222ed9fdc6fba

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
