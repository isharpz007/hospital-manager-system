using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Odi_HMS_PROJECT_alph
{
    public partial class Room2 : Form
    {
        // Declare SqlConnection object
        private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\odian\source\repos\Odi HMS PROJECT alph\Odi HMS PROJECT alph\hmsDb.mdf"";Integrated Security=True");

        public Room2()
        {
            InitializeComponent();
            DisplayRoom2();
        }

        private void DisplayRoom2()
        {
            try
            {
                con.Open();
                string Query = "select * from Room2";
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
                DisplayRoom2();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    textBox1.Text = row.Cells[0].Value.ToString();
                    textBox2.Text = row.Cells[1].Value.ToString();
                    textBox3.Text = row.Cells[2].Value.ToString();
                    textBox4.Text = row.Cells[3].Value.ToString();
                    textBox5.Text = row.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Enter the Room2 Id");
                }
                else
                {
                    con.Open();
                    string query = "delete from Room where PatientId = @patientId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@patientId", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Room Deleted successfully");
                    DisplayRoom2();
                }
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
    }
}
