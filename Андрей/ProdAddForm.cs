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

namespace Андрей
{
    public partial class ProdAddForm : Form
    {
        public ProdAddForm()
        {
            InitializeComponent();
        }

        static string enterLink = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Terna_Jewellery;Trusted_Connection = True;TrustServerCertificate = True;Data Source=MEPHI3-MSSQL";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connect = new SqlConnection();
                connect.ConnectionString = enterLink;

                connect.Open();
                SqlCommand enter = new SqlCommand();
                enter.CommandType = CommandType.StoredProcedure;
                enter.CommandText = "AddProd";
                enter.Parameters.AddWithValue("@Articule", textBox1.Text);
                enter.Parameters.AddWithValue("@ProductName", textBox2.Text);
                enter.Parameters.AddWithValue("@UnitOfMeasurement", textBox3.Text);
                enter.Parameters.AddWithValue("@Price", textBox4.Text);
                enter.Parameters.AddWithValue("@MaxDiscount", textBox5.Text);
                enter.Parameters.AddWithValue("@Manufacturer", textBox6.Text);
                enter.Parameters.AddWithValue("@Provider", textBox7.Text);
                enter.Parameters.AddWithValue("@Category", textBox8.Text);
                enter.Parameters.AddWithValue("@Discount", textBox9.Text);
                enter.Parameters.AddWithValue("@InStock", textBox10.Text);
                enter.Parameters.AddWithValue("@Description", textBox11.Text);
                enter.Parameters.AddWithValue("@ProductPhoto", textBox12.Text);
                enter.Connection = connect;
                SqlDataReader sqlReader = enter.ExecuteReader();
                sqlReader.Read();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
