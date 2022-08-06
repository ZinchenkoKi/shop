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
    public partial class userkab : Form
    {
        Form1 con1 = new Form1();
        private DataSet set1 = null;
        public userkab()
        {
            InitializeComponent();
        }

        private void userkab_Load(object sender, EventArgs e)
        {
            con1.Connect_SroteDB = new SqlConnection(ConfigurationManager.ConnectionStrings["Store_db"].ConnectionString);
            con1.Connect_SroteDB.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Products", con1.Connect_SroteDB);
            DataSet set1 = new DataSet();
            adapter.Fill(set1);
            label9.Text = set1.Tables[0].Rows[0].ItemArray[0].ToString();
        }
    }
}
