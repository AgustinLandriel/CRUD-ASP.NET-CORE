using CRUD_CORE_MVC.Models;
using System.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
            cmd.CommandType = CommandType.StoredProcedure;
            datos.Lector = cmd.ExecuteReader();
            conexion.Open();

            try
            {
                while (!datos.Lector.Read())
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

          public void AgregarContacto(ContactoModel contacto)
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
    }
}
