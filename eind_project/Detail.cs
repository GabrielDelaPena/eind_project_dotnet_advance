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
    public partial class Detail : Form
    {
        public Assignment assignment = null;
        public Detail()
        {
            InitializeComponent();
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            AssignmentDAO assignmentDAO = new AssignmentDAO();

            Category category = assignmentDAO.getCatById(assignment.Category_ID);

            title_label.Text = assignment.Title;
            category_label.Text = category.Category_Name;
            desc_label.Text = assignment.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
