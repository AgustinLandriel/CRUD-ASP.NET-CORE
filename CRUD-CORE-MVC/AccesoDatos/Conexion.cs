using System.Data;
using System.Data.SqlClient;

namespace CRUD_CORE_MVC.AccesoDatos
{
    public class Conexion
    {

        //Atributos
        private string conexionSQL;
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlConnection conexion;


        //Constructor
        public Conexion() {
            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            
            conexionSQL = builder.GetSection("ConnectionStrings:conexionSQL").Value;
           
            SqlCommand comando = new SqlCommand();

            SqlConnection conexion = new SqlConnection(conexionSQL);

        
        }

        //Metodos


        //public string ConexionSQL()
        //{
        //    return conexionSQL;
        //}

        public SqlDataReader Lector
        {
            get { return lector; }
        }


        public void setQuery(string consulta)
        {
            comando.CommandType = CommandType.Text;
            comando.CommandText = consulta;

            
        }

        public void setSP(string storeProcedure)
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = storeProcedure;
        }

        public void setParametros (string var,object dato)
        {
            comando.Parameters.AddWithValue(var, dato);
        }

        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void EjecutarLectura()
        {
            //Conecto el comando con la BD
            comando.Connection = conexion;
            

            try
            {
                //Abro conexion
                conexion.Open();

                //Traigo al lector toda las columnas de datos
                lector = comando.ExecuteReader();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                //Cierro lector si esta vacio
                /*  if (lector != null)
                {
                    lector.Close();
                }*/

                //Cierro conexion de la BD

                conexion.Close();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
