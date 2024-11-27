using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionResto
{
    public partial class Reportes : System.Web.UI.Page
    {
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

            }
            }
        }
    }
}