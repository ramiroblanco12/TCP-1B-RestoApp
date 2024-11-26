﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PedidoNegocio
    {

        public void agregarPedido(Pedido nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Agregar el pedido principal
                datos.setearConsulta("INSERT INTO Pedidos (Fecha, Mozo_id, Mesa_id, Monto) OUTPUT INSERTED.Id VALUES (@Fecha, @MozoId, @MesaId, @Monto)");
                datos.setearParametro("@Fecha", nuevo.Fecha);
                datos.setearParametro("@MozoId", nuevo.IdMozo);
                datos.setearParametro("@MesaId", nuevo.IdMesa);
                datos.setearParametro("@Monto", nuevo.Monto);

                // Obtener el ID del pedido generado
                datos.ejecutarLectura();
                int pedidoId = 0;
                if (datos.Lector.Read())
                {
                    pedidoId = (int)datos.Lector[0];
                }
                datos.cerrarConexion();

                // Agregar los productos relacionados al pedido
                foreach (var producto in nuevo.Productos)
                {
                    AccesoDatos datosProductos = new AccesoDatos();
                    try
                    {
                        datosProductos.setearConsulta("INSERT INTO pedido_productos (pedido_id, producto_id, cantidad) VALUES (@PedidoId, @ProductoId, @Cantidad)");
                        datosProductos.setearParametro("@PedidoId", pedidoId);
                        datosProductos.setearParametro("@ProductoId", producto.IdProducto);
                        datosProductos.setearParametro("@Cantidad", producto.Cantidad);
                        datosProductos.ejecutarAccion();
                    }
                    finally
                    {
                        datosProductos.cerrarConexion();
                    }
                }
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

        public List<Pedido> listar()
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, Fecha, Mozo_id, Mesa_id, Monto FROM Pedidos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pedido aux = new Pedido
                    {
                        Id = (int)datos.Lector["Id"],
                        Fecha = (DateTime)datos.Lector["Fecha"],
                        IdMozo = (int)datos.Lector["Mozo_id"],
                        IdMesa = (int)datos.Lector["Mesa_id"],
                        Monto = (decimal)datos.Lector["Monto"]
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

        public List<ProductoPedido> obtenerDetallePedido(int pedidoId)
        {
            List<ProductoPedido> lista = new List<ProductoPedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"SELECT pp.producto_id, p.Nombre, pp.cantidad, p.Precio 
                               FROM pedido_productos pp 
                               INNER JOIN Productos p ON pp.producto_id = p.Id
                               WHERE pp.pedido_id = @pedidoId");
                datos.setearParametro("@pedidoId", pedidoId);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ProductoPedido detalle = new ProductoPedido
                    {
                        IdProducto = (int)datos.Lector["producto_id"], 
                        NombreProducto = (string)datos.Lector["Nombre"],
                        Cantidad = (int)datos.Lector["cantidad"],
                        Precio = (decimal)datos.Lector["Precio"]
                    };

                    lista.Add(detalle);
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
