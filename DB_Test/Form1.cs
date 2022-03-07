using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DB_Test
{
    public partial class Form1 : Form
    {

        InsertCustomer insertCustomer = new InsertCustomer();

        private string selectedCellInDataGridView = "";
        private string CustomerID = "";
        private string CompanyName = "";
        private string ContactName = "";
        private string Phone = "";
        public bool showMessage;



        public Form1()
        {
            InitializeComponent();
            labelDateTime.Text = "";
            timer1.Enabled = true;
            ConnectToDatabase();

            showMessage = checkBox1.Checked = Properties.Settings.Default.ShowMessage;
            
        }
        


        /// <summary>
        /// Aktualizacia dataGridView
        /// </summary>
        public void DataGridViewUpdate()
        {
            if (DatabaseHandler.con == null || DatabaseHandler.con.State == ConnectionState.Closed)
            {

                if (showMessage)
                {
                    MessageBox.Show("Databaza nepripojena");
                }

            }
            else if (DatabaseHandler.con != null && DatabaseHandler.con.State == ConnectionState.Open)
            {
                var select = "SELECT * FROM Customers";

                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = DatabaseHandler.SelectQuery(DatabaseHandler.con, select).Tables[0];
            }
        }

        private void ConnectToDatabase()
        {
            DatabaseHandler.Connect();
            toolStripStatusLabel1.Text = "Connection opened";
            BtnConnenctOrClose.Text = "Close";
            toolStripStatusLabel1.BackColor = Color.Aquamarine;

            DataGridViewUpdate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (DatabaseHandler.con != null)
                DatabaseHandler.con.Close();

            Properties.Settings.Default.Save();
        }


        private void BtnConnenctOrClose_Click(object sender, EventArgs e)
        {
            if (DatabaseHandler.con != null && DatabaseHandler.con.State == ConnectionState.Open)
            {
                DatabaseHandler.con.Close();
                toolStripStatusLabel1.Text = "Connection closed";
                toolStripStatusLabel1.BackColor = SystemColors.Control;
                BtnConnenctOrClose.Text = "Open";

            }
            else
            {
                DatabaseHandler.Connect();
                toolStripStatusLabel1.Text = "Connection opened";
                BtnConnenctOrClose.Text = "Close";
                toolStripStatusLabel1.BackColor = Color.Aquamarine;
                DataGridViewUpdate();
            }
        }

        
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                selectedCellInDataGridView = dataGridView1[0, e.RowIndex].Value.ToString();


                CustomerID = dataGridView1[0, e.RowIndex].Value.ToString();
                label_ID.Text = string.Format("ID: {0}", CustomerID);
                CompanyName = CompanyName_textBox.Text = dataGridView1[1, e.RowIndex].Value.ToString();
                ContactName = ContactName_textBox.Text = dataGridView1[2, e.RowIndex].Value.ToString();
                Phone = Phone_textBox.Text = dataGridView1[3, e.RowIndex].Value.ToString();

            }
            else
            {
                CustomerID = "CustomerID";
                label_ID.Text = "ID: ?";
                CompanyName = "CompanyName";
                ContactName = "ContactName";
                Phone = "Phone";
            }

        }

        
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (DatabaseHandler.con == null || DatabaseHandler.con.State == ConnectionState.Closed)
            {

                if (showMessage)
                {
                    MessageBox.Show("Databaza nepripojena");
                }
                
            }
            else if (DatabaseHandler.con != null && DatabaseHandler.con.State == ConnectionState.Open)
            {

                insertCustomer.ShowDialog();

                if (insertCustomer.DialogResult == DialogResult.OK)
                {
                    DataGridViewUpdate();
                }

            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            DataGridViewUpdate();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            CompanyName = CompanyName_textBox.Text;
            ContactName = ContactName_textBox.Text;
            Phone = Phone_textBox.Text;

            if (DatabaseHandler.con == null || DatabaseHandler.con.State == ConnectionState.Closed)
            {

                if (showMessage)
                {
                    MessageBox.Show("Databaza nepripojena");
                }

            }
            else if (DatabaseHandler.con != null && DatabaseHandler.con.State == ConnectionState.Open)
            {
                var comand =
                    $"UPDATE Customers SET CompanyName = '{CompanyName}', ContactName = '{ContactName}', Phone = '{Phone}' WHERE CustomerID = {CustomerID}";
                DatabaseHandler.DatabeseQuery(DatabaseHandler.con, comand);
                DataGridViewUpdate();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (DatabaseHandler.con == null || DatabaseHandler.con.State == ConnectionState.Closed)
            {
                MessageBox.Show("Databaza nepripojena");

            }
            else if (dataGridView1.SelectedCells.Count > 0 && selectedCellInDataGridView != "")
            {

                if (showMessage)
                {
                    DialogResult result = MessageBox.Show($"Skutocne vymazat CustomerID {selectedCellInDataGridView} ?", "Potvrdenie",
                        MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        var command = $"DELETE FROM Customers WHERE CustomerID = '{selectedCellInDataGridView}'";
                        DatabaseHandler.DatabeseQuery(DatabaseHandler.con, command);
                        DataGridViewUpdate();
                    }
                }
                else
                {
                    var command = $"DELETE FROM Customers WHERE CustomerID = '{selectedCellInDataGridView}'";
                    DatabaseHandler.DatabeseQuery(DatabaseHandler.con, command);
                    DataGridViewUpdate();
                }
                
            }
            else
            {
                MessageBox.Show("chyba vyber");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("dddd, d.M.yyyy, HH:mm:ss");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            showMessage = Properties.Settings.Default.ShowMessage = checkBox1.Checked;
        }
    }
}
