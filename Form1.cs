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
        }

        DataTable TaskList = new DataTable();

        private void formMain_Load(object sender, EventArgs e)
        {
            //Column Creation/Recreation
            TaskList.Columns.Add("Title");
            TaskList.Columns.Add("Description");
            dgvTasks.DataSource = TaskList;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            // Emptying textboxes for Quality of Life
            refresh();
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
                if(dgvTasks.CurrentCell != null)
                {
                    TaskList.Rows[dgvTasks.CurrentCell.RowIndex].Delete(); 
                }
                else
                {
                    MessageBox.Show("Please Select Task To Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                MessageBox.Show("An error has occured and deletion has failed: " +ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void refresh()
        {
            // Refresh the datagridview to ensure new data is present in the UI.
            dgvTasks.Refresh();

            // Emptying textboxes for Quality of Life
            txtTaskTitle.Text = "";
            txtTaskDescription.Text = "";
        }
    }
}
