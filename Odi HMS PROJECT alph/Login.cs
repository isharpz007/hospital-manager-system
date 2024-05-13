using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Odi_HMS_PROJECT_alph
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ClrBtn_Click(object sender, EventArgs e)
        {
            Admin.Text = " ";
            Password.Text = " ";
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\odian\\source\\repos\\Odi HMS PROJECT alph\\Odi HMS PROJECT alph\\hmsDb.mdf\";Integrated Security=True";

            try
            {
                // Create the connection object with the connection string
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Define the SQL command with SQL parameters
                    string sql = "SELECT COUNT(1) FROM [dbo].[Register] WHERE [username] = @Username AND [password] = @Password";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", Admin.Text);
                        cmd.Parameters.AddWithValue("@Password", Password.Text);

                        // Open the connection
                        con.Open();

                        // Execute the query
                        int count = (int)cmd.ExecuteScalar();

                        if (count == 1)
                        {
                            // If login is successful, proceed to next form
                            Home obj = new Home();
                            obj.Show();
                            this.Hide();
                            MessageBox.Show("Login Successful");
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any potential errors
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void doctorBtn_Click(object sender, EventArgs e)
        {
            // Check if both fields are empty
            if (Admin.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (Admin.Text == "daniel" && Password.Text == "enter")
            {
                Doctor obj = new Doctor();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Enter the correct username and password");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Check if both fields are empty
            if (Admin.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Define the connection string
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\odian\\source\\repos\\Odi HMS PROJECT alph\\Odi HMS PROJECT alph\\hmsDb.mdf\";Integrated Security=True";

                try
                {
                    // Create the connection object with the connection string
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Define the SQL command with SQL parameters
                        string sql = "SELECT COUNT(1) FROM [dbo].[Register] WHERE [username] = @Username AND [password] = @Password";

                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            // Add parameters to prevent SQL injection
                            cmd.Parameters.AddWithValue("@Username", Admin.Text);
                            cmd.Parameters.AddWithValue("@Password", Password.Text);

                            // Open the connection
                            con.Open();

                            // Execute the query
                            int count = (int)cmd.ExecuteScalar();

                            if (count == 1)
                            {
                                MessageBox.Show("Login Successful");

                                // Proceed to Doctor form
                                Doctor obj = new Doctor();
                                obj.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any potential errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            {
                Appointment obj = new Appointment();
                obj.Show();
                this.Hide();
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Check if both fields are empty
            if (Admin.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Define the connection string
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\odian\\source\\repos\\Odi HMS PROJECT alph\\Odi HMS PROJECT alph\\hmsDb.mdf\";Integrated Security=True";

                try
                {
                    // Create the connection object with the connection string
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Define the SQL command with SQL parameters
                        string sql = "SELECT COUNT(1) FROM [dbo].[Register] WHERE [username] = @Username AND [password] = @Password";

                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            // Add parameters to prevent SQL injection
                            cmd.Parameters.AddWithValue("@Username", Admin.Text);
                            cmd.Parameters.AddWithValue("@Password", Password.Text);

                            // Open the connection
                            con.Open();

                            // Execute the query
                            int count = (int)cmd.ExecuteScalar();

                            if (count == 1)
                            {
                                MessageBox.Show("Login Successful");

                                // Proceed to Doctor form
                                receptionist obj = new receptionist();
                                obj.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any potential errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            // Check if both fields are empty
            if (Admin.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Define the connection string
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\odian\\source\\repos\\Odi HMS PROJECT alph\\Odi HMS PROJECT alph\\hmsDb.mdf\";Integrated Security=True";

                try
                {
                    // Create the connection object with the connection string
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Define the SQL command with SQL parameters
                        string sql = "SELECT COUNT(1) FROM [dbo].[Register] WHERE [username] = @Username AND [password] = @Password";

                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            // Add parameters to prevent SQL injection
                            cmd.Parameters.AddWithValue("@Username", Admin.Text);
                            cmd.Parameters.AddWithValue("@Password", Password.Text);

                            // Open the connection
                            con.Open();

                            // Execute the query
                            int count = (int)cmd.ExecuteScalar();

                            if (count == 1)
                            {
                                MessageBox.Show("Login Successful");

                                // Proceed to Doctor form
                                Home obj = new Home();
                                obj.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any potential errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            // Check if both fields are empty
            if (Admin.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Define the connection string
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\odian\\source\\repos\\Odi HMS PROJECT alph\\Odi HMS PROJECT alph\\hmsDb.mdf\";Integrated Security=True";

                try
                {
                    // Create the connection object with the connection string
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Define the SQL command with SQL parameters
                        string sql = "SELECT COUNT(1) FROM [dbo].[Register] WHERE [username] = @Username AND [password] = @Password";

                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            // Add parameters to prevent SQL injection
                            cmd.Parameters.AddWithValue("@Username", Admin.Text);
                            cmd.Parameters.AddWithValue("@Password", Password.Text);

                            // Open the connection
                            con.Open();

                            // Execute the query
                            int count = (int)cmd.ExecuteScalar();

                            if (count == 1)
                            {
                                MessageBox.Show("Login Successful");

                                // Proceed to Doctor form
                                Home obj = new Home();
                                obj.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any potential errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Check if both fields are empty
            if (Admin.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                // Define the connection string
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\odian\\source\\repos\\Odi HMS PROJECT alph\\Odi HMS PROJECT alph\\hmsDb.mdf\";Integrated Security=True";

                try
                {
                    // Create the connection object with the connection string
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Define the SQL command with SQL parameters
                        string sql = "SELECT COUNT(1) FROM [dbo].[Register] WHERE [username] = @Username AND [password] = @Password";

                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            // Add parameters to prevent SQL injection
                            cmd.Parameters.AddWithValue("@Username", Admin.Text);
                            cmd.Parameters.AddWithValue("@Password", Password.Text);

                            // Open the connection
                            con.Open();

                            // Execute the query
                            int count = (int)cmd.ExecuteScalar();

                            if (count == 1)
                            {
                                MessageBox.Show("Login Successful");

                                // Proceed to Doctor form
                                Home obj = new Home();
                                obj.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username or Password");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any potential errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Register obj = new Register();
            obj.Show();
            this.Hide();
        }
    }
}
