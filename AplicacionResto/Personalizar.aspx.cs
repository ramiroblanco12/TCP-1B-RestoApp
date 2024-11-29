using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionResto
{
    public partial class Personalizar : System.Web.UI.Page
    {
        public bool sel { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || ((Dominio.Usuario)Session["usuario"]).tipoUsuario != Dominio.TipoUsuario.Admin)
            {
                // Redirigir si no es administrador
                Response.Redirect("/Pedidos.aspx");
            }
            else
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
                        sel = false;
                        MozoNegocio negocio = new MozoNegocio();
                        dgvMozos.DataSource = negocio.listar();
                        dgvMozos.DataBind();
                    }


                }
            }

        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                CrearUsuario user = new CrearUsuario();
                CrearUsuarioNegocio usuarioNegocio = new CrearUsuarioNegocio();
                user.Usuario = txtUsuer.Text;
                user.Pass = txtPass.Text;
                user.Tipo = int.Parse(dropOpciones.SelectedValue);
                int id = usuarioNegocio.insertarNuevo(user);




            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }

        protected void btnCrearMesas_Click(object sender, EventArgs e)
        {

            int cantidadMesas = int.Parse(txtCantidadMesas.Text);


            if (cantidadMesas > 0 && txtCantidadMesas != null)
            {

                AccesoDatos datos = new AccesoDatos();

                for (int i = 1; i <= cantidadMesas; i++)
                {
                    int numeroMesa = i;
                    int idMozo = -1;
                    try
                    {
                        datos.setearConsulta("INSERT INTO Mesas (Numero, IdMozo) VALUES (@Numero, @IdMozo)");
                        datos.setearParametro("@Numero", numeroMesa);
                        datos.setearParametro("@IdMozo", idMozo);
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
            else
            {

                lblMensaje.Text = "Ingrese una cantidad válida mayor a 0.";
                return;
            }
         }



            protected void CargarTXT(object sender, EventArgs e)
            {

                sel = true;
                GridViewRow SelectedRow = dgvMozos.SelectedRow;

                txtEId.Text = SelectedRow.Cells[1].Text;
                txtMId.Text = SelectedRow.Cells[1].Text;
                txtMNombre.Text = SelectedRow.Cells[2].Text;
            }


        protected void CargaDGV()
        {
            MozoNegocio negocio = new MozoNegocio();
            dgvMozos.DataSource = negocio.listar();
            dgvMozos.DataBind();
        }



        protected void btnAceptarModificar_Click(object sender, EventArgs e)
        {

            Mozo nuevo = new Mozo();
            MozoNegocio negocio = new MozoNegocio();
            try
            {
                nuevo.NombreCompleto = txtMNombre.Text;

                negocio.modificarConSP(nuevo);

                Response.Redirect("Personalizar.aspx", false);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message.Replace("'", "\\'");
                string script = $"alert('Ocurrio un error: necesita cargar datos para aceptar' );";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "errorAlert", script, true);

            }

        }

        protected void btnAceptarEliminar_Click1(object sender, EventArgs e)
        {

            try
            {
                Mozo nuevo = new Mozo();
                MozoNegocio negocio = new MozoNegocio();

                nuevo.Id = int.Parse(txtEId.Text);
                negocio.eliminar(int.Parse(txtEId.Text));


                Response.Redirect("Productos.aspx");

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);

            }

        }

        protected void btnaceptar_Click1(object sender, EventArgs e)
        {
            Mozo nuevo = new Mozo();
            MozoNegocio negocio = new MozoNegocio();
            try
            {
                nuevo.NombreCompleto = txtNombre.Text;
                negocio.agregarConSP(nuevo);

                Response.Redirect("Personalizar.aspx", false);
            }
            catch (Exception)
            {
                string script = "alert('Por favor, completa el campo.');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
            }

        }
    }
}

