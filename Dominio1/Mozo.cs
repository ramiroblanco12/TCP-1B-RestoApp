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
        public string NombreCompleto { get; set; }
=======

        public string NombreApellido { get; set; }

        public string NombreCompleto { get; set; }



>>>>>>> 743aa24ce6c5d0f88d63f01e32d1c3e5b7aba365
        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
