using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PedidoNegocio
    {
        public List<Pedido> listar()
        {
            List<Pedido> lista= new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {


                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        public void agregarPedido(Pedido nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearProcedimiento("spAltaProducto");
                //datos.setearParametro("@nombre", nuevo.Nombre);
                //datos.setearParametro("@desc", nuevo.Descripcion);
                //datos.setearParametro("@precio", nuevo.Precio);

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


    }
}
