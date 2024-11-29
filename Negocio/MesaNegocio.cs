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
        //public bool CrearMesa(Mesa Mesa)
        //{
        //    try
        //    {
        //        datos.setearConsulta("Select Id, Numero, Capacidad  FROM Mesas where Id = @Id AND Numero = @Numero AND Capacidad = @Capacidad");
        //        datos.setearParametro("@Id", Mesa.Id);
        //        datos.setearParametro("@Numero", Mesa.Numero);
        //        //datos.setearParametro("@Capacidad", Mesa.Capacidad);

        //        datos.ejecutarLectura();
        //        while (datos.Lector.Read())
        //        {

        //            Mesa.Id = (int)datos.Lector["Id"];
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


        public List<Mesa> listar()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Numero,IdMozo FROM Mesas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mesa aux = new Mesa
                    {
                        Id = (int)datos.Lector["Id"],
                        Numero = (int)datos.Lector["Numero"],
                        
                    };

                    int idMozo = (int)datos.Lector["IdMozo"];

                   
                        Mozo mozo = ObtenerMozoPorId(idMozo);
                        aux.Mozo = mozo;
                    
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
       private Mozo ObtenerMozoPorId(int idMozo)
        {
            AccesoDatos datos = new AccesoDatos();
            Mozo mozo = null;

            try
            {
                // Consulta para obtener el mozo por su Id
                datos.setearConsulta("SELECT Id, NombreCompleto FROM Mozos WHERE Id = @Id");
                datos.setearParametro("@Id", idMozo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    mozo = new Mozo
                    {
                        Id = (int)datos.Lector["Id"],
                        NombreCompleto = (string)datos.Lector["NombreCompleto"]
                    };
                }

                return mozo;
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
