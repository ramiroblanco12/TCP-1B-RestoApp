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
                ProductoId = productoId,
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
        }
        protected void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            Button btnEliminar = (Button)sender;
            GridViewRow row = (GridViewRow)btnEliminar.NamingContainer;

            int productoId = int.Parse(dgvProductos.DataKeys[row.RowIndex].Value.ToString()); // Esto puede causar error si no se encuentra el producto en el DataKey

            // Verifica si el producto está en la lista antes de eliminarlo
            var producto = ProductosTemp.FirstOrDefault(p => p.ProductoId == productoId);
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
    }
}