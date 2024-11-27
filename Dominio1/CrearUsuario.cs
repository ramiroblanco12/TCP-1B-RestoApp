using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CrearUsuario
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public string Usuario { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento{ get; set; }
        public bool Admin { get; set; }

    }
}
