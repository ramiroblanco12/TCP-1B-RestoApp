using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MozoNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        //public bool CrearMesa(Mozo Mozo)
        //{
        //    try
        //    {
        //        datos.setearConsulta("Select Id, Nombre, Apellido FROM Mozos where Id = @Id AND Nombre = @Nombre AND Apellido = @Apellido");
        //        datos.setearParametro("@Id", Mozo.Id);
        //        datos.setearParametro("@Nombre", Mozo.NombreApellido);
        //        datos.setearParametro("@Apellido", Mozo.Apellido);

        //        datos.ejecutarLectura();
        //        while (datos.Lector.Read())
        //        {

        //            Mozo.Id = (int)datos.Lector["Id"];
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }

        //}




    }
}
