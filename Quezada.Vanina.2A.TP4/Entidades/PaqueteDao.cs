using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class PaqueteDao
    {
        private SqlCommand comando;
        private SqlCommand conexion;
        #region Constructor
        static PaqueteDao() { }
        #endregion
        #region Metodos
        public static bool Insertar(Paquete p)
        {
            return false;
        }
        #endregion
    }
}
