﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionResto
{
    public partial class Pedidos : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            MesaNegocio mesanegocio = new MesaNegocio();
            try
            {
                if (Session["usuario"] == null)
                {

                    Session.Add("error", "debes iniciar sesion para ingresar");
                    Response.Redirect("Default.aspx", false);



                }
                else
                {
                    if (!IsPostBack)
                    {
                        txtPrecio.Enabled = false;
                        List<Producto> listaProducto = negocio.listar();
                        List<Mesa> listaMesa = mesanegocio.listar();
                        Session["listaProducto"] = listaProducto;
                        Session["listaMesa"] = listaMesa;
                        ddlProducto.DataSource = listaProducto;
                        ddlProducto.DataValueField = "Id";
                        ddlProducto.DataTextField = "Nombre";
                        ddlProducto.DataBind();
                        ddlMesa.DataSource = listaMesa;
                        ddlMesa.DataValueField = "Id";
                        ddlMesa.DataTextField = "Numero";
                        ddlMesa.DataBind();

                        ddlProducto.Items.Insert(0, new ListItem("Seleccione un producto", ""));
                        ddlMesa.Items.Insert(0, new ListItem("Seleccione una mesa", ""));

                        ddlProducto.SelectedIndex = 0;
                        ddlMesa.SelectedIndex = 0;

                        cargarPedidos();
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        private List<ProductoPedido> ProductosTemp
        {
            get
            {
                if (Session["ProductosTemp"] == null)
                {
                    Session["ProductosTemp"] = new List<ProductoPedido>();
                }
                return (List<ProductoPedido>)Session["ProductosTemp"];
            }
            set
            {
                Session["ProductosTemp"] = value;
            }
        }
        public bool listarCant(int IdRecibido, int CantRecibida)
        {

            AccesoDatos datos = new AccesoDatos();
            Producto aux = null;

            try
            {
                datos.setearConsulta("Select CantidadDisp From Productos where Id=@Id");
                datos.setearParametro("@Id", IdRecibido);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux = new Producto();
                    aux.CantidadDisp = (int)datos.Lector["CantidadDisp"];
                }
                if (aux != null && aux.CantidadDisp >= CantRecibida)
                {

                    return true;
                }
                else
                {
                    return false;
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
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {

            try
            {

                int productoId = int.Parse(ddlProducto.SelectedValue);
                string nombreProducto = ddlProducto.SelectedItem.Text;
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);
                bool prueba = listarCant(productoId, cantidad);
                if (prueba)
                {

                    // Crear el producto y añadirlo a la lista temporal
                    var productoPedido = new ProductoPedido
                    {
                        IdProducto = productoId,
                        NombreProducto = nombreProducto,
                        Cantidad = cantidad,
                        Precio = precio
                    };

                    ProductosTemp.Add(productoPedido);

                    // Actualizar el GridView con los productos agregados
                    dgvProductos.DataSource = ProductosTemp;
                    dgvProductos.DataBind();

                    // Limpiar los campos 
                    txtCantidad.Text = "";
                    txtPrecio.Text = "";
                    ddlProducto.SelectedIndex = 0;
                }
                else
                {
                    string script = "alert('No hay stock disponible para este producto.');";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);

                }
            }
            catch (Exception)
            {
                string script = "alert('Debe completar todos los campos.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", script, true);
            }
        }

        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            if (Session["ProductosTemp"] == null || ((List<ProductoPedido>)Session["ProductosTemp"]).Count == 0)
            {
                // Si no hay productos, mostrar un mensaje de alerta al usuario
                string script = "alert('Debe agregar productos antes de realizar el pedido.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
            }
            else
            {
                try
                {
                    decimal montoTotal = ProductosTemp.Sum(p => p.Precio * p.Cantidad);

                    Pedido nuevoPedido = new Pedido
                    {
                        Fecha = DateTime.Now,
                        IdMozo = 1, // Este valor falta hacerlo dinamico
                        IdMesa = 2, // También dinámico
                        Monto = montoTotal,
                        Productos = ProductosTemp
                    };

                    PedidoNegocio pedidoNegocio = new PedidoNegocio();
                    pedidoNegocio.agregarPedido(nuevoPedido);

                    // Limpiar productos temporales y notificar al usuario
                    ProductosTemp.Clear();
                    dgvProductos.DataBind();
                    cargarPedidos();
                    string script = "alert('Pedido agregado con éxito.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertaSimple", script, true);
                }
                catch (Exception ex)
                {
                    string script = $"alert('Error: {ex.Message}');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "alertaError", script, true);
                }
            }
        }
        protected void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            GridViewRow row = (GridViewRow)btnEliminar.NamingContainer;

            int productoId = int.Parse(dgvProductos.DataKeys[row.RowIndex].Value.ToString()); // Esto puede causar error si no se encuentra el producto en el DataKey

            // Verifica si el producto está en la lista antes de eliminarlo
            var producto = ProductosTemp.FirstOrDefault(p => p.IdProducto == productoId);
            if (producto != null)
            {
                ProductosTemp.Remove(producto);
                dgvProductos.DataSource = ProductosTemp;
                dgvProductos.DataBind();
            }
            else
            {
                Console.WriteLine("Producto no encontrado para eliminar.");
            }
        }

        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (!string.IsNullOrEmpty(ddlProducto.SelectedItem.Value))
            {
                try
                {

                    int productoId = int.Parse(ddlProducto.SelectedItem.Value);

                    // Buscar el producto
                    Producto productoSeleccionado = ((List<Producto>)Session["listaProducto"]).Find(x => x.Id == productoId);

                    // Mostrar el precio del producto seleccionado
                    if (productoSeleccionado != null)
                    {
                        txtPrecio.Text = productoSeleccionado.Precio.ToString();
                    }
                    else
                    {
                        // En caso de no encontrar el producto
                        txtPrecio.Text = "Producto no encontrado";
                    }
                }
                catch (FormatException)
                {
                    // En caso de que no se pueda convertir el valor a int
                    txtPrecio.Text = "Selecciona un producto válido";
                }
            }
            else
            {
                // Si no se seleccionó un producto válido, limpiar el precio
                txtPrecio.Text = "";
                txtCantidad.Text = "";
            }
        }
        private void cargarPedidos()
        {
            PedidoNegocio negocio = new PedidoNegocio();
            dgvPedidos.DataSource = negocio.listar();
            dgvPedidos.DataBind();
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                Button btnDetalle = (Button)sender;
                GridViewRow row = (GridViewRow)btnDetalle.NamingContainer;

                int pedidoId = int.Parse(dgvPedidos.DataKeys[row.RowIndex].Value.ToString());

                PedidoNegocio negocio = new PedidoNegocio();
                List<ProductoPedido> detalles = negocio.obtenerDetallePedido(pedidoId);

                dgvDetallePedido.DataSource = detalles;
                dgvDetallePedido.DataBind();


            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Replace("'", "\\'");
                string script = $"alert('Error al cargar el detalle: {mensaje}');";
                ScriptManager.RegisterStartupScript(this, GetType(), "errorDetalle", script, true);
            }
        }

        protected void ddlMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlMesa.SelectedItem.Value))
            {
                try
                {

                    int mesaId = int.Parse(ddlMesa.SelectedItem.Value);

                    // Buscar la mesa
                    Mesa mesaSeleccionada = ((List<Mesa>)Session["listaMesa"]).Find(x => x.Id == mesaId);

                    // Mostrar el nombre del mozo
                    if (mesaSeleccionada != null && mesaSeleccionada.Mozo != null)
                    {
                        txtMozo.Text = mesaSeleccionada.Mozo.NombreCompleto;  // Acceder al nombre del mozo
                    }
                    else
                    {
                        // En caso de no encontrar la mesa o el mozo
                        txtMozo.Text = "Mesa no encontrada o sin mozo asignado";
                    }
                }
                catch (FormatException)
                {
                    // En caso de que no se pueda convertir el valor a int
                    txtMozo.Text = "Selecciona una mesa válida";
                }
            }
            else
            {
                // Si no se seleccionó una mesa válida
                txtMozo.Text = "";
               
            }
        }
    }
}

