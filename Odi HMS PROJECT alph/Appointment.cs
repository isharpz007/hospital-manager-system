using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Odi_HMS_PROJECT_alph
{
    public partial class Appointment : Form
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\odian\source\repos\Odi HMS PROJECT alph\Odi HMS PROJECT alph\hmsDb.mdf;Integrated Security=True");

        public Appointment()
        {
            InitializeComponent();
            DisplayAppointment();
        }

        private void DisplayAppointment()
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Appointment";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                // Bind the DataTable to your DataGridView or any other control to display the appointments.
                // For example:
                // dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (!UserAgrees())
                return;

            TryAddAppointment();
        }

        private bool UserAgrees()
        {
            var result = MessageBox.Show("Do you agree to the terms and conditions?", "Agreement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("You agreed.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("You did not agree.", "Agreement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void TryAddAppointment()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Missing Information");
                return;
            }

            try
            {
                con.Open();
                string query = "INSERT INTO Appointment (Date, Time, Purpose, Statue) VALUES (@Date, @Time, @Purpose, @Statue)";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Date", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Time", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Purpose", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Statue", textBox5.Text.Trim());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Appointment has been successfully booked. We take your privacy seriously. Thank you for trusting us with your information!");
                }
                DisplayAppointment();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestBtn_Click(object sender, EventArgs e)
        {
            test obj = new test();
            obj.Show();
            this.Hide();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " ")
                {
                    MessageBox.Show("Enter the Appointment Id");
                }
                else
                {
                    con.Open();
                    string query = "delete from Appointment where Appointment_ID=' " + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted successfully");
                    DisplayAppointment();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox5.Text == " " || textBox6.Text == " ")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "update Patient set  Patient_ID=@Patient_ID, Date=@Date, Time=@Time, Purpose=@Purpose, Status=@Statue where Appointment_ID=@Appointment_ID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Date", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Time", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Purpose", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Statuse", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Patient_ID", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Appointment_ID", textBox1.Text);



                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("EDIT Successfully");
                    DisplayAppointment();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}

