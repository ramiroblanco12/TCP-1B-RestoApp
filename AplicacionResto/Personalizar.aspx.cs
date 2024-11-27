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
    public partial class Personalizar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if (Session["usuario"] == null)
            {
                Session.Add("error", "debes iniciar sesion para ingresar");
                Response.Redirect("Default.aspx", false);
            }
            else
            {
            }
            }
=======

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //// Validación del lado del servidor
            //if (Page.IsValid)
            //{
            //    string username = txtUsername.Text.Trim();
            //    string password = txtPassword.Text.Trim();

            //    // Aquí podrías guardar los datos en la base de datos
            //    // Ejemplo de lógica básica
            //    if (GuardarUsuarioEnBaseDeDatos(username, password))
            //    {
            //        lblMessage.CssClass = "text-success";
            //        lblMessage.Text = "Usuario registrado exitosamente.";
            //    }
            //    else
            //    {
            //        lblMessage.CssClass = "text-danger";
            //        lblMessage.Text = "Hubo un error al registrar el usuario.";
            //    }

            //    lblMessage.Visible = true;
            //}
        }
>>>>>>> 3118d5cf97779e535111cc7de9cf540b7b854e48

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                CrearUsuario user = new CrearUsuario();
                CrearUsuarioNegocio usuarioNegocio = new CrearUsuarioNegocio();
                user.Usuario = txtUsuer.Text;
                user.Pass =txtPass.Text;
                user.Tipo = int.Parse(txtTipo.Text);
                int id = usuarioNegocio.insertarNuevo(user);




            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}