using CRUD_CORE_MVC.Models;
using System.Data.SqlClient;
using System.Data;


namespace CRUD_CORE_MVC.AccesoDatos
{
    public class ContactoDatos
    {

        public List<ContactoModel> ListarContacto()
        {
            Conexion datos = new Conexion();

            List<ContactoModel> lista = new List<ContactoModel>();
            datos.setSP("SP_LISTAR");
            datos.EjecutarLectura();


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
                datos.CerrarConexion();
            }
			
        }

          public void AgregarContacto(ContactoModel contacto)
        {
            Conexion datos = new Conexion();
            try
            {
                datos.setSP("SP_GUARDAR");
                datos.setParametros("@Nombre", contacto.Nombre);
                datos.setParametros("@Telefono", contacto.Telefono);
                datos.setParametros("@Correo", contacto.Correo);
                datos.EjecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
    }
}
