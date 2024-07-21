using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace SistemaDeVendas.Uteis
{
    public class DAL
    {
        private static string Server = "DESKTOP-DB70OBM\\SQLEXPRESS01";
        private static string Database = "sistema_venda";
        private static string User = "admin";
        private static int Password = 1234;
       // private static string connectionString = $"Server={Server}; Database={Database}; User Id={User}; Password={Password}"; Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
        private static string connectionString = $"Server={Server}; Database={Database}; Trusted_Connection=True;"; 
        private static SqlConnection Connection;

        public DAL()
        {
            
            Connection = new SqlConnection(GetConnectionString("Default"));
            Connection.Open();
        }

        public static string GetConnectionString(string connectionStringName)
        {
            string basePath = "";
            try
            {
                var env = PlatformServices.Default.Application;
                basePath = Directory.GetCurrentDirectory();
                var builder = new ConfigurationBuilder()
                    .SetBasePath(basePath)
                    .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

             var  Configuration = builder.Build();
                return Configuration.GetConnectionString(connectionStringName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable RetDataTable(string sql)
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand(sql, Connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(data);
            return data;
        }

        public DataTable RetDataTable(SqlCommand command)
        {
            DataTable data = new DataTable();
            command.Connection = Connection;
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(data);
            return data;
        }

        public void ExecutarComandoSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, Connection);
            command.ExecuteNonQuery();
        }
    }
}

