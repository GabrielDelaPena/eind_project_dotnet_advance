using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eind_project
{
    public partial class Home : Form
    {
        BindingSource assignmentBindingSource = new BindingSource();
        public User currentUser = null;
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            AssignmentDAO assignmentDAO = new AssignmentDAO();
            UsernameLabel.Text = currentUser.username;

            List<Assignment> assignmentList = assignmentDAO.getListByUser(currentUser.Id);

            foreach (Assignment assignment in assignmentList)
            {
                dataGridView1.Rows.Add(assignment.Id, assignment.Title);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AssignmentDAO assignmentDAO = new AssignmentDAO();
            List<Assignment> assignmentList = assignmentDAO.getByTitle(SearchInput.Text);

            dataGridView1.Rows.Clear();

            foreach (Assignment assignment in assignmentList)
            {
                dataGridView1.Rows.Add(assignment.Id, assignment.Title);
            }
            SearchInput.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AssignmentDAO assignmentDAO = new AssignmentDAO();

            List<Assignment> assignmentList = assignmentDAO.getListByUser(currentUser.Id);

            dataGridView1.Rows.Clear();

            foreach (Assignment assignment in assignmentList)
            {
                dataGridView1.Rows.Add(assignment.Id, assignment.Title);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssignmentDAO assignmentDAO = new AssignmentDAO();

            int rowClickedIndex = dataGridView1.CurrentRow.Index;

            int assignmentID = (int)dataGridView1.Rows[rowClickedIndex].Cells[0].Value;

            Assignment detailAssignment = assignmentDAO.getById(assignmentID);

            Detail detail = new Detail();
            detail.assignment = detailAssignment;
            detail.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AssignmentDAO assignmentDAO = new AssignmentDAO();

            int rowClickedIndex = dataGridView1.CurrentRow.Index;

            int assignmentID = (int)dataGridView1.Rows[rowClickedIndex].Cells[0].Value;

            Assignment detailAssignment = assignmentDAO.getById(assignmentID);

            Edit edit = new Edit();
            edit.assignment = detailAssignment;
            edit.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AssignmentDAO assignmentDAO = new AssignmentDAO();

            int rowClickedIndex = dataGridView1.CurrentRow.Index;

            int assignmentID = (int)dataGridView1.Rows[rowClickedIndex].Cells[0].Value;

            assignmentDAO.deleteAssignmet(assignmentID);
            MessageBox.Show("The assignment has been deleted.");
            MessageBox.Show("Please click on refresh to update Assignment list.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.currentUser = currentUser;
            add.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            currentUser = null;
            MessageBox.Show("Logout successfull!");
            this.Hide();
            form1.Show();
        }
    }
}
