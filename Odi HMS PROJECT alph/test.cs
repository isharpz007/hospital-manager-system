using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odi_HMS_PROJECT_alph
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void text_result_Load(object sender, EventArgs e)
        {

        }

        private void CrossBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DocBtn_Click(object sender, EventArgs e)
        {
            Doctor obj = new Doctor();
            obj.Show();
            this.Hide();
        }
    }
}
