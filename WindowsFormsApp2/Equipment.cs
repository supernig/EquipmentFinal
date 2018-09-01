﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Timers;
namespace WindowsFormsApp2
{
    public partial class Equipment : UserControl
    {
        MySqlConnection con = new MySqlConnection("server=localhost;database=db;user=root;password=root");
        MySqlCommand cmd;
        DataTable grid = new DataTable();
        // int selectedRow;

        public Equipment()
        {
            InitializeComponent();
            refresh();
        }
        public static string sendtext = "";

    


      


        public void refresh(string query = "select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID")
        {

            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
            adapter.Fill(table);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Columns.Clear();
            dgv.DataSource = table;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].HeaderCell.Value = "Name";
            dgv.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].HeaderCell.Value = "Category";
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].HeaderCell.Value = "Status";
            dgv.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = new AddEquip();
            a.Show();
        }

        public void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.SelectedIndex = -1;
            refresh("select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure?", "Alert!", MessageBoxButtons.YesNo);
            if (dg == DialogResult.Yes)
            {
                string insertQuery = "DELETE FROM items WHERE id ="+dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
                executeMyQuery(insertQuery);
                refresh("select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID");

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
                    MessageBox.Show("Deleted");

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

        private void button2_Click(object sender, EventArgs e)
        {
            sendtext = dgv.Rows[dgv.SelectedRows[0].Index].Cells[0].Value.ToString();
            var a = new EquipViewUI();
            a.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex + 1;
            if (textBox1.Text != "" && comboBox1.SelectedIndex != -1)
            {
                refresh("select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID where items.name like '%" + textBox1.Text + "%' and items.categoryID =" + i);
            }
            else
            {

                refresh("select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID ");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex + 1;
            if (comboBox1.SelectedIndex != -1 && textBox1.Text != "")
            {
                refresh("select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID where items.name like '%" + textBox1.Text + "%' and items.categoryID ="+i);
            }

            if (textBox1.Text == "")
            {
                refresh("select items.id, items.name, category.description,items.status from items left join category on category.id = items.categoryID where items.name like '%" + textBox1.Text + "%' and items.categoryID =" + i);
            }

        }
    }
}
