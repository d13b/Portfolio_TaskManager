using System;
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

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            DataRow row = data.NewRow();
            row["Task Title"] = txtTaskTitle.Text;
            row["Task Description"] = txtTaskDescription.Text;
            row["Task Status"] = "Incomplete";
            data.Rows.Add(row);
        }

        private void updateTable()
        {
            DataRow row = data.NewRow();
            row["Task Title"] = txtTaskTitle.Text;
            row["Task Description"] = txtTaskDescription.Text;
            row["Task Status"] = "Incomplete";
            data.Rows.Add(row);
        }

        // Sets up the columns for the task list
        private void InitializeTaskTable()
        {
            data.Columns.Add("Task Title");
            data.Columns.Add("Task Description");
            data.Columns.Add("Task Status");
            dgvTasks.DataSource = data;
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTasks.SelectedRows)
            {
                dgvTasks.Rows.RemoveAt(row.Index);
            }
        }
    }
}
