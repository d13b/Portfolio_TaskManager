using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        DataTable TaskList = new DataTable();

        private void formMain_Load(object sender, EventArgs e)
        {
            //Column Creation
            TaskList.Columns.Add("Title");
            TaskList.Columns.Add("Description");
            dgvTasks.DataSource = TaskList;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            // Emptying textboxes for Quality of Life
            txtTaskTitle.Text = "";
            txtTaskDescription.Text = "";
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            txtTaskTitle.Text = TaskList.Rows[dgvTasks.CurrentCell.RowIndex].ItemArray[0].ToString();
            txtTaskDescription.Text = TaskList.Rows[dgvTasks.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            try
            {
                TaskList.Rows[dgvTasks.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                MessageBox.Show("An error has occured and deletion has failed: " +ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
