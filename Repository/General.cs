﻿using System.Data.SqlClient;

namespace WebApplication1.Repository
{
    public class General
    {
        public static string connectionString()
        {
            SqlConnectionStringBuilder connectionbuilder = new();
            connectionbuilder.DataSource = "DESKTOP-H515FHI";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;
            return (cs);
        }
    }
}
