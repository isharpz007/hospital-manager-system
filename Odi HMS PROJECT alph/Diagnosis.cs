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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Odi_HMS_PROJECT_alph
{
    public partial class Diagnosis : Form
    {
        public Diagnosis()
        {
            InitializeComponent();
            DisplayDiagnosis();
        }
        readonly SqlConnection con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\odian\source\repos\Odi HMS PROJECT alph\Odi HMS PROJECT alph\hmsDb.mdf"";Integrated Security=True");
        private void DisplayDiagnosis()
        {
            try
            {
                con.Open();
                string Query = "select * from Diagnosis";
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


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox5.Text == " " || textBox6.Text == " " || comboBox1.Text == " " )
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "insert into Diagnosis Values(' " + textBox1.Text + "', '" + comboBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "','" + textBox5.Text + "' ,  '" + textBox6 + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Entered successfully");
                    DisplayDiagnosis();
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
            if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox5.Text == " " || textBox6.Text == " " || comboBox1.Text == " ")
            {
                MessageBox.Show("Missing Information");
            }
            try
            {
                if (textBox1.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || textBox5.Text == " " || comboBox1.Text == " " || textBox6.Text == " " )
                {
                    MessageBox.Show("Missing Information");
                }
                else
                {
                    con.Open();
                    string query = "update Diagnsis set PatientId=@PatientId, PatientName=@PatientName, Symptoms=@S, DiagnosticTest=@D, Medicines=@M, Appointment_Id=@AId, ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PatientId", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@PatientName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@S", textBox3.Text);
                    cmd.Parameters.AddWithValue("@D", textBox4.Text);
                    cmd.Parameters.AddWithValue("@M", textBox5.Text);
                    cmd.Parameters.AddWithValue("@AId", textBox6.Text);
                   



                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated Successfully");
                    DisplayDiagnosis();
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

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " ")
                {
                    MessageBox.Show("Enter the Diagnosis Id");
                }
                else
                {
                    con.Open();
                    string query = "delete from Diagnosis where DId=' " + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted successfully");
                    DisplayDiagnosis();
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

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            comboBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();



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

        private void Diagnosis_Load(object sender, EventArgs e)
        {
            DisplayDiagnosis();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayPatientName();
        }
        string pname;
        void DisplayPatientName()
        {
            try
            {
                con.Open();
                string ss = "select * from patient where  PId =" + comboBox1.SelectedValue.ToString();

                SqlCommand cmd = new SqlCommand(ss, con);
                DataTable dt = new DataTable();
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    pname = dr["PName"].ToString();
                    textBox2.Text = pname;

                }
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
            this.Close();
        }

        private void DocBtn_Click(object sender, EventArgs e)
        {
            Patient obj = new Patient();
            obj.Show();
            this.Hide();
        }
    }
    
}
