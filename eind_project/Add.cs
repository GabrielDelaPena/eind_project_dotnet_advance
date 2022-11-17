using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eind_project
{
    public partial class Add : Form
    {
        public User currentUser = null;
        public Add()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (title_input.Text == "" || desc_input.Text == "" || cat_checklist.CheckedItems.Count == 0)
            {
                MessageBox.Show("Some fields are empty!");
                return;
            }

            AssignmentDAO assignmentDAO = new AssignmentDAO();

            string selectedCat = "";

            foreach (string item in cat_checklist.CheckedItems)
            {
                selectedCat = item;
            }

            int categoryID = assignmentDAO.getCatByName(selectedCat).Id;

            Assignment newAssignment = new Assignment
            {
                Title = title_input.Text,
                Category_ID = categoryID,
                User_ID = currentUser.Id,
                Description = desc_input.Text,
            };

            assignmentDAO.addAssignment(newAssignment);
            MessageBox.Show("New assignment added.");
            MessageBox.Show("Please refresh to update the list.");

            this.Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
