using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateColumn.Services
{
    public class Service : IService
    {
        private readonly IConfiguration _configuration;
        public Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool InsertColumn(ModelClass add)
        {
            int result = 0;
            string? connectionString = _configuration.GetConnectionString("ConnectionString")?.ToString();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            using (SqlCommand cmd = new SqlCommand("insert into CustomerData(Id,CreatedDate)values(@param1,@param2)", sqlConnection))
            {               
                cmd.Parameters.AddWithValue("@param1", add.Id);
                cmd.Parameters.AddWithValue("@param2", add.CreatedDate);                
                result= cmd.ExecuteNonQuery();
            }
            if (result == 1)
            {
                sqlConnection.Close();
                return true;

            }
            else
            {
                sqlConnection.Close();
                return false;

            }
        }
    }
}

