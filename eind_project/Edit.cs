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
    public partial class Edit : Form
    {
        public Assignment assignment = null;
        BindingSource assignmentBindingSource = new BindingSource();
        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            AssignmentDAO assignmentDAO = new AssignmentDAO();
            Category category = assignmentDAO.getCatById(assignment.Category_ID);
            
            title_textbox.Text = assignment.Title;
            cat_checklist.SetItemChecked((category.Id - 1), true);
            desc_textbox.Text = assignment.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (title_textbox.Text == "" || desc_textbox.Text == "" || cat_checklist.CheckedItems.Count == 0)
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

            Assignment updatedAssignment = new Assignment
            {
                Title = title_textbox.Text,
                Category_ID = categoryID,
                User_ID = assignment.User_ID,
                Description = desc_textbox.Text,
            };

            assignmentDAO.updateAssignment(updatedAssignment, assignment.Id);
            MessageBox.Show("The assignment has been updated.");
            MessageBox.Show("Please refresh to update the assignment list.");
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
