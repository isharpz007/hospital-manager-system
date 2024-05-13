using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Odi_HMS_PROJECT_alph
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
            DisplayDoctor();
        }

        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\odian\source\repos\Odi HMS PROJECT alph\Odi HMS PROJECT alph\hmsDb.mdf"";Integrated Security=True");
        private void DisplayDoctor()
        {
            try
            {
                con.Open();
                string Query = "select * from Doctor";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
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
        private void CrossBtn_Click(object sender, EventArgs e)
        {

        }

        private void CrossBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || comboBox1.Text == " " || textBox5.Text == " " || textBox4.Text == " ")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "insert into Doctor Values(' " + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Entered successfully");
                    DisplayDoctor();
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

        private void Doctor_Load(object sender, EventArgs e)
        {
            DisplayDoctor();
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " ")
                {
                    MessageBox.Show("Enter the Doctor Id");
                }
                else
                {
                    con.Open();
                    string query = "delete from Doctor where DocId=' " + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted successfully");
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

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || comboBox1.Text == " " || textBox5.Text == " " || textBox4.Text == " ")
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "update Doctor set DocName =@DocName, DocGen= @DocGen, Experience=@Experience, Licensce=@Licensce where DocId = @DocId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@DocName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@DocGen", comboBox1.Text);
                    cmd.Parameters.AddWithValue("Experience", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Licensce", textBox5.Text);
                    cmd.Parameters.AddWithValue("@DocId", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");
                    DisplayDoctor();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void DiagBtn_Click(object sender, EventArgs e)
        {
            Diagnosis obj = new Diagnosis();
            obj.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
