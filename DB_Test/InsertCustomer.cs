using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Test
{
    public partial class InsertCustomer : Form
    {

        public InsertCustomer()
        {
            InitializeComponent();

        }


        //private string CompanyName;
        //public string companyName
        //{
        //    get
        //    {
        //        return CompanyName;
        //    }

        //    set
        //    {
        //        CompanyName = value;
        //        CompanyName_textBox.Text = value;
        //    }
        //}


        private void BtnInsertCustomer_Click(object sender, EventArgs e)
        {
        
            var CompanyName = CompanyName_textBox.Text;
            var ContactName = ContactName_textBox.Text;
            var Phone = Phone_textBox.Text;


            if (CompanyName == "" || ContactName == "" || Phone == "" )
            {
                MessageBox.Show("Vsetky polia su povinne");
            }
            else
            {
                var comand = $"INSERT INTO Customers (CompanyName, ContactName, Phone) VALUES ('{CompanyName}', '{ContactName}', '{Phone}')";

                DatabaseHandler.DatabeseQuery(DatabaseHandler.con, comand);
                DialogResult = DialogResult.OK;
            }


        }
    }
}
