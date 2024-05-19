﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ChatBot.Helpers;
using ChatBot.Models;

namespace ChatBot.Services
{
    public class Categorieservice
    {
        private DataSet GetCategoriesData(string where = "")
        {
            string query = "Select * from Categories";
            if (where != "")
                query += $" WHERE {where}";
            return new DatabaseHelper().ExecuteQuery(query, "Categories");
        }

        public List<Category> GetCategories() => CategoryHelper.GetFromDataSet(GetCategoriesData());
        public Category GetCategorie(int id) => CategoryHelper.GetFromDataSet(GetCategoriesData($"id = {id}")).FirstOrDefault();

        public bool CreateCategory(Category category)
        {
            return new DatabaseHelper().ExecuteNonQuery($"Insert into categories (name) VALUES ({category.Name})");
            
        }
        public bool UpdateCategory(Category category)
        {

            return new DatabaseHelper().ExecuteNonQuery($"Update categories SET name = {category.Name} WHERE id = {category.Id}");
        }
        public bool DeleteCategory(Category category)
        {
            return new DatabaseHelper().ExecuteNonQuery($"Delete from categories where id = {category.Id}");
        }
    }
}




