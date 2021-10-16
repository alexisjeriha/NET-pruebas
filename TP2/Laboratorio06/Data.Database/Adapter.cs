using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringExpress";

        public SqlConnection SqlConn { get; set; }


        protected void OpenConnection()
        {

            string sCnn = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            SqlConn = new SqlConnection(sCnn);
            SqlConn.Open();
        }

        protected void CloseConnection()
        {
            SqlConn.Close();
            SqlConn = null;

        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }




    }


}

