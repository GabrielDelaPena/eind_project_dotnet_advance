using System.Data;
using System.Data.SqlClient;

namespace eind_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PasswordTxt.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            AssignmentDAO assignmentDAO = new AssignmentDAO();

            if (assignmentDAO.getUser(UsernameTxt.Text, PasswordTxt.Text) == null)
            {
                MessageBox.Show("Incorrect username or password.");
                UsernameTxt.Clear();
                PasswordTxt.Clear();
                return;
            }

            home.currentUser = assignmentDAO.getUser(UsernameTxt.Text, PasswordTxt.Text);

            home.Show();
            this.Hide();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            
        }
    }
}