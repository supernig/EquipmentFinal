using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp2
{
    public partial class EditEquip : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=db;user=root;password=root");
        MySqlCommand adapter;
        MySqlCommand cmd;
        public EditEquip()
        {
            InitializeComponent();

            setTextform("Select items.name,category.description, items.description from items left join category on category.id = items.categoryID where items.id = "+Equipment.sendtext);
    
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var a = 1 + comboBox1.SelectedIndex;
            if (textBox1.Text != "" )
            {

                DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    string insertQuery = "UPDATE items SET name='" + textBox1.Text + "' , categoryID =" + a+ " , description=" + textBox2.Text+" where items.id = " + Equipment.sendtext;
                    executeMyQuery(insertQuery);
                 
                    //(System.Windows.Forms.Application.OpenForms["Form2"] as Form2).setTextform("SELECT items.id,items.name,category.description,items.description,COUNT(itemcontent.id) AS test FROM items left join category on items.categoryID = category.id left join itemcontent on itemcontent.itemID=items.id and items.id =" + UserControl1.sendtext);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Dispose();

                }
            }
            else
            {
                MessageBox.Show("Successfully Updated");
            }

        }

        public void setTextform(string query)
        {

            openConnection();
            adapter = new MySqlCommand(query, con);
            MySqlDataReader myreader = adapter.ExecuteReader();
            if (myreader.Read())
            {
                textBox1.Text = myreader.GetValue(0).ToString();
                comboBox1.Text = myreader.GetValue(1).ToString();
                textBox2.Text = myreader.GetValue(2).ToString();
                // cat.Text = myreader.GetValue(3).ToString();
                //  stk.Text = myreader.GetValue(4).ToString();
                //  this.Text = myreader.GetValue(1).ToString();
            }
            myreader.Close();
            closeConnection();

        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void executeMyQuery(string query)
        {
            try
            {
                openConnection();
                cmd = new MySqlCommand(query, con);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("Executed");
                    MessageBox.Show("Successfully Updated");

                }

                else
                {
                    MessageBox.Show("Not Executed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
