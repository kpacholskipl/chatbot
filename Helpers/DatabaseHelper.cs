using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

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
            catch(SqlException ex)
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
                    SqlDataAdapter adapter = new SqlDataAdapter { SelectCommand = command };
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }




        //public DataSet UpdateAdapter(string query())
       // {

//        }
        /*
           public static DataTable ExecuteQueryCommand(SqlCommand command)
           {
               DataTable dt = new();
               try
               {
                   using SqlConnection connection = new(connectionString);
                   command.Connection = connection;
                   connection.Open();
                   using SqlDataAdapter adapter = new(command);
                   adapter.Fill(dt);
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex.Message);
               }
               return dt;
           }

           public static bool ExecuteNonQuery(string query)
           {
               bool result = true;

               try
               {
                   using SqlConnection connection = new(connectionString);
                   connection.Open();
                   using SqlCommand command = new(query, connection);
                   command.ExecuteNonQuery();
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex.Message);
                   result = false;
               }
               return result;
           }

           public static bool ExecuteNonQueryCommand(SqlCommand command)
           {
               bool result = true;
               try
               {
                   using SqlConnection connection = new(connectionString);
                   command.Connection = connection;
                   connection.Open();
                   command.ExecuteNonQuery();
               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex.Message);
                   result = false;
               }
               return result;
           }
           public static int ExecuteScalarCommand(SqlCommand command)
           {
               try
               {
                   using SqlConnection connection = new(connectionString);
                   command.Connection = connection;
                   connection.Open();
                   return Convert.ToInt32(command.ExecuteScalar());

               }
               catch (Exception ex)
               {
                   Console.WriteLine(ex.Message);
               }
               return 0;
           }*/
    }
}