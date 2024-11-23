using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionResto
{
    public partial class Productos : System.Web.UI.Page
    {
        //--Seleccionado genera un bool para controlar que este cargado antes de modificar--
        public bool seleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            seleccionado = false;
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();

        }



        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto();
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDesc.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                negocio.agregarConSP(nuevo);


                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Replace("'", "\\'");
                string script = $"alert('Ocurrio un error: necesita cargar datos para aceptar' );";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorAlert", script, true);

            }
        }


        protected void CargarTXT(object sender, EventArgs e)
        {

            seleccionado = true;
            GridViewRow SelectedRow = dgvProductos.SelectedRow;

            txtEID.Text = SelectedRow.Cells[1].Text;
            txtMId.Text = SelectedRow.Cells[1].Text;
            txtMNombre.Text = SelectedRow.Cells[2].Text;
            txtMDesc.Text = SelectedRow.Cells[3].Text;
            txtMPrecio.Text = SelectedRow.Cells[4].Text;
        }

        protected void CargaDGV()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProductos.DataSource = negocio.listar();
            dgvProductos.DataBind();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Producto nuevo = new Producto();
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                nuevo.Nombre = txtMNombre.Text;
                nuevo.Descripcion = txtMDesc.Text;
                nuevo.Precio = decimal.Parse(txtMPrecio.Text);
                nuevo.Id = int.Parse(txtMId.Text);

                //negocio.modificarConSP(nuevo);


                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Replace("'", "\\'");
                string script = $"alert('Ocurrio un error: necesita cargar datos para aceptar' );";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorAlert", script, true);

            }

        }


        protected void btnAceptarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto nuevo = new Producto();
                ProductoNegocio negocio = new ProductoNegocio();

                nuevo.Id = int.Parse(txtEID.Text);
                negocio.eliminar(int.Parse(txtEID.Text));
                Response.Redirect("Productos.aspx");

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);

            }


        }
    }
}