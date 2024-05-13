using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Odi_HMS_PROJECT_alph
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        // Register Form
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\odian\\source\\repos\\Odi HMS PROJECT alph\\Odi HMS PROJECT alph\\hmsDb.mdf\";Integrated Security=True";

            try
            {
                // Create the connection object with the connection string
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Define the SQL command with SQL parameters
                    string sql = @"INSERT INTO [dbo].[Register]
                           ([firstname], [lastname], [address], [gender], [email], [phone], [username], [password])
                           VALUES
                           (@FirstName, @LastName, @Address, @Gender, @Email, @Phone, @Username, @Password)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@FirstName", txtFname.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLname.Text);
                        cmd.Parameters.AddWithValue("@Address", txtA.Text);
                        cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem.ToString()); // Assuming you have a ComboBox for gender
                        cmd.Parameters.AddWithValue("@Email", txtE.Text);
                        cmd.Parameters.AddWithValue("@Phone", txtP.Text);
                        cmd.Parameters.AddWithValue("@Username", txtUname.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                        // Open the connection
                        con.Open();

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Close the connection automatically by 'using' statement
                    }
                }

                // Show success message
                MessageBox.Show("Registered Successfully");

                // After registration, show the login form
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Handle any potential errors
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
        }
    }
}

