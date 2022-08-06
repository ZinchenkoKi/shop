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
    public partial class User : Form
    {

        Form1 con1 = new Form1();

        public User()
        {
            InitializeComponent();
        }

        private void User_Load(object sender, EventArgs e)
        {
            con1.Connect_SroteDB = new SqlConnection(ConfigurationManager.ConnectionStrings["Store_db"].ConnectionString);
            con1.Connect_SroteDB.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Name,Price,Quantity FROM Products", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // закрытие приложения
        }

        private void информацияОПриложенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +
              "Приложение Магазин компютерной техники Последний Kонтинент" +
              "  Разработал Зинченко К.А");
        }

        private void верияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Beta version 0.1");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select Name,Price,Quantity FROM Products", con1.Connect_SroteDB);
                DataSet set1 = new DataSet();
                adapter.Fill(set1);
                dataGridView1.DataSource = set1.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select Name,Price,Quantity FROM Products where Category = 'Komplect' ", con1.Connect_SroteDB);
                DataSet set1 = new DataSet();
                adapter.Fill(set1);
                dataGridView1.DataSource = set1.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select Name,Price,Quantity FROM Products where Category = 'PC' ", con1.Connect_SroteDB);
                DataSet set1 = new DataSet();
                adapter.Fill(set1);
                dataGridView1.DataSource = set1.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select Name,Price,Quantity FROM Products where Category = 'Seti' ", con1.Connect_SroteDB);
                DataSet set1 = new DataSet();
                adapter.Fill(set1);
                dataGridView1.DataSource = set1.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select Name,Price,Quantity FROM Products where Category = 'Office' ", con1.Connect_SroteDB);
                DataSet set1 = new DataSet();
                adapter.Fill(set1);
                dataGridView1.DataSource = set1.Tables[0];
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select Name,Price,Quantity FROM Products where Category = 'Obslujivanie' ", con1.Connect_SroteDB);
                DataSet set1 = new DataSet();
                adapter.Fill(set1);
                dataGridView1.DataSource = set1.Tables[0];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Name LIKE '%{textBox1.Text}%'";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {

                if (comboBox3.SelectedIndex == 0)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Price <= 10";
                }
                else if (comboBox3.SelectedIndex == 1)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Price >= 11 AND Quantity <= 999 ";
                }
                else if (comboBox3.SelectedIndex == 2)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Price >= 1000";
                }
                else if (comboBox3.SelectedIndex == 3)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"";
                }

            }
            else if (comboBox2.SelectedIndex == 1)
            {

                if (comboBox3.SelectedIndex == 0)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Quantity <= 10";
                }
                else if (comboBox3.SelectedIndex == 1)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Quantity >= 11 AND Quantity <= 999 ";
                }
                else if (comboBox3.SelectedIndex == 2)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Quantity >= 1000";
                }
                else if (comboBox3.SelectedIndex == 3)
                {
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"";
                }
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                comboBox3.Enabled = true;
            }
           else if (comboBox2.SelectedIndex == 1)
            {
                comboBox3.Enabled = true;
            }
          else  if (comboBox2.SelectedIndex == 2)
            {
                comboBox3.Enabled = false;
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void менбВыобораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form1();
            ifrm.Show(); // отображаем Form2
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }
    }
   
       
           
    
           
       

        
    
}
