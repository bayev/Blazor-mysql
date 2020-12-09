using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace DataLibrary
{
    public class DataAccess
    {
        public static List<T> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                //Model Type of return data -> mapping the data in T in a set/ one per row
                List<T> rows = connection.Query<T>(sql, parameters).ToList();
                //Return the data in a list - with parameters
                return rows;
            }
        }


        //save data
        public static void SaveData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                connection.Execute(sql, parameters);
            }
        }

    }
}
