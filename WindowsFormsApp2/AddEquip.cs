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
    public partial class AddEquip : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=db;user=root;password=root");
        MySqlCommand adapter;
        MySqlCommand cmd;
        Equipment uc1 = new Equipment();
        public AddEquip()
        {
            InitializeComponent();
        }
        public static string lastid;
        private void AddEquip_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 1;
            string loadquery = "SELECT IFNULL(MAX(`id`),0) + 1 AS nextId FROM `items`";
            setCount(loadquery);
        }


        public void setCount(string query)
        {

            openConnection();
            adapter = new MySqlCommand(query, con);
            MySqlDataReader myreader = adapter.ExecuteReader();
            if (myreader.Read())
            {

              lastid = myreader.GetValue(0).ToString();

            }
            myreader.Close();
            closeConnection();

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
            var a = 1 + comboBox1.SelectedIndex;
            
            verify("Select COUNT(*) FROM items where name ='" + textBox1.Text + "'");
     
                if (textBox1.Text != "" || textBox2.Text != "")
                {
                if (last < 1)
                {
                    DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
                        if (dg == DialogResult.Yes)
                        {
                            string insertQuery = "INSERT INTO items(name, categoryID, tagID, description,status) VALUES ('" + textBox1.Text + "','" + a + "','1','" + textBox2.Text + "','" + comboBox2.Text + "')";
                        if (comboBox2.Text=="Temporary")
                        {
                            string insertQuery1 = "INSERT INTO status(itemid,daterented,datedue,owner) VALUES (" +lastid+ ",'" + dtrdp1.Text + "','" + dddtp.Text + "','" + ownertb.Text + "')";
                            executeMyQuery(insertQuery1);
                   
                            setCount("SELECT IFNULL(MAX(`id`),0) + 1 AS nextId FROM `items`");
                        }
                            executeMyQuery(insertQuery);
                           
                            MessageBox.Show("Item added Successfully");
                            //uc1.refresh("select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID");

                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                            this.Dispose();

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
                MessageBox.Show("Already Exist", "Error. ",
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
                   // MessageBox.Show("Item added Successfully");
          
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

        private void AddEquip_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Temporary")
            {
                dr.Visible = true;
                dtrdp1.Visible = true;
                dddtp.Visible = true;
                ddlbl.Visible = true;
                owner.Visible = true;
                ownertb.Visible = true;
                     

            }
            if (comboBox2.Text == "Permanent")
            {
                dr.Visible = false;
                dtrdp1.Visible = false;
                dddtp.Visible = false;
                ddlbl.Visible = false;
                owner.Visible = false;
                ownertb.Visible = false;


            }
        }
    }
}
