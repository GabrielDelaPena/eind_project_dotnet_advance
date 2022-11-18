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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            PasswordTxt.PasswordChar = '*';
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTxt.Text == "" || PasswordTxt.Text == "")
            {
                MessageBox.Show("Some fields are empty!");
                return;
            }

            AssignmentDAO assignmentDAO = new AssignmentDAO();

            User newUser = new User
            {
                username = UsernameTxt.Text,
                password = PasswordTxt.Text,
            };

            assignmentDAO.addUser(newUser);
            MessageBox.Show("Register successfully!");
            MessageBox.Show("Please login!");
            this.Close();
        }
    }
}
