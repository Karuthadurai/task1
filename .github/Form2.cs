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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form4 popup = new Form4();
            popup.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            populategridview();
            populatedropdown();
        }

        private void populategridview()
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-C1O55HH\\SQLEXPRESS01;Initial Catalog = Sale;Integrated Security = True");
            SqlCommand cmd = new SqlCommand("multiselect", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                dataGridView1.DataSource = bsource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void populatedropdown()
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-C1O55HH\\SQLEXPRESS01;Initial Catalog = Sale;Integrated Security = True");
            SqlCommand cmd = new SqlCommand("Select Customer from SaleMaster", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            comboBox1.Items.Clear();    
            while(reader.Read())
            {
                string item = reader["Customer"].ToString();
                comboBox1.Items.Add(item);
            }
            reader.Close();
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-C1O55HH\\SQLEXPRESS01;Initial Catalog = Sale;Integrated Security = True");
            SqlCommand cmd = new SqlCommand("  ", con);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                dataGridView1.DataSource = bsource;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form5 popup = new Form5();
            popup.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            populategridview();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
