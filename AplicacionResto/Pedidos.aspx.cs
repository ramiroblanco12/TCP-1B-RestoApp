using Dominio;
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
            try
            {
                if (!IsPostBack)
                {

                    txtPrecio.Enabled = false;
                    ProductoNegocio negocio = new ProductoNegocio();
                    List<Producto> lista = negocio.listar();

                    ddlProducto.DataSource = lista;
                    ddlProducto.DataValueField = "Id";
                    ddlProducto.DataTextField = "Nombre";
                    ddlProducto.DataBind();

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
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            // Obtener los valores del modal
            int productoId = int.Parse(ddlProducto.SelectedValue);
            string nombreProducto = ddlProducto.SelectedItem.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            // decimal precio = ObtenerPrecioProducto(productoId); // Método para obtener el precio del producto

            // Crear el producto y añadirlo a la lista temporal
            var productoPedido = new ProductoPedido
            {
                IdProducto = productoId,
                NombreProducto = nombreProducto,
                Cantidad = cantidad,
                // Precio = precio
            };

            ProductosTemp.Add(productoPedido);

            // Actualizar el GridView con los productos agregados
            dgvProductos.DataSource = ProductosTemp;
            dgvProductos.DataBind();

            // Limpiar los campos del modal
            txtCantidad.Text = "";
            ddlProducto.SelectedIndex = 0;
        }

        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            //decimal montoTotal = ProductosTemp.Sum(p => ObtenerPrecioProducto(p.IdProducto) * p.Cantidad);

            try
            {
                Pedido nuevoPedido = new Pedido
                {
                    Fecha = DateTime.Now,
                    IdMozo= 1,  // ID del mozo
                    IdMesa = 2,  // ID de la mesa
                    Monto = 100, // Calculado previamente
                    Productos = new List<ProductoPedido>(ProductosTemp)
                };

                PedidoNegocio pedidoNegocio = new PedidoNegocio();
                pedidoNegocio.agregarPedido(nuevoPedido);
                // Limpiar los productos temporales
                ProductosTemp.Clear();

                string script = "alert('Se agregó el pedido con exito');";
                ScriptManager.RegisterStartupScript(this, GetType(), "alertaSimple", script, true);

            }
            catch (Exception ex)
            {
                // Manejo de errores
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
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
            try
            {
                int productoId = int.Parse(ddlProducto.SelectedValue);

                
                    ProductoNegocio negocio = new ProductoNegocio();
                    Producto productoSeleccionado = negocio.listar().FirstOrDefault(p => p.Id == productoId);

                    if (productoSeleccionado != null)
                    {
                        // Cargar el precio en el TextBox
                        txtPrecio.Text = productoSeleccionado.Precio.ToString(); 
                    }

            
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}