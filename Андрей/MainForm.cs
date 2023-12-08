using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Андрей
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Строка подключения
        static string enterLink = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Terna_Jewellery;Trusted_Connection = True;TrustServerCertificate = True;Data Source=MEPHI3-MSSQL";
        DataTable dt = new DataTable();

        //Вывод таблицы с товарами при загрузке формы
        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label1.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = enterLink;
                con.Open();

                //Вывод кол-ва строк из таблицы продуктов
                SqlCommand prodCount = new SqlCommand();
                string Count = "Select count(*) From Product";
                prodCount.Connection = con;
                prodCount.CommandType = CommandType.Text;
                prodCount.CommandText = Count;
                SqlDataReader reader = prodCount.ExecuteReader();
                label10.Text = $"{dataGridView1.DisplayedRowCount(true)}/{reader.Read()}";

                //Вывод таблицы в dataGridView
                string select = "Select ArticuleId as 'Артикул', ProductName as 'Название', UnitOfMeasurement as 'Единицы счистления', Price as 'Цена без скидки', (Price - ((Price / 100)*Discount)) as 'Цена со скидкой', Discount as 'Скидка', Manufacturer as 'Производитель',Description as 'Описание товара', Category as' Категория', ProductPhoto as 'Фото товара' From Product";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = select;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dt = new DataTable("Product");
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.RowHeadersVisible = false;
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }

            //Изменение цвета клеток с большой скидкой
            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (Convert.ToInt32(row.Cells[5].Value) > 15) //проверка скидки каждого продукта
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(byte)(127)), ((int)(byte)(255)), ((int)(byte)(0)));
                }
            //Не помню что это
            SqlCommand prodView = new SqlCommand();
        }

        //Кнопка возврата к окну входа
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Run(new Form1());
        }

        //Вывод данных о товаре и фото товара при нажатии клетки в датагриде 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != null & e.RowIndex != -1)
                {
                    DataGridViewRow productDate = dataGridView1.Rows[e.RowIndex];
                    label6.Text = productDate.Cells[7].Value.ToString();
                    label7.Text = productDate.Cells[6].Value.ToString();
                    label8.Text = productDate.Cells[4].Value.ToString();
                    if (productDate.Cells[9].Value.ToString() != "")
                    {
                        //String imageName = Properties.Resources.productDate.Cells[9].Value.ToString();
                        //Здесь нужно поменять путь к фотографиям

                        String imageName = "D:\\Андрей\\" + productDate.Cells[9].Value.ToString();
                        pictureBox1.Image = Image.FromFile(imageName);
                    }

                    else
                    {
                        //String imageName = Properties.Resources.picture as Bitmap;
                        String imageName = "D:\\Андрей\\" + "picture.png";
                        pictureBox1.Image = Image.FromFile(imageName);
                    }
                    label1.Text = productDate.Cells[5].Value.ToString() + "%";
                }
            }
            catch { Exception ex; }
        }

        //Поисковая строка по имени
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "Название" + " like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = bs;
        }
        //Фильтр по скидке
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = enterLink;
            con.Open();

            int discountIndex = comboBox1.SelectedIndex;
            switch (discountIndex)
            {
                //Все диапазоны
                case 0:
                    try
                    {
                        //Запрос из бд таблиц вместе с условием для скидки
                        string select = "Select ArticuleId as 'Артикул', ProductName as 'Название', UnitOfMeasurement as 'Единицы счистления', Price as 'Цена без скидки', (Price - ((Price / 100)*Discount)) as 'Цена со скидкой', Discount as 'Скидка', Manufacturer as 'Производитель',Description as 'Описание товара', Category as' Категория', ProductPhoto as 'Фото товара' From Product";

                        BindingSource bs = new BindingSource();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = select;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        dt = new DataTable("Product");
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.RowHeadersVisible = false;

                        //Сохранение фильтра с названием, чтобы когда фильтр скидки менялся, фильтр по названию не слетал
                        bs.DataSource = dataGridView1.DataSource;
                        bs.Filter = "Название" + " like '%" + textBox1.Text + "%'";
                        dataGridView1.DataSource = bs;
                        con.Close();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                    break;

                // 0-9,99%
                case 1:
                    try
                    {
                        string select = "Select ArticuleId as 'Артикул', ProductName as 'Название', UnitOfMeasurement as 'Единицы счистления', Price as 'Цена без скидки', (Price - ((Price / 100)*Discount)) as 'Цена со скидкой', Discount as 'Скидка', Manufacturer as 'Производитель',Description as 'Описание товара', Category as' Категория', ProductPhoto as 'Фото товара' From Product where Discount < 10";

                        BindingSource bs = new BindingSource();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = select;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        dt = new DataTable("Product");
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.RowHeadersVisible = false;

                        bs.DataSource = dataGridView1.DataSource;
                        bs.Filter = "Название" + " like '%" + textBox1.Text + "%'";
                        dataGridView1.DataSource = bs;
                        con.Close();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                    break;

                // 10-14,99%
                case 2:
                    try
                    {
                        string select = "Select ArticuleId as 'Артикул', ProductName as 'Название', UnitOfMeasurement as 'Единицы счистления', Price as 'Цена без скидки', (Price - ((Price / 100)*Discount)) as 'Цена со скидкой', Discount as 'Скидка', Manufacturer as 'Производитель',Description as 'Описание товара', Category as' Категория', ProductPhoto as 'Фото товара' From Product Where Discount >= 10 and Discount < 15";

                        BindingSource bs = new BindingSource();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = select;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        dt = new DataTable("Product");
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.RowHeadersVisible = false;

                        bs.DataSource = dataGridView1.DataSource;
                        bs.Filter = "Название" + " like '%" + textBox1.Text + "%'";
                        dataGridView1.DataSource = bs;
                        con.Close();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                    break;

                // 15% и более
                case 3:
                    try
                    {
                        string select = "Select ArticuleId as 'Артикул', ProductName as 'Название', UnitOfMeasurement as 'Единицы счистления', Price as 'Цена без скидки', (Price - ((Price / 100)*Discount)) as 'Цена со скидкой', Discount as 'Скидка', Manufacturer as 'Производитель',Description as 'Описание товара', Category as' Категория', ProductPhoto as 'Фото товара' From Product Where Discount >= 15";

                        BindingSource bs = new BindingSource();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = select;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        dt = new DataTable("Product");
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.RowHeadersVisible = false;

                        bs.DataSource = dataGridView1.DataSource;
                        bs.Filter = "Название" + " like '%" + textBox1.Text + "%'";
                        dataGridView1.DataSource = bs;
                        con.Close();
                    }
                    catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
                    break;
            }
        }

        //Переход к добавлению товара
        private void button2_Click(object sender, EventArgs e)
        {
            ProdAddForm prodAddForm = new ProdAddForm();
            prodAddForm.Show();
        }

        //Переход к корзине
        private void button3_Click(object sender, EventArgs e)
        {
            BascetForm bForm = new BascetForm();
            bForm.Show();
        }


        //Это прост я случайно нажал и все ☻

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
