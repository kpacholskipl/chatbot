using System;
using System.Data;
using System.Data.SqlClient;

namespace ChatBot.Helpers
{
    public class DatabaseHelper
    {
        protected readonly string connectionString = @"Data Source=SQL6032.site4now.net;Initial Catalog=db_aa8e53_chat;User Id=db_aa8e53_chat_admin;Password=Test1234";

        public DataSet SelectQuery(string query, string table)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { SelectCommand = new SqlCommand(query, conn) };
                adapter.Fill(ds, table);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;      
        }

        public DataSet SelectCommand(SqlCommand command, string table)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { SelectCommand = command };
                adapter.SelectCommand.Connection = conn;
                adapter.Fill(ds, table);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }
        public bool InsertQuery(string query)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { InsertCommand = new SqlCommand(query, conn) };
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

        public bool InsertCommand(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { InsertCommand = command };
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
        public bool UpdateQuery(string query)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { UpdateCommand = new SqlCommand(query, conn) };
                adapter.UpdateCommand.ExecuteNonQuery();
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


        public bool UpdateCommand(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { UpdateCommand = command };
                adapter.UpdateCommand.Connection = conn;
                adapter.UpdateCommand.ExecuteNonQuery();
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
        public bool DeleteQuery(string query)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { DeleteCommand = new SqlCommand(query, conn) };
                adapter.DeleteCommand.ExecuteNonQuery();
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
        public bool DeleteCommand(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { DeleteCommand = command };
                adapter.DeleteCommand.Connection = conn;
                adapter.DeleteCommand.ExecuteNonQuery();
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
        public int InsertScalar(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter { InsertCommand = command };
                adapter.InsertCommand.Connection = conn;
                return Convert.ToInt32(adapter.InsertCommand.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return 0;
        }
    }
}