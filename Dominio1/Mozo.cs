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
=======
        public string NombreCompleto { get; set; }
       
>>>>>>> 6b587513489e30c19cfb65f5e8a959b6b368ecf7
        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
