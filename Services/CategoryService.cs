using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ChatBot.Helpers;
using ChatBot.Models;

namespace ChatBot.Services
{
    public class CategoryService
    {
        private DataSet GetCategoriesData(string where = "")
        {
            string query = "Select * from Categories";
            if (where != "")
                query += $" WHERE {where}";
            return new DatabaseHelper().SelectQuery(query, "Categories");
        }

        public List<Category> GetListCategories() => CategoryHelper.GetFromDataSet(GetCategoriesData());
        public DataSet GetCategories() => GetCategoriesData();
        public Category GetCategory(int id) => CategoryHelper.GetFromDataSet(GetCategoriesData($"id = {id}")).FirstOrDefault();

        public bool CreateCategory(Category category)
        {
            SqlCommand cmd = new SqlCommand("Insert into categories (name) VALUES (@name)");
            cmd.Parameters.AddWithValue("@name", category.Name);
            return new DatabaseHelper().InsertCommand(cmd);
            
        }
        public bool UpdateCategory(Category category)
        {
            SqlCommand cmd = new SqlCommand("Update categories SET name = @name WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", category.Id);
            cmd.Parameters.AddWithValue("@name", category.Name);
            return new DatabaseHelper().UpdateCommand(cmd);
        }
        public bool DeleteCategory(int id)
        {
            return new DatabaseHelper().DeleteQuery($"Delete from categories where id = {id}");
        }
    }
}





