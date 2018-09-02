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
    public partial class EquipViewUI : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=db;user=root;password=root");
        MySqlCommand adapter;
        MySqlCommand cmd;
        DataTable grid = new DataTable();
        public EquipViewUI()
        {
            InitializeComponent();
            refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");
            setTextform("SELECT items.id,items.name,category.description,items.description,items.status FROM items left join category on items.categoryID = category.id left join itemcontent on itemcontent.itemID=items.id  where items.id ="+Equipment.sendtext);
            damagerefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 2 group by itemcontent.modelNumber");
            onrepairrefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 3 group by itemcontent.modelNumber");
            dbrrefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 4");
            repairrefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,repairlogs.daterepaired from items left join itemcontent on items.id = itemcontent.itemID inner JOIN repairlogs on  itemcontent.id = repairlogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 1");
            setCount("Select COUNT(itemcontent.id) as test from itemcontent where itemcontent.itemID = "+Equipment.sendtext+" and itemcontent.tagID = 1");
         
        }

       

        
        public void refresh(string query)
        {

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            adapter.Fill(table);
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderCell.Value = "Name";
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
       
       


        }

        public void damagerefresh(string query)
        {

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            adapter.Fill(table);
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = table;
            dataGridView2.Columns[0].Visible = false;
            dataGridView2.Columns[2].Visible = false;
            dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].HeaderCell.Value = "Name";
            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[3].HeaderCell.Value = "Date Damaged";
            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        public void onrepairrefresh(string query)
        {

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            adapter.Fill(table);
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.Columns.Clear();
            dataGridView3.DataSource = table;
            dataGridView3.Columns[0].Visible = false;
            dataGridView3.Columns[2].Visible = false;
            dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns[1].HeaderCell.Value = "Name";
            dataGridView3.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns[3].HeaderCell.Value = "Date Damaged";
            dataGridView3.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        public void dbrrefresh(string query)
        {

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            adapter.Fill(table);
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.Columns.Clear();
            dataGridView4.DataSource = table;
            dataGridView4.Columns[0].Visible = false;
            dataGridView4.Columns[2].Visible = false;
            dataGridView4.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.Columns[1].HeaderCell.Value = "Name";
            dataGridView4.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView4.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.Columns[3].HeaderCell.Value = "Date Damaged";
            dataGridView4.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView4.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        public void repairrefresh(string query)
        {

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            adapter.Fill(table);
            dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView5.Columns.Clear();
            dataGridView5.DataSource = table;
            dataGridView5.Columns[0].Visible = false;
            dataGridView5.Columns[2].Visible = false;
            dataGridView5.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView5.Columns[1].HeaderCell.Value = "Name";
            dataGridView5.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView5.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView5.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView5.Columns[3].HeaderCell.Value = "Date Repaired";
            dataGridView5.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView5.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        public string flag;
        public void setTextform(string query)
        {

            openConnection();
            adapter = new MySqlCommand(query, con);
            MySqlDataReader myreader = adapter.ExecuteReader();
            if (myreader.Read())
            {
                name.Text = myreader.GetValue(1).ToString();
                cat.Text = myreader.GetValue(2).ToString();
               flag = myreader.GetValue(4).ToString();
                stats.Text = myreader.GetValue(4).ToString();
                this.Text = myreader.GetValue(1).ToString();
            }
            myreader.Close();
            closeConnection();
            if(flag == "Temporary")
            {
                setStatus("SELECT * FROM status where itemID = "+Equipment.sendtext);
            }

        }
        public void setStatus(string query)
        {
            label4.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            drl.Visible = true;
            ddl.Visible = true;
            ol.Visible = true;
            openConnection();
            adapter = new MySqlCommand(query, con);
            MySqlDataReader myreader = adapter.ExecuteReader();
            if (myreader.Read())
            {

                drl.Text = myreader.GetValue(2).ToString();
                ddl.Text = myreader.GetValue(3).ToString();
                ol.Text = myreader.GetValue(4).ToString();

            }
            myreader.Close();
            closeConnection();

        }

        public void setCount(string query)
        {

            openConnection();
            adapter = new MySqlCommand(query, con);
            MySqlDataReader myreader = adapter.ExecuteReader();
            if (myreader.Read())
            {
              
                stk.Text = myreader.GetValue(0).ToString();
            
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



        public static string findid = "";
        private void button1_Click(object sender, EventArgs e)
        {
            findid = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
            var a = new EditContent();
           
           // MessageBox.Show(id);
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var a = new AddContent();
            a.Show();
            a.ShowDialog();
            if (a.DialogResult == DialogResult.OK)
            {
                refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");

            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                string insertQuery = "DELETE FROM itemcontent WHERE id =" + dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
                executeMyQuery(insertQuery);
                refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");
                setCount("Select COUNT(itemcontent.id) as test from itemcontent where itemcontent.itemID = " + Equipment.sendtext + " and itemcontent.tagID = 1");


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
                    MessageBox.Show("Process Complete");

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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 1)
            {
                mtor.Visible = true;
                dbr.Visible = false;
                rep.Visible = false;
            }
            if (tabControl1.SelectedIndex == 2)
            {
                mtor.Visible = false;
                dbr.Visible = true;
                rep.Visible = true;
            }
            if (tabControl1.SelectedIndex != 2)
            {
               // mtor.Visible = false;
                dbr.Visible = false;
                rep.Visible = false;
            }
            if (tabControl1.SelectedIndex != 0)
            {
                button2.Visible = false;
                button1.Visible = false;
                button4.Visible = false;
            }
            if (tabControl1.SelectedIndex == 0)
            {
                button2.Visible = true;
                button1.Visible = true;
                button4.Visible = true;
            }


        }

        private void mtor_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                string insertQuery = "UPDATE itemcontent SET tagID=3 where itemID =" + Equipment.sendtext + " and id=" + dataGridView2.Rows[dataGridView2.SelectedRows[0].Index].Cells[2].Value.ToString();
                executeMyQuery(insertQuery);
                refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");
                setCount("Select COUNT(itemcontent.id) as test from itemcontent where itemcontent.itemID = " + Equipment.sendtext + " and itemcontent.tagID = 1");
 
                damagerefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 2 group by itemcontent.modelNumber");
                onrepairrefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 3 group by itemcontent.modelNumber");

            }
        }

        private void rep_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {

                string insertQuery = "UPDATE itemcontent SET tagID=1, StockID = StockID+1 where itemID =" + Equipment.sendtext + " and id=" + dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[2].Value.ToString();
                string insertQuery1 = " INSERT INTO repairlogs (itemID, daterepaired) VALUES ('" + dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[2].Value.ToString() + "',  '" + DateTime.Now + "')";
                executeMyQuery(insertQuery);
                executeMyQuery(insertQuery1);
                refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");
                setCount("Select COUNT(itemcontent.id) as test from itemcontent where itemcontent.itemID = " + Equipment.sendtext + " and itemcontent.tagID = 1");

                damagerefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 2");
                onrepairrefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 3");
                repairrefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,repairlogs.daterepaired from items left join itemcontent on items.id = itemcontent.itemID inner JOIN repairlogs on  itemcontent.id = repairlogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 1");

            }
        }

        private void dbr_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                string insertQuery = "UPDATE itemcontent SET tagID=4 where itemID =" + Equipment.sendtext + " and id=" + dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[2].Value.ToString();
                string insertQuery1 = " INSERT INTO repairlogs (itemID, daterepaired) VALUES ('" + dataGridView3.Rows[dataGridView3.SelectedRows[0].Index].Cells[2].Value.ToString() + "',  '" + DateTime.Now + "')";
                executeMyQuery(insertQuery);
                executeMyQuery(insertQuery1);
                refresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id from items left join itemcontent on items.id = itemcontent.itemID where items.id =" + Equipment.sendtext + " and itemcontent.tagID < 2");
                setCount("Select COUNT(itemcontent.id) as test from itemcontent where itemcontent.itemID = " + Equipment.sendtext + " and itemcontent.tagID = 1");
                damagerefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 2");
                onrepairrefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 3");
                dbrrefresh("SELECT items.id,itemcontent.modelNumber,itemcontent.id,damagelogs.datedamaged from items left join itemcontent on items.id = itemcontent.itemID inner JOIN damagelogs on  itemcontent.id = damagelogs.itemid where items.id =" + Equipment.sendtext + " and itemcontent.tagID = 4");

            }
        }
    }
}
