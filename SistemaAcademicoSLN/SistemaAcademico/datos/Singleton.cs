using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.datos
{
    internal class Singleton
    {
        private static Singleton instancia;
        private SqlConnection cnn;
        private Singleton()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);
        }
        public static Singleton ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new Singleton();
            return instancia;
        }
        public SqlConnection ObtenerConexion()
        {
            return this.cnn;
        }
    }
}
