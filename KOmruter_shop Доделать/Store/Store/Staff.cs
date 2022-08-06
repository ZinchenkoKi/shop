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
    public partial class Staff : Form
    {
        Form1 con1 = new Form1();
        public int znach; // переменная значения с другой формы

        

        private SqlCommandBuilder sqlBilder = null; 

        private SqlDataAdapter adapter = null;

        private DataSet set1 = null;

        private bool newRowAdding = false;



        public Staff()
        {
            InitializeComponent();
        }

        private void LoadData() // загрузка занных бд
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT *, 'Delite' AS [Delite] FROM Products", con1.Connect_SroteDB); 

                sqlBilder = new SqlCommandBuilder(adapter);

                sqlBilder.GetDeleteCommand();
                sqlBilder.GetUpdateCommand();
                sqlBilder.GetInsertCommand();

                set1 = new DataSet();

                adapter.Fill(set1, "Products");

                dataGridView2.DataSource = set1.Tables["Products"];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[6, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReloadData() // обновление данных в бд
        {
            try
            {
                set1.Tables["Products"].Clear();

                adapter.Fill(set1, "Products");

                dataGridView2.DataSource = set1.Tables["Products"];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[6, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button9_Click(object sender, EventArgs e) // открытие списка всех пользователей
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Users", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
            comboBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e) // Открытие списка всех товаров
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
            comboBox1.Enabled = true;
        }

        private void Staff_Load(object sender, EventArgs e) //запуск базы данных
        {
            con1.Connect_SroteDB = new SqlConnection(ConfigurationManager.ConnectionStrings["Store_db"].ConnectionString);
            con1.Connect_SroteDB.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
        }

        private void button8_Click(object sender, EventArgs e) // открытие списка всех сотрудников
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Staff", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
            comboBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) // поиск по командной строке
        {
            SqlDataAdapter adapter = new SqlDataAdapter(textBox1.Text, con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
        }

        private void button11_Click(object sender, EventArgs e) // список всех товаров на вкладке редактирование товары
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView2.DataSource = set1.Tables[0];
            LoadData();
        }


        private void выходToolStripMenuItem_Click(object sender, EventArgs e) // закрытие формы
        {
            Application.Exit();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)  // выбор функции для обновления на разных вкладках панели
        {
            if (tableLayoutPanel2.TabIndex == 0)
            {
                ReloadData();
            }
            else if (tableLayoutPanel2.TabIndex == 1)
            {
                ReloadUsers();
            }
            else if (tableLayoutPanel2.TabIndex == 2)
            {
                ReloadStaff();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) // бействия удаления обновления и редактирования 
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    string task = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();

                    if (task == "Delite") // удаление данных из таблицы и бд
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView2.Rows.RemoveAt(rowIndex);

                            set1.Tables["Products"].Rows[rowIndex].Delete();

                            adapter.Update(set1, "Products");
                        }
                    }
                    else if (task == "Insert") // ввод даных в бд
                    {
                        int rowIndex = dataGridView2.Rows.Count - 2;

                        DataRow row = set1.Tables["Products"].NewRow();

                        row["Name"] = dataGridView2.Rows[rowIndex].Cells["Name"].Value;
                        row["Price"] = dataGridView2.Rows[rowIndex].Cells["Price"].Value;
                        row["Quantity"] = dataGridView2.Rows[rowIndex].Cells["Quantity"].Value;
                        kat ifrm = new kat();
                        ifrm.Owner = this;
                        ifrm.ShowDialog();
                        MessageBox.Show(Convert.ToString(znach)," staff");
                        if (znach == 0)
                        {
                            row["Category"] = "Komplect";
                        }
                        else if (znach == 1)
                        {
                            row["Category"] = "PC";
                        }
                        else if (znach == 2)
                        {
                            row["Category"] = "Seti";
                        }
                        else if (znach == 3)
                        {
                            row["Category"] = "Office";
                        }
                        else if (znach == 4)
                        {
                            row["Category"] = "Obslujivanie";
                        }
                        row["Product_type"] = dataGridView2.Rows[rowIndex].Cells["Product_type"].Value;
                        

                        set1.Tables["Products"].Rows.Add(row);

                        set1.Tables["Products"].Rows.RemoveAt(set1.Tables["Products"].Rows.Count - 1);

                        dataGridView2.Rows.RemoveAt(dataGridView2.Rows.Count - 2);

                        dataGridView2.Rows[e.RowIndex].Cells[6].Value = "Delite";

                        adapter.Update(set1, "Products");

                        newRowAdding = false;
                    }
                    else if (task == "Update") // изменение данных в бд
                    {
                        int r = e.RowIndex;

                        set1.Tables["Products"].Rows[r]["Name"] = dataGridView2.Rows[r].Cells["Name"].Value;
                        set1.Tables["Products"].Rows[r]["Price"] = dataGridView2.Rows[r].Cells["Price"].Value;
                        set1.Tables["Products"].Rows[r]["Quantity"] = dataGridView2.Rows[r].Cells["Quantity"].Value;
                        set1.Tables["Products"].Rows[r]["Category"] = dataGridView2.Rows[r].Cells["Category"].Value;
                        set1.Tables["Products"].Rows[r]["Product_type"] = dataGridView2.Rows[r].Cells["Product_type"].Value;

                        adapter.Update(set1, "Products");

                        dataGridView2.Rows[e.RowIndex].Cells[6].Value = "Delite";
                    }
                    ReloadData();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_UserAddedRow(object sender, DataGridViewRowEventArgs e) // добавление сторки в таблицу
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridView2.Rows.Count - 2;

                    DataGridViewRow row = dataGridView2.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[6, lastRow] = linkCell;

                    row.Cells["Delite"].Value = "Insert";
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView2_CellValueChanged_1(object sender, DataGridViewCellEventArgs e) // проверка на ввод
        {
            try
            {
                if (newRowAdding == false)
                {

                    int rowIndex = dataGridView2.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView2.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView2[6, rowIndex] = linkCell;

                    editingRow.Cells["Delite"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) // ввод только цифр в цифровых полях
        {
            e.Control.KeyPress -= new KeyPressEventHandler(columCeyPress);

            if (dataGridView2.CurrentCell.ColumnIndex == 2 || dataGridView2.CurrentCell.ColumnIndex == 3)
            {
                TextBox textBox = e.Control as TextBox;
                if (textBox != null)
                {
                    textBox.KeyPress += new KeyPressEventHandler(columCeyPress);
                }
            }
        }

        private void columCeyPress(object Sender, KeyPressEventArgs e) // проверка строки новая или нет 
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // ------------------------------------------------------------------------Вкладка пользователи----------------------------------------------------------------


        private void LoadUsers()  // загрузка бызы всех поьзователей
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT *, 'Delite' AS [Delite] FROM Users", con1.Connect_SroteDB);

                sqlBilder = new SqlCommandBuilder(adapter);

                sqlBilder.GetDeleteCommand();
                sqlBilder.GetUpdateCommand();
                sqlBilder.GetInsertCommand();

                set1 = new DataSet();

                adapter.Fill(set1, "Users");

                dataGridView3.DataSource = set1.Tables["Users"];

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView3[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReloadUsers()
        {
            try
            {
                set1.Tables["Users"].Clear();

                adapter.Fill(set1, "Users");

                dataGridView3.DataSource = set1.Tables["Users"];

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView3[7, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button10_Click(object sender, EventArgs e) /// открытие списка всех пользователей
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Users", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView3.DataSource = set1.Tables[0];
            LoadUsers();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    string task = dataGridView3.Rows[e.RowIndex].Cells[7].Value.ToString();

                    if (task == "Delite")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView3.Rows.RemoveAt(rowIndex);

                            set1.Tables["Users"].Rows[rowIndex].Delete();

                            adapter.Update(set1, "Users");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView3.Rows.Count - 2;

                        DataRow row = set1.Tables["Users"].NewRow();

                        row["Name"] = dataGridView3.Rows[rowIndex].Cells["Name"].Value;
                        row["Surname"] = dataGridView3.Rows[rowIndex].Cells["Surname"].Value;
                        row["Patronymic"] = dataGridView3.Rows[rowIndex].Cells["Patronymic"].Value;
                        row["Date_of_Birth"] = dataGridView3.Rows[rowIndex].Cells["Date_of_Birth"].Value;
                        row["Address"] = dataGridView3.Rows[rowIndex].Cells["Address"].Value;
                        row["Phone"] = dataGridView3.Rows[rowIndex].Cells["Phone"].Value;

                        set1.Tables["Users"].Rows.Add(row);

                        set1.Tables["Users"].Rows.RemoveAt(set1.Tables["Users"].Rows.Count - 1);

                        dataGridView3.Rows.RemoveAt(dataGridView3.Rows.Count - 2);

                        dataGridView3.Rows[e.RowIndex].Cells[7].Value = "Delite";

                        adapter.Update(set1, "Users");

                        newRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        set1.Tables["Users"].Rows[r]["Name"] = dataGridView3.Rows[r].Cells["Name"].Value;
                        set1.Tables["Users"].Rows[r]["Surname"] = dataGridView3.Rows[r].Cells["Surname"].Value;
                        set1.Tables["Users"].Rows[r]["Patronymic"] = dataGridView3.Rows[r].Cells["Patronymic"].Value;
                        set1.Tables["Users"].Rows[r]["Date_of_Birth"] = dataGridView3.Rows[r].Cells["Date_of_Birth"].Value;
                        set1.Tables["Users"].Rows[r]["Address"] = dataGridView3.Rows[r].Cells["Address"].Value;
                        set1.Tables["Users"].Rows[r]["Phone"] = dataGridView3.Rows[r].Cells["Phone"].Value;



                        adapter.Update(set1, "Users");

                        dataGridView3.Rows[e.RowIndex].Cells[7].Value = "Delite";
                    }
                    ReloadUsers();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridView3.Rows.Count - 2;

                    DataGridViewRow row = dataGridView3.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView3[7, lastRow] = linkCell;

                    row.Cells["Delite"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {

                    int rowIndex = dataGridView3.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView3.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView3[7, rowIndex] = linkCell;

                    editingRow.Cells["Delite"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //----------------------------------------------------------------------------------Сотрудники---------------------------------------------------------------------------------------

        private void LoadStaff()  // загрузка бызы всех сотрудников
        {
            try
            {
                adapter = new SqlDataAdapter("SELECT *, 'Delite' AS [Delite] FROM Staff", con1.Connect_SroteDB);

                sqlBilder = new SqlCommandBuilder(adapter);

                sqlBilder.GetDeleteCommand();
                sqlBilder.GetUpdateCommand();
                sqlBilder.GetInsertCommand();

                set1 = new DataSet();

                adapter.Fill(set1, "Staff");

                dataGridView4.DataSource = set1.Tables["Staff"];

                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView4[5, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReloadStaff()
        {
            try
            {
                set1.Tables["Staff"].Clear();

                adapter.Fill(set1, "Staff");

                dataGridView4.DataSource = set1.Tables["Staff"];

                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView4[5, i] = linkCell;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Staff", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView4.DataSource = set1.Tables[0];
            LoadStaff();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    string task = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();

                    if (task == "Delite")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;

                            dataGridView4.Rows.RemoveAt(rowIndex);

                            set1.Tables["Staff"].Rows[rowIndex].Delete();

                            adapter.Update(set1, "Staff");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView4.Rows.Count - 2;

                        DataRow row = set1.Tables["Staff"].NewRow();

                        row["Name"] = dataGridView4.Rows[rowIndex].Cells["Name"].Value;
                        row["Surname"] = dataGridView4.Rows[rowIndex].Cells["Surname"].Value;
                        row["Position"] = dataGridView4.Rows[rowIndex].Cells["Position"].Value;
                        row["Phone"] = dataGridView4.Rows[rowIndex].Cells["Phone"].Value;

                        set1.Tables["Staff"].Rows.Add(row);

                        set1.Tables["Staff"].Rows.RemoveAt(set1.Tables["Staff"].Rows.Count - 1);

                        dataGridView4.Rows.RemoveAt(dataGridView4.Rows.Count - 2);

                        dataGridView4.Rows[e.RowIndex].Cells[5].Value = "Delite";

                        adapter.Update(set1, "Staff");

                        newRowAdding = false;
                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;

                        set1.Tables["Staff"].Rows[r]["Name"] = dataGridView4.Rows[r].Cells["Name"].Value;
                        set1.Tables["Staff"].Rows[r]["Surname"] = dataGridView4.Rows[r].Cells["Surname"].Value;
                        set1.Tables["Staff"].Rows[r]["Position"] = dataGridView4.Rows[r].Cells["Position"].Value;
                        set1.Tables["Staff"].Rows[r]["Phone"] = dataGridView4.Rows[r].Cells["Phone"].Value;

                        adapter.Update(set1, "Staff");

                        dataGridView4.Rows[e.RowIndex].Cells[5].Value = "Delite";
                    }
                    ReloadStaff();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView4_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridView4.Rows.Count - 2;

                    DataGridViewRow row = dataGridView4.Rows[lastRow];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView4[5, lastRow] = linkCell;

                    row.Cells["Delite"].Value = "Insert";
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {

                    int rowIndex = dataGridView4.SelectedCells[0].RowIndex;

                    DataGridViewRow editingRow = dataGridView4.Rows[rowIndex];

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();

                    dataGridView4[5, rowIndex] = linkCell;

                    editingRow.Cells["Delite"].Value = "Update";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------

        //-------------------------------------------------------------------------------------Фильтры по категориям------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)//- комплектующие для ПК
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products where Category = 'Komplect'", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
            comboBox1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products where Category = 'PC'", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
            comboBox1.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products where Category = 'Seti'", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
            comboBox1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products where Category = 'Office'", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
            comboBox1.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products where Category = 'Obslujivanie'", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            dataGridView1.DataSource = set1.Tables[0];
            comboBox1.Enabled = true;
        }

        private void версияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Beta version 0.1");
        }

        private void оПриложенииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" +
                "Приложение Магазин компютерной техники Последний континент"+
                "  Разработал Зинченко К.А");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Name LIKE '%{textBox1.Text}%'";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                button1.Enabled = true;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                button1.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Quantity <= 10";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Quantity >= 11 AND Quantity <= 499 ";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"Quantity >= 500";
            }
        }

        private void менюВыбораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form1();
            ifrm.Show(); // отображаем Form2
            this.Hide(); // скрываем Form1 (this - текущая форма)
        }
    }
}
