using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        AccesoDatos datos = new AccesoDatos();
        public bool Loguear(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("Select Id, Usuario, Pass, TipoUsuario FROM Usuarios where Usuario = @User AND Pass = @Pass");
                datos.setearParametro("@User", usuario.User);
                datos.setearParametro("@Pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.tipoUsuario = (int)(datos.Lector["TipoUsuario"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Normal;
                    return true;
                }
                return false;
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
