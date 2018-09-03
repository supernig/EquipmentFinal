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
    public partial class AddContent : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=db;user=root;password=root");
        MySqlCommand cmd;
        MySqlCommand adapter;
        public AddContent()
        {
            InitializeComponent();
        }

        int last;
        public void verify(string query)
        {

            openConnection();
            adapter = new MySqlCommand(query, con);
            MySqlDataReader myreader = adapter.ExecuteReader();
            if (myreader.Read())
            {

                last = int.Parse(myreader.GetValue(0).ToString());

            }
            myreader.Close();
            closeConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verify("Select COUNT(*) FROM itemcontent where modelNumber ='" + textBox1.Text + "' and itemID =" + Equipment.sendtext);
            if (last < 1)
            {
                if (textBox1.Text != "")
                {

                    DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
                    if (dg == DialogResult.Yes)
                    {
                        string insertQuery = "INSERT INTO itemcontent(itemID, tagID, modelNumber, StockID) VALUES (" + Equipment.sendtext + ",1,'" + textBox1.Text + "',0)";
                        executeMyQuery(insertQuery);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                        (System.Windows.Forms.Application.OpenForms["EquipViewUI"] as EquipViewUI).refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");
                        (System.Windows.Forms.Application.OpenForms["EquipViewUI"] as EquipViewUI).setCount("Select COUNT(itemcontent.id) as test from itemcontent where itemcontent.itemID = " + Equipment.sendtext + " and itemcontent.tagID = 1");

                    }


                }
                else
                {
                    MessageBox.Show("Something went wrong", "Error. ",
       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Item Already Exist", "Error. ",
      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                    MessageBox.Show("Item added Successfully");

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
