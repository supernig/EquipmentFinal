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
    public partial class EditContent : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=db;user=root;password=root");
        MySqlCommand adapter;
        MySqlCommand cmd;
        public EditContent()
        {
            InitializeComponent();
            string query = "SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.id= "+EquipViewUI.findid ;
           
            comboBox1.SelectedIndex = 0;
            findCount("Select StockID from itemcontent where itemcontent.id =" +EquipViewUI.findid);
            setTextform(query);
        }

        public void findCount(string query)
        {
           
            openConnection();
            adapter = new MySqlCommand(query, con);
            MySqlDataReader myreader = adapter.ExecuteReader();
            if (myreader.Read())
            {

                if (myreader.GetValue(0).ToString() != "0")
                {
                    repcount.Visible = true;
                    repcount.Text = "This item has been repaired " + myreader.GetValue(0).ToString() + " times";
                }
                

            }
            myreader.Close();
            closeConnection();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            var a = 1 + comboBox1.SelectedIndex;
            if (textBox1.Text != "" && comboBox1.SelectedIndex == 0)
            {
                
                    DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
                    if (dg == DialogResult.Yes)
                    {
                        string insertQuery = "UPDATE itemcontent SET modelNumber='" + textBox1.Text + "' where itemID ="+Equipment.sendtext+" and id="+EquipViewUI.findid;
                        executeMyQuery(insertQuery);
                    (System.Windows.Forms.Application.OpenForms["EquipViewUI"] as EquipViewUI).refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");
                    (System.Windows.Forms.Application.OpenForms["EquipViewUI"] as EquipViewUI).damagerefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 2");
                    MessageBox.Show("Successfully Updated");
                    //(System.Windows.Forms.Application.OpenForms["Form2"] as Form2).setTextform("SELECT items.id,items.name,category.description,items.description,COUNT(itemcontent.id) AS test FROM items left join category on items.categoryID = category.id left join itemcontent on itemcontent.itemID=items.id and items.id =" + UserControl1.sendtext);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Dispose();

                    }
            }
            if (textBox1.Text != "" && comboBox1.SelectedIndex == 1)
            {
                DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    string insertQuery = "UPDATE itemcontent SET modelNumber='" + textBox1.Text + "',tagID = 2 where itemID =" + Equipment.sendtext + " and id=" + EquipViewUI.findid;
                    string insertQuery1 = " INSERT INTO damagelogs (itemID,datedamaged) VALUES ('" + EquipViewUI.findid + "',  '" + dtp1.Text + "')";
                    executeMyQuery(insertQuery);
                    executeMyQuery(insertQuery1);
                    MessageBox.Show("Successfully Updated");
                    (System.Windows.Forms.Application.OpenForms["EquipViewUI"] as EquipViewUI).refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");
                    (System.Windows.Forms.Application.OpenForms["EquipViewUI"] as EquipViewUI).damagerefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 2");
                    (System.Windows.Forms.Application.OpenForms["EquipViewUI"] as EquipViewUI).setTextform("SELECT items.id,items.name,category.description,items.description,items.status FROM items left join category on items.categoryID = category.id left join itemcontent on itemcontent.itemID=items.id  where items.id =" + Equipment.sendtext);

                    (System.Windows.Forms.Application.OpenForms["EquipViewUI"] as EquipViewUI).setCount("Select COUNT(itemcontent.id) as test from itemcontent where itemcontent.itemID = " + Equipment.sendtext + " and itemcontent.tagID = 1");
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Dispose();

                }
            }
            else
            {

            }
        }
        public void setTextform(string query)
        {

            openConnection();
            adapter = new MySqlCommand(query, con);
            MySqlDataReader myreader = adapter.ExecuteReader();
            if (myreader.Read())
            {
                textBox1.Text = myreader.GetValue(1).ToString();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 1)
            {
                dd.Visible = true;
                dtp1.Visible = true;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                dd.Visible = false;
                dtp1.Visible = false;
            }
        }

      
    }
}
