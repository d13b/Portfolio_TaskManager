﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Portfolio_TaskManager
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            InitializeTaskTable();
        }

        DataTable data = new DataTable();
        int indexRow;

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            DataRow row = data.NewRow();
            row["Task Title"] = txtTaskTitle.Text;
            row["Task Description"] = txtTaskDescription.Text;
            row["Task Status"] = "Incomplete";
            data.Rows.Add(row);
            clearTextBoxes();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = dgvTasks.Rows[indexRow];
            newDataRow.Cells[0].Value = txtTaskTitle.Text;
            newDataRow.Cells[1].Value = txtTaskDescription.Text;
            clearTextBoxes();
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTasks.SelectedRows)
            {
                dgvTasks.Rows.RemoveAt(row.Index);
            }
            clearTextBoxes();
        }

        private void dgvTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dgvTasks.Rows[indexRow];

            txtTaskTitle.Text = row.Cells[0].Value.ToString();
            txtTaskDescription.Text = row.Cells[1].Value.ToString();
        }


        // All Clicks Are to be Above Reusable Code. Otherwise it's not neat.

        // Sets up the columns for the task list
        private void InitializeTaskTable()
        {
            data.Columns.Add("Task Title");
            data.Columns.Add("Task Description");
            data.Columns.Add("Task Status");
            dgvTasks.DataSource = data;
        }

        // Quality of life for end user - Clear Text Boxes from Input
        private void clearTextBoxes()
        {
            txtTaskTitle.Text = "";
            txtTaskDescription.Text = "";
        }
    }
}
