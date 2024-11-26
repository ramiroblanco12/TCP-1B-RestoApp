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

        private bool GuardarUsuarioEnBaseDeDatos(string username, string password)
        {
            // Implementa tu lógica de guardado en la base de datos aquí.
            // Retorna true si fue exitoso, de lo contrario false.
            return true; // Ejemplo ficticio
        }
    }
}