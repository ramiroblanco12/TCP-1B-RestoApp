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
     
        
        public List<Mozo> listar()
        {
            List<Mozo> lista = new List<Mozo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id,NombreCompleto,Activo From Mozos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mozo aux = new Mozo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];
                    //aux.Activo = (bool)datos.Lector["Activo"];
                    //if (aux.Activo) { 
                    //}
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


        public void agregarConSP(Mozo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spAltaMozo");
                datos.setearParametro("@nombre", nuevo.NombreCompleto);

                datos.ejecutarAccion();
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

        public void modificarConSP(Mozo mozo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spModificarMozo");
                datos.setearParametro("@nombre", mozo.NombreCompleto);
                datos.setearParametro("@id", mozo.Id);

                datos.ejecutarAccion();
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
        public void eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
           
            try
            {
                string consulta = "UPDATE Mozo SET Activo = 0 WHERE Id = " + id;
                datos.setearConsulta(consulta);
           
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                
                datos = null;
            }
        }




    }
}
