﻿using ChatBot.Models;
using ChatBot.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatBot.Forms.Views.Admin
{
    public partial class CategoriesForm : Form
    {
        private readonly CategoryService _categoryService = new CategoryService();

        public CategoriesForm()
        {
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            PrepareDataGridView();
            LoadCategories();

            bindingNavigatorCategories.BindingSource = bindingSourceCategories;
        }

        private void PrepareDataGridView()
        {
            dataGridViewCategories.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "name" });
        }

        private void LoadCategories()
        {
            DataSet dataSet = _categoryService.GetCategories();
            bindingSourceCategories.DataSource = dataSet.Tables["categories"];
            dataGridViewCategories.DataSource = bindingSourceCategories;
            dataGridViewCategories.Columns[0].Visible = false;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewCategories.EndEdit();

            if (dataGridViewCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCategories.SelectedRows[0];

                if (selectedRow.IsNewRow || selectedRow.Index == dataGridViewCategories.Rows.Count - 1)
                {
                    MessageBox.Show("Select not empty row!");
                    return;
                }

                var categoryID = selectedRow.Cells["id"].Value;

                if (categoryID == null || string.IsNullOrEmpty(categoryID.ToString()))
                {
                    MessageBox.Show("You cannot delete a categoryID with an empty or null ID!");
                    return;
                }

                _categoryService.DeleteCategory((int)categoryID);
                LoadCategories();
            }
            else
            {
                MessageBox.Show("No row selected!");
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewCategories.EndEdit();

            if (dataGridViewCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCategories.SelectedRows[0];

                var name = (string)selectedRow.Cells[1].Value;
  
                var category = new Models.Category(name);

                _categoryService.CreateCategory(category);
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dataGridViewCategories.EndEdit();

            if (dataGridViewCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCategories.SelectedRows[0];

                var name = (string)selectedRow.Cells[1].Value;
                var categoryID = (int)selectedRow.Cells[0].Value;

                var category = new Models.Category(categoryID, name);

                _categoryService.UpdateCategory(category);
            }
        }
    }
}
