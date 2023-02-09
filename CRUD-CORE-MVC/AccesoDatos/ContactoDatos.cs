using CRUD_CORE_MVC.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Contracts;


namespace CRUD_CORE_MVC.AccesoDatos
{
    public class ContactoDatos
    {

        public List<ContactoModel> ListarContacto()
        {

            //datos.setSP("SP_LISTAR");
            //datos.EjecutarLectura();

            List<ContactoModel> lista = new List<ContactoModel>();
            Conexion datos = new Conexion();
            SqlConnection conexion = new SqlConnection(datos.ConexionSQL);
            SqlCommand cmd = new SqlCommand("SP_LISTAR", conexion);
            conexion.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            datos.Lector = cmd.ExecuteReader();

            try
            {
                while (datos.Lector.Read())
                {
                    ContactoModel contactoAux = new ContactoModel();

                    contactoAux.idContacto = (int)datos.Lector["idContacto"];
                    contactoAux.Nombre = (string)datos.Lector["Nombre"];
                    contactoAux.Telefono = (string)datos.Lector["Telefono"];
                    contactoAux.Correo = (string)datos.Lector["Correo"];

                    lista.Add(contactoAux);

                }

                return lista;
            }
            catch (Exception )
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
			
        }

        public bool AgregarContacto(ContactoModel contacto)
        {
            Conexion datos = new Conexion();
            SqlConnection conexion = new SqlConnection(datos.ConexionSQL); //Hago la conexion a la bd
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_GUARDAR",conexion); //Conecto el comando con la bd y el store procedure

            comando.CommandType = CommandType.StoredProcedure; // Selecciono el tipo de comando

            try
            {
                //datos.setSP("SP_GUARDAR");
                //datos.setParametros("@Nombre", contacto.Nombre);
                //datos.setParametros("@Telefono", contacto.Telefono);
                //datos.setParametros("@Correo", contacto.Correo);
                //datos.EjecutarAccion();

                //Reemplazo las variables de la sp por los att de los contactos
                comando.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                comando.Parameters.AddWithValue("@Correo", contacto.Correo);
                comando.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                comando.ExecuteNonQuery(); //Hago el commit
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close(); //Cierro conexion
            }

        }

        public bool ModificarContacto(ContactoModel contacto)
        {
            Conexion datos = new Conexion();
            SqlConnection conexion = new SqlConnection(datos.ConexionSQL); 
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_EDITAR", conexion); 
            comando.CommandType = CommandType.StoredProcedure; 

            try
            {
                
                comando.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                comando.Parameters.AddWithValue("@Correo", contacto.Correo);
                comando.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                comando.Parameters.AddWithValue("@idContacto", contacto.idContacto);
                comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close(); //Cierro conexion
            }
        }

        public ContactoModel ObtenerContacto(int idContacto)
        {
            ContactoModel contacto = new ContactoModel();
            Conexion datos = new Conexion();
            SqlConnection conexion = new SqlConnection(datos.ConexionSQL);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_OBTENER_CONTACTO", conexion);
            comando.Parameters.AddWithValue("@idContacto", idContacto);
            comando.CommandType = CommandType.StoredProcedure;
            datos.Lector = comando.ExecuteReader();

            try
            {
                while (datos.Lector.Read())
                {
                    contacto.idContacto = (int)datos.Lector["idContacto"];
                    contacto.Nombre = (string)datos.Lector["Nombre"];
                    contacto.Telefono = (string)datos.Lector["Telefono"];
                    contacto.Correo = (string)datos.Lector["Correo"];
                }
                return contacto;
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

        public bool EliminarContacto(int idContacto)
        {
            Conexion datos = new Conexion();
            SqlConnection conexion = new SqlConnection(datos.ConexionSQL);
            conexion.Open();
            SqlCommand comando = new SqlCommand("SP_ELIMINAR", conexion);
            comando.Parameters.AddWithValue("@idContacto",idContacto);
            comando.CommandType = CommandType.StoredProcedure;

            try
            {

                comando.ExecuteNonQuery();
                return true;
                
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexion.Close(); //Cierro conexion
            }
        }
    }
}
