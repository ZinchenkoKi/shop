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
    public partial class Form1 : Form
    {
        public SqlConnection Connect_SroteDB = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if ((textBox1.Text == "Klad") && (textBox2.Text == "1"))
            //{
            Form ifrm = new Staff();
            ifrm.Show(); // отображаем Form2
            this.Hide(); // скрываем Form1 (this - текущая форма)
            //}
            //else
            //{
            //    MessageBox.Show("Неверный логин или пароль!");
            //}
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // закрытие приложения
        }

        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form regestr = new regis();
            regestr.Show(); // отображаем Form2
        }

        private void информацияОПриложениииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +
               "Приложение Магазин компютерной техники Последний континент" +
               "  Разработал Зинченко К.А");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "Klad") && (textBox2.Text == "1"))
            {
                Form ifrm = new User();
                ifrm.Show(); // отображаем Form2
                this.Hide(); // скрываем Form1 (this - текущая форма)

            }
            else if ((textBox1.Text != "Klad") || (textBox2.Text != "1"))
            {
                Form ifrm = new User();
                ifrm.Show(); // отображаем Form2
                this.Hide(); // скрываем Form1 (this - текущая форма)
            }


        }
    }
}
