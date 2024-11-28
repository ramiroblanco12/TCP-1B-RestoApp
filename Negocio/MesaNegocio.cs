using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MesaNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public bool CrearMesa(Mesa Mesa)
        {
            try
            {
                datos.setearConsulta("Select Id, Numero, Capacidad  FROM Mesas where Id = @Id AND Numero = @Numero AND Capacidad = @Capacidad");
                datos.setearParametro("@Id", Mesa.Id);
                datos.setearParametro("@Numero", Mesa.Numero);
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


        public List<Mesa> listar()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Numero,Capacidad,Mozo FROM Mesas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa
                    {
                        Id = (int)datos.Lector["Id"],
                        Numero = (int)datos.Lector["Numero"],
                        Capacidad = (int)datos.Lector["Capacidad"],
                        Mozo = (Mozo)datos.Lector["Mozo"]
                    };

                    lista.Add(aux);
                }

                return lista;
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
