using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace eind_project
{
    internal class AssignmentDAO
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\delap\\OneDrive\\Documents\\ProgVak\\Fase 2\\1ste_Sem\\.NET Advanced\\Eind_Project\\project\\eind_project\\eind_project\\Assignment.mdf\";Integrated Security=True";

        public User getUser(string username, string password)
        {
            User user = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE username=@username AND password=@password");
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Connection = connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        username = reader.GetString(1),
                        password = reader.GetString(2)
                    };
                }
            }

            connection.Close();
            return user;
        }

        public List<Assignment> getListByUser(int user_id)
        {
            List<Assignment> assignmentList = new List<Assignment>();


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [Assignment] WHERE user_id=@user_id");
            command.Parameters.AddWithValue("@user_id", user_id);
            command.Connection = connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Assignment assignment = new Assignment
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Category_ID = reader.GetInt32(2),
                        User_ID = reader.GetInt32(3),
                        Description = reader.GetString(4)
                    };
                    assignmentList.Add(assignment);
                }
            }
            connection.Close();
            return assignmentList;
        }

        public List<Assignment> getByTitle(string title)
        {
            List<Assignment> assignmentList = new List<Assignment>();


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            String searchTerm = "%" + title + "%";

            SqlCommand command = new SqlCommand("SELECT * FROM [Assignment] WHERE title LIKE @search");
            command.Parameters.AddWithValue("@search", searchTerm);
            command.Connection = connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Assignment assignment = new Assignment
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Category_ID = reader.GetInt32(2),
                        User_ID = reader.GetInt32(3),
                        Description = reader.GetString(4)
                    };
                    assignmentList.Add(assignment);
                }
            }

            connection.Close();
            return assignmentList;
        }

        public Assignment getById(int ID)
        {
            Assignment assignment = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [Assignment] WHERE Id=@Id");
            command.Parameters.AddWithValue("@Id", ID);
            command.Connection = connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    assignment = new Assignment
                    {
                        Id = reader.GetInt32(0),
                        Title= reader.GetString(1),
                        Category_ID= reader.GetInt32(2),
                        User_ID= reader.GetInt32(3),
                        Description= reader.GetString(4)
                    };
                }
            }
            connection.Close();
            return assignment;
        }

        public Category getCatById(int ID)
        {
            Category category = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [Category] WHERE Id=@Id");
            command.Parameters.AddWithValue("@Id", ID);
            command.Connection = connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    category = new Category
                    {
                        Id = reader.GetInt32(0),
                        Category_Name= reader.GetString(1),
                    };
                }
            }

            connection.Close();
            return category;
        }

        public Category getCatByName(string name)
        {
            Category category = null;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM [Category] WHERE category_name=@category_name");
            command.Parameters.AddWithValue("@category_name", name);
            command.Connection = connection;

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    category = new Category
                    {
                        Id = reader.GetInt32(0),
                        Category_Name = reader.GetString(1),
                    };
                }
            }

            connection.Close();
            return category;
        }

        public void updateAssignment(Assignment newAssignment, int assignmentID)
        { 

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE Assignment SET title=@title, category_id=@category_id, user_id=@user_id, description=@description WHERE Id=@Id", connection);
            command.Parameters.AddWithValue("@Id", assignmentID);
            command.Parameters.AddWithValue("@title", newAssignment.Title);
            command.Parameters.AddWithValue("@category_id", newAssignment.Category_ID);
            command.Parameters.AddWithValue("@user_id", newAssignment.User_ID);
            command.Parameters.AddWithValue("@description", newAssignment.Description);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void deleteAssignmet(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM Assignment WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void addAssignment(Assignment newAssignment)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Assignment (title, category_id, user_id, description) VALUES (@title, @category_id, @user_id, @description)", connection);
            command.Parameters.AddWithValue("@title", newAssignment.Title);
            command.Parameters.AddWithValue("@category_id", newAssignment.Category_ID);
            command.Parameters.AddWithValue("@user_id", newAssignment.User_ID);
            command.Parameters.AddWithValue("@description", newAssignment.Description);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
