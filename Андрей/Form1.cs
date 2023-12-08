using System.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Web;

namespace Андрей
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Строка подключения (нужно поменять на всякий)
        static string enterLink = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Terna_Jewellery;Trusted_Connection = True;TrustServerCertificate = True;Data Source=MEPHI3-MSSQL";
        MainForm mainF = new MainForm();

        int troubles = 0;
        int s = 10;

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = enterLink;
            connect.Open();
        }

        //Кнопка входа с функцией приветствия в зависимости от времени устройства для зарегестрированного пользователя
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = enterLink;

            string hello;
            DateTime dateTime = DateTime.Now;
            if (dateTime.Hour >= 0 && dateTime.Hour <= 6)
            {
                hello = "Доброй ночи";
            }
            else if (dateTime.Hour >= 7 && dateTime.Hour <= 12)
            {
                hello = "Доброе утро";
            }
            else if (dateTime.Hour >= 13 && dateTime.Hour <= 18)
            {
                hello = "Добрый день ";
            }
            else if (dateTime.Hour > 18 && dateTime.Hour <= 23)
            {
                hello = "Добрый вечер";
            }
            else
            {
                hello = "Добро пожаловать";
            }
            try
            {
                connect.Open();
                SqlCommand enter = new SqlCommand();
                enter.CommandType = CommandType.StoredProcedure;
                enter.CommandText = "Enter";
                enter.Parameters.AddWithValue("@login", textBox1.Text);
                enter.Parameters.AddWithValue("@password", textBox2.Text);
                enter.Connection = connect;
                SqlDataReader sqlReader = enter.ExecuteReader();
                sqlReader.Read();

                if (sqlReader.HasRows)
                {
                    connect.Close();
                    connect.Open();
                    string login = textBox1.Text;

                    //Вывод имени и отчества пользователя с привествием
                    using (SqlCommand sqlCom = new SqlCommand(@"Select [Name], Patronymic From [User]  Where [Login] like @login", connect))
                    {
                        SqlParameter logPar = new SqlParameter("@login", login);
                        sqlCom.Parameters.Add(logPar);
                        SqlDataReader Reader = sqlCom.ExecuteReader();
                        Reader.Read();
                        string welcome = hello + ',' + ' ' + Reader.GetString(0) + ' ' + Reader.GetString(1) + ".";
                        this.Hide();
                        MessageBox.Show(welcome);

                        mainF.Show();
                        connect.Close();
                    }
                }
                else
                {
                    troubles++;
                    if (troubles == 3)
                    {
                        timer1.Start();
                    }
                    MessageBox.Show("Неправильный логин или пароль. Попробуйте снова");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка, ( {ex.Message} )");
            }
        }

        //Кнопка входа с функцией приветствия в зависимости от времени устройства для гостя
        private void button2_Click(object sender, EventArgs e)
        {
            string hello;
            DateTime dateTime = DateTime.Now;
            if (dateTime.Hour >= 0 && dateTime.Hour <= 6)
            {
                hello = "Доброй ночи";
            }
            else if (dateTime.Hour >= 7 && dateTime.Hour <= 12)
            {
                hello = "Доброе утро";
            }
            else if (dateTime.Hour >= 13 && dateTime.Hour <= 18)
            {
                hello = "Добрый день ";
            }
            else if (dateTime.Hour > 18 && dateTime.Hour <= 23)
            {
                hello = "Добрый вечер";
            }
            else
            {
                hello = "Добро пожаловать";
            }
            this.Hide();
            MessageBox.Show($"{hello}, Гость!");
            mainF.Show();
        }
        //Таймер блокировки входа после неудачной попытки 
        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = $"Подождите({s})";
            s--;
            label5.Visible = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;

            if (s == 0)
            {
                timer1.Stop();
                label5.Visible = false;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
                s = 10;
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}