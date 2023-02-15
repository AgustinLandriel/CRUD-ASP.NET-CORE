using CRUD_CORE_MVC.AccesoDatos;
using CRUD_CORE_MVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUD_CORE_MVC.AccesoDatos
{
    public class Registro
    {
        public bool UsuarioRegistro(UsuarioModel usuario)
        {

            Conexion datos = new Conexion();
            SqlConnection conexion = new SqlConnection(datos.ConexionSQL); //Hago la conexion a la bd
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_REGISTRO", conexion); //Conecto el comando con la bd y el store procedure

            comando.CommandType = CommandType.StoredProcedure; // Selecciono el tipo de comando

            try
            {


                //Reemplazo las variables de la sp por los att de los contactos
                comando.Parameters.AddWithValue("@usuario", usuario.User);
                comando.Parameters.AddWithValue("@password", usuario.Contraseña);
                //comando.Parameters.AddWithValue("@tipoUsuario", usuario.tipoUser);

                comando.ExecuteNonQuery(); //Hago el commit
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                conexion.Close(); //Cierro conexion
            }
        }

        public bool BuscarUsuario(UsuarioModel usuario)
        {
            ContactoModel contacto = new ContactoModel();
            Conexion datos = new Conexion();
            SqlConnection conexion = new SqlConnection(datos.ConexionSQL);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_BUSCAR_USUARIO", conexion);
            comando.Parameters.AddWithValue("@usuario", usuario.User);
            comando.Parameters.AddWithValue("@password", usuario.Contraseña);
            comando.CommandType = CommandType.StoredProcedure;
            datos.Lector = comando.ExecuteReader();

            try
            {
                while (datos.Lector.Read())
                {
                    usuario.idUsuario = (int)datos.Lector["idUsuario"];
                    usuario.User = (string)datos.Lector["User"];
                    usuario.Contraseña = (string)datos.Lector["Contraseña"];
                    usuario.tipoUser = (bool)datos.Lector["tipoUsuario"];

                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
