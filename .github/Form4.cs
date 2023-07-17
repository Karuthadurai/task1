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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int QTY = Convert.ToInt32(textBox5.Text);
            int Tax = Convert.ToInt32(comboBox1.SelectedItem);
            int Price = Convert.ToInt32(textBox4.Text);
            int Total = QTY * Price + (Price / Tax) ;

            SqlConnection con = new SqlConnection("Data Source = DESKTOP-C1O55HH\\SQLEXPRESS01;Initial Catalog = Sale;Integrated Security = True");
            SqlCommand cmd = new SqlCommand("MultiInsert",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ItemNo",textBox1.Text);
            cmd.Parameters.AddWithValue("@ItemName",textBox2.Text);
            cmd.Parameters.AddWithValue("@QTY",QTY);
            cmd.Parameters.AddWithValue("@Tax",Tax);
            cmd.Parameters.AddWithValue("@Price",Price);
            cmd.Parameters.AddWithValue("@Customer",textBox3.Text);
            cmd.Parameters.AddWithValue("@Date",dateTimePicker1.Value.ToShortDateString());
            cmd.Parameters.AddWithValue("@Total",Total);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
                this.Close();
            }
        }
    }
}
