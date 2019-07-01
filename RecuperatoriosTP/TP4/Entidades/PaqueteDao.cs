using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace Entidades
{
    public class PaqueteDao
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;
        #region Constructor
        static PaqueteDao() {

            // CREO UN OBJETO SQLCONECTION
            conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);

            // CREO UN OBJETO SQLCOMMAND
            PaqueteDao.comando = new SqlCommand();
            // INDICO EL TIPO DE COMANDO
            PaqueteDao.comando.CommandType = System.Data.CommandType.Text;
            // ESTABLEZCO LA CONEXION
            PaqueteDao.comando.Connection = PaqueteDao.conexion;
        }
        #endregion
        #region Metodos
        public static bool Insertar(Paquete p)
        {
            bool todoOk = false;

            string sql = "INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES(";
            sql = sql + "'" + p.DireccionEntrega + "','" + p.TrackingID + "', 'Vanina Quezada')";

            try
            {
                // LE PASO LA INSTRUCCION SQL
                PaqueteDao.comando.CommandText = sql;

                // ABRO LA CONEXION A LA BD
                PaqueteDao.conexion.Open();

                // EJECUTO EL COMMAND
                PaqueteDao.comando.ExecuteNonQuery();

                todoOk = true;

            }
            catch (Exception)
            {
                todoOk = false;
            }
            finally
            {
                if (todoOk)
                    PaqueteDao.conexion.Close();
            }
            return todoOk;

        }
        #endregion
    }
}
