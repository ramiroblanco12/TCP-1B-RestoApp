using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal class MesaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public bool CrearMesa(Mesa Mesa)
        {
            try
            {
                datos.setearConsulta("Select Id, Numero, Capacidad  FROM Mesas where Id = @Id AND Numero = @Numero AND Capacidad = @Capacidad");
                datos.setearParametro("@Id", Mesa.Id);
                datos.setearParametro("@Numero",Mesa.Numero );
                datos.setearParametro("@Capacidad", Mesa.Capacidad);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Mesa.Id = (int)datos.Lector["Id"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }



    }
}
