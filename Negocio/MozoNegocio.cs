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
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Id,Nombre ,Descripcion, Precio, CantidadDisp From Productos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.CantidadDisp = (int)datos.Lector["CantidadDisp"];

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


        public void agregarConSP(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("spAltaMozo");
                datos.setearParametro("@nombre", nuevo.Nombre);

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

        public void modificarConSP(Producto prod)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("spModificarMozo");
                datos.setearParametro("@nombre", prod.Nombre);
                datos.setearParametro("@id", prod.Id);

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
