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

namespace SalesProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-C1O55HH\\SQLEXPRESS01;Initial Catalog = Sale;Integrated Security = True");
            con.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("Select username,password from Users where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Success - Welcome to Entry Page");
                this.Hide();
                Form2 page = new Form2();
                page.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login Check Details");
            }
            con.Close();

        }
    }
}
