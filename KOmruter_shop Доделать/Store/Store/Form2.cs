using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Store
{
    public partial class regis : Form
    {
        Form1 con2 = new Form1();// коннект с фотомой бд

        public regis()
        {
            InitializeComponent();
        }

        private void regis_Load(object sender, EventArgs e)
        {
    
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Clear();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Clear();
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con2.Connect_SroteDB = new SqlConnection(ConfigurationManager.ConnectionStrings["Store_db"].ConnectionString); // открытие бд
            con2.Connect_SroteDB.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO [Users] (Name, Surname, Patronymic, Date_of_Birth, Address, Phone) VALUES (@Name, @Surname, @Patronymic, @Date_of_Birth, @Address, @Phone)", con2.Connect_SroteDB); // вносим данные в таблицу сотрудники

            command.Parameters.AddWithValue("Name", textBox1.Text);
            command.Parameters.AddWithValue("Surname", textBox6.Text);
            command.Parameters.AddWithValue("Phone", textBox3.Text);
            command.Parameters.AddWithValue("Patronymic", textBox2.Text);
            command.Parameters.AddWithValue("Date_of_Birth", textBox8.Text);
            command.Parameters.AddWithValue("Address", textBox9.Text);

            command.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand($"INSERT INTO [LAP] (Login, Pasword) VALUES (@Login, @Pasword)", con2.Connect_SroteDB);// вносим данные в таблицу логины сотрудников

            command2.Parameters.AddWithValue("Login", textBox4.Text);
            command2.Parameters.AddWithValue("Pasword", textBox5.Text);
            command2.ExecuteNonQuery();

            MessageBox.Show("Регистрация завершена");
            this.Close();
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Clear();
        }

        private void textBox8_MouseClick(object sender, MouseEventArgs e)
        {
            textBox8.Clear();
        }

        private void textBox9_MouseClick(object sender, MouseEventArgs e)
        {
            textBox9.Clear();
        }
        //---------------------------------------------------------------------------------------Регистрация сотрудника---------------------------------------------------------------


        private void textBox7_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Clear();
        }

        private void textBox10_MouseClick(object sender, MouseEventArgs e)
        {
            textBox10.Clear();
        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            textBox11.Clear();
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            textBox12.Clear();
        }

        private void textBox13_MouseClick(object sender, MouseEventArgs e)
        {
            textBox13.Clear();
        }

        private void textBox14_MouseClick(object sender, MouseEventArgs e)
        {
            textBox14.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con2.Connect_SroteDB = new SqlConnection(ConfigurationManager.ConnectionStrings["Store_db"].ConnectionString); // открытие бд
            con2.Connect_SroteDB.Open();

            SqlCommand command = new SqlCommand($"INSERT INTO [Staff] (Name, Surname,Position,Phone) VALUES (@Name, @Surname, @Position, @Phone)", con2.Connect_SroteDB); // вносим данные в таблицу сотрудники

            command.Parameters.AddWithValue("Name", textBox7.Text);
            command.Parameters.AddWithValue("Surname", textBox10.Text);
            command.Parameters.AddWithValue("Position", textBox11.Text);
            command.Parameters.AddWithValue("Phone", textBox12.Text);


            command.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand($"INSERT INTO [Stuff_LAP] (Login, Pasword) VALUES (@Login, @Pasword)", con2.Connect_SroteDB);// вносим данные в таблицу логины сотрудников

            command2.Parameters.AddWithValue("Login", textBox13.Text);
            command2.Parameters.AddWithValue("Pasword", textBox14.Text);
            command2.ExecuteNonQuery();

            MessageBox.Show("Регистрация завершена");
            this.Close();
        }
    }
}
