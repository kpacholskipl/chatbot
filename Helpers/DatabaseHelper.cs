using System;
using System.Data;
using System.Data.SqlClient;

namespace ChatBot.Helpers
{
    public class DatabaseHelper
    {
        protected readonly string connectionString = @"Data Source=SQL6032.site4now.net;Initial Catalog=db_aa8e53_chat;User Id=db_aa8e53_chat_admin;Password=Test1234";

        public DataSet ExecuteQuery(string query, string table)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter { SelectCommand = new SqlCommand(query, conn) };
                    adapter.Fill(ds, table);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ds;
        }
        public DataSet ExecuteCommand(SqlCommand command)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter { SelectCommand = command };
                    adapter.Fill(ds);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ds;
        }
        public bool ExecuteNonQuery(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter { SelectCommand = new SqlCommand(query, conn) };
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool ExecuteNonCommand(SqlCommand command)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter { InsertCommand = command };
                    //adapter.InsertCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool InsertNonCommand(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter {InsertCommand = command };
                adapter.InsertCommand.Connection = conn;
                adapter.InsertCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
    }
}