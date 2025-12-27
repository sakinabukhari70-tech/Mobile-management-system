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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mobile_Management_System
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            DisplayCustomer();
        }
        readonly SqlConnection Con = new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Hussain\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayCustomer()
        {
            try
            {
                Con.Open();
                string query = "select * from CTBL";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder sql = new SqlCommandBuilder();
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Con.Close();
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
        private void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox4.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox5.Text == " ")
                {
                    MessageBox.Show("Missing info");
                }
                else
                {
                    Con.Open();
                    string query = "insert into CTBL VALUES('" + textBox1.Text + "','" + textBox4.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Successfully");
                    DisplayCustomer();
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

        private void homebtn_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox4.Text = " ";
            comboBox2.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox5.Text = " ";


        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || textBox4.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " " || textBox5.Text == " ")
                {
                    MessageBox.Show("Missing information");
                }
                else
                {
                    Con.Open();


                    SqlCommand cmd = new SqlCommand("update CTBL set CName=@CN, Gender=@G,Address=@A, PurchasedMobile=@PM,Bill=@B WHERE CId=@Key", Con);
                    cmd.Parameters.AddWithValue("@CN", textBox4.Text);
                    cmd.Parameters.AddWithValue("@G", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@A", textBox2.Text);
                    cmd.Parameters.AddWithValue("@PM", textBox3.Text);
                    cmd.Parameters.AddWithValue("@B", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Key", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Updated Successfully");
                    DisplayCustomer();
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

        private void deletebtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter the Customer id");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from CTBL WHERE CId='" + textBox1.Text + " '';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Deleted Successfully");
                    DisplayCustomer();

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
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
    }
}
