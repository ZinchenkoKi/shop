using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public partial class kat : Form
    {
        public int znach1;
        public kat()
        {
            InitializeComponent();
        }
        int s;
    private void button1_Click(object sender, EventArgs e)
        {
            Staff main = this.Owner as Staff; 

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите категорию товара");

            }
            else if (comboBox1.SelectedIndex == 0)
            {
               s = 0;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                s = 1;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                s= 2;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                s = 3;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                s = 4;
            }
             main.znach =s;
            this.Hide(); // скрываем kat (this - текущая форма)
        }
    }
}
