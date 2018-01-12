using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContextNamespace
{
    public static class ConnectionTools
    {
        // all params are optional
        public static void ChangeDatabase(
            this DataContext source,
            string initialCatalog = "",
            string dataSource = "",
            string userId = "",
            string password = "",
            bool integratedSecuity = true,
            string configConnectionStringName = "")
        /* this would be used if the
        *  connectionString name varied from 
        *  the base EF class name */
        {
            try
            {
                // use the const name if it's not null, otherwise
                // using the convention of connection string = EF contextname
                // grab the type name and we're done
                var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
                    ? source.GetType().Name
                    : configConnectionStringName;

                // add a reference to System.Configuration
                var entityCnxStringBuilder = new EntityConnectionStringBuilder();

                entityCnxStringBuilder.Provider = "System.Data.SqlClient";
                entityCnxStringBuilder.ProviderConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[configNameEf].ConnectionString;


                // init the sqlbuilder with the full EF connectionstring cargo
                var sqlCnxStringBuilder = new SqlConnectionStringBuilder
                    (entityCnxStringBuilder.ProviderConnectionString);

                // only populate parameters with values if added
                if (!string.IsNullOrEmpty(initialCatalog))
                    sqlCnxStringBuilder.InitialCatalog = initialCatalog;
                if (!string.IsNullOrEmpty(dataSource))
                    sqlCnxStringBuilder.DataSource = dataSource;
                if (!string.IsNullOrEmpty(userId))
                    sqlCnxStringBuilder.UserID = userId;
                if (!string.IsNullOrEmpty(password))
                    sqlCnxStringBuilder.Password = password;

                // set the integrated security status
                // sqlCnxStringBuilder.IntegratedSecurity = integratedSecuity;

                // now flip the properties that were changed
                source.Database.Connection.ConnectionString
                    = sqlCnxStringBuilder.ConnectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DbConnection GetConnection()
        {
            try
            {

                // TODO: Change from config.xml file
                string sqlServerHost = "127.0.0.1";
                string user = "root";
                string password = "Sense17*";
                string port = "3306";
                MySqlConnectionStringBuilder sqlBuilder = new MySqlConnectionStringBuilder
                {
                    Server = string.Format("{0}", sqlServerHost),
                    Database = "myterm",
                    UserID = user,
                    Password = password,
                    Port = Convert.ToUInt32(port),
                    AutoEnlist = false
                };

                DbProviderFactory factory =
                    DbProviderFactories.GetFactory("MySql.Data.MySqlClient");

                DbConnection dbConnection = factory.CreateConnection();
                dbConnection.ConnectionString = sqlBuilder.ConnectionString;

                return dbConnection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

