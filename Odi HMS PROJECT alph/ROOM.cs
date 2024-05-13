using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Odi_HMS_PROJECT_alph
{
    public partial class ROOM : Form
    {
        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\odian\source\repos\Odi HMS PROJECT alph\Odi HMS PROJECT alph\hmsDb.mdf"";Integrated Security=True");

        public ROOM()
        {
            InitializeComponent();
            DisplayRoom();
        }

        private void DisplayRoom()
        {
            try
            {
                con.Open();
                string Query = "select * from Room";
                SqlDataAdapter sda = new SqlDataAdapter(Query, con);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
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
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
                {
                    MessageBox.Show("Missing Information");
                    return;
                }

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string query = "insert into Room Values(@patientId, @patientPhone, @patientName, @gender, @roomNumber)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@patientId", textBox1.Text);
                cmd.Parameters.AddWithValue("@patientPhone", textBox2.Text);
                cmd.Parameters.AddWithValue("@patientName", textBox3.Text);
                cmd.Parameters.AddWithValue("@gender", textBox4.Text);
                cmd.Parameters.AddWithValue("@roomNumber", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Entered successfully");
                DisplayRoom();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " ")
                {
                    MessageBox.Show("Enter the Room Id");
                }
                else
                {
                    con.Open();
                    string query = "delete from Room where PatientId=' " + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Room Deleted successfully");
                    DisplayRoom();
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ROOM_Load(object sender, EventArgs e)
        {

        }
    }
}
