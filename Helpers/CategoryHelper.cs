using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ChatBot.Models;

namespace ChatBot.Helpers
{
    public class CategoryHelper
    {
        public static List<Category> GetFromDataSet(DataSet ds)
        {
            List<Category> categories = new List<Category>();

            foreach (DataRow row in ds.Tables["Categories"].Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string name = row["name"].ToString();

                Category Category = new Category(id, name);
                categories.Add(Category);
            }

            return categories;
        }
        public static SqlCommand AddParametrsToSqlCommand(SqlCommand cmd, Category Category)
        {
            //cmd.Parameters.AddWithValue("@CategoryId", Category.CategoryId);
            //cmd.Parameters.AddWithValue("@email", Category.Email);
            //cmd.Parameters.AddWithValue("@password", Category.Password);
            //cmd.Parameters.AddWithValue("@role", Category.Name);
            //cmd.Parameters.AddWithValue("@name", Category.Name);

            return cmd;
        }
    }
}