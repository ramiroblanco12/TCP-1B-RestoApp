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
        public List<Mozo> listar()
        {
            List<Mozo> lista = new List<Mozo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id,NombreCompleto From Mozos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Mozo aux = new Mozo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.NombreCompleto = (string)datos.Lector["NombreCompleto"];

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
                datos.setearConsulta("Delete From Mozo where Id =" + id);
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
