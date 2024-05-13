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

namespace Odi_HMS_PROJECT_alph
{
    public partial class receptionist : Form
    {
        public receptionist()
        {
            InitializeComponent();
            DisplayPatient();
        }

        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\odian\source\repos\Odi HMS PROJECT alph\Odi HMS PROJECT alph\hmsDb.mdf"";Integrated Security=True");
        private void DisplayPatient()
        {
            try
            {
                con.Open();
                string Query = "select * from Patient";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                con.Close();
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox5.Text == " " || comboBox1.Text == " " || comboBox2.Text == " " || textBox6.Text == " ")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();

                    string query = "INSERT INTO Patient (PId, PAge, MajorDisease, PName, PGen, PAddress, PPhone, BloodGroup) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + textBox6.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Entered successfully");
                    DisplayPatient();
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


        private void Patient_Load(object sender, EventArgs e)
        {
            DisplayPatient();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Patient_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox5.Text == " " || textBox7.Text == " " || textBox8.Text == " " || comboBox1.Text == " " || comboBox2.Text == " " || comboBox3.Text == " " || textBox6.Text == " ")
                {
                    MessageBox.Show("Missing Information");
                }

                else
                {
                    con.Open();
                    string query = "update Patient set PName=@PName, PAddress=@PAddress, PAge=@PAge, PPhone=@PPhone, PGen=@PGen, BloodGroup=@BloodGroup, MajorDisease=@MajorDisease SelectDoctor=@SelectDoctor PatientEmail=@PatientEmail PatientDOB=@PatientDOB where PId=@PId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@PAddress", textBox3.Text);
                    cmd.Parameters.AddWithValue("@PAge", textBox4.Text);
                    cmd.Parameters.AddWithValue("@PPhone", textBox5.Text);
                    cmd.Parameters.AddWithValue("@PGen", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@BloodGroup", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@MajorDisease", textBox6.Text);
                    cmd.Parameters.AddWithValue("@PId", textBox1.Text);




                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");
                    DisplayPatient();
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

        private void DelBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " ")
                {
                    MessageBox.Show("Enter the Patients Id");
                }
                else
                {
                    con.Open();
                    string query = "delete from Patient where PId=' " + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted successfully");
                    DisplayPatient();
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

        private void ResetBtn_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            comboBox1.Text = " ";
            comboBox2.Text = " ";
            textBox6.Text = " ";
            comboBox3.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
        }

        private void HomeBtn_Click_1(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView2.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = dataGridView2.SelectedRows[0].Cells[4].Value.ToString();
                comboBox1.Text = dataGridView2.SelectedRows[0].Cells[5].Value.ToString();
                comboBox2.Text = dataGridView2.SelectedRows[0].Cells[6].Value.ToString();
                textBox6.Text = dataGridView2.SelectedRows[0].Cells[7].Value.ToString();
                comboBox3.Text = dataGridView2.SelectedRows[0].Cells[8].Value.ToString();
                textBox7.Text = dataGridView2.SelectedRows[0].Cells[9].Value.ToString();
                textBox8.Text = dataGridView2.SelectedRows[0].Cells[10].Value.ToString();





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

        private void CrossBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Appointment obj = new Appointment();
            obj.Show();
            this.Hide();
        }

        private void PatientBtn_Click(object sender, EventArgs e)
        {

            // Check if both fields are empty
            if (Admin.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else if (Admin.Text == "daniel" && Password.Text == "enter")
            {
                Patient obj = new Patient();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Enter the correct username and password");
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
    
}
