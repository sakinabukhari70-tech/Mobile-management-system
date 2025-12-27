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

namespace Mobile_Management_System
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Hussain\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");
        private void FetchCus()
        {
            try
            {
                Con.Open();
                string query = "Select * from CTBL WHERE CId='" + textBox1.Text + "'";
                SqlCommand Sql = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(Sql);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    label3.Text = dr["CId"].ToString();
                    label5.Text = dr["CName"].ToString();
                    label7.Text = dr["Gender"].ToString();
                    label9.Text = dr["Address"].ToString();
                    label12.Text = dr["Purchased Mobile"].ToString();
                    label13.Text = dr["Bill"].ToString();
                    label3.Visible = true;
                    label5.Visible = true;
                    label7.Visible = true;
                    label9.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }
        private void Homebtn_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Refereshbtn_Click(object sender, EventArgs e)
        {
            FetchCus();
        }
    }
}
