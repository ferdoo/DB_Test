using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DB_Test
{
    public static class DatabaseHandler
    {
        public static System.Data.SqlClient.SqlConnection con;

        
        /// <summary>
        /// Pripjit k databaze
        /// </summary>
        public static void Connect()
        {


            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(LocalDB)\MSSQLLocalDB";
            builder.AttachDBFilename = @"D:\VS repos\DB_Test\DB_Test\Database1.mdf";
            builder.IntegratedSecurity = true;
            builder.ConnectTimeout = 30;


            con = new System.Data.SqlClient.SqlConnection();

            con.ConnectionString = builder.ConnectionString;

            //con.OpenAsync(cancellationToken: new CancellationToken(CancelOpenning));
            con.Open();
        }

        /// <summary>
        /// SqlDataAdapter
        /// </summary>
        /// <param name="connection - Pripojenie k DB"></param>
        /// <param name="CommandText - SQL Statement"></param>
        /// <returns>Vracia DataSet</returns>
        public static DataSet SelectQuery(System.Data.SqlClient.SqlConnection connection, string CommandText)
        {
            try
            {
                var dataAdapter = new SqlDataAdapter(CommandText, connection);
                var ds = new DataSet();
                dataAdapter.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.ShowMessage)
                {
                    MessageBox.Show(ex.Message);
                    Logger.Log("SelectQuery", ex);
                }
                return null;
            }
            
        }

        /// <summary>
        /// SqlCommand
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="CommandText"></param>
        public static void DatabeseQuery(System.Data.SqlClient.SqlConnection connection, string CommandText)
        {
            SqlCommand cmd = new SqlCommand(CommandText, connection);

            var commandType = CommandText.Substring(0, CommandText.IndexOf(" "));
            var msgTXTOK = "";

            switch (commandType)
            {
                case "INSERT":
                    msgTXTOK = "Zaznam vlozeny uspesne";
                    break;
                case "DELETE":
                    msgTXTOK = "Zaznam zmazany uspesne";
                    break;
                case "UPDATE":
                    msgTXTOK = "Zaznam aktualizovany uspesne";
                    break;
            }
            

            try
            {
                cmd.ExecuteNonQuery();
                if (Properties.Settings.Default.ShowMessage)
                {
                    MessageBox.Show(msgTXTOK);
                    
                }
                

            }
            catch (SqlException ex)
            {
                if (Properties.Settings.Default.ShowMessage)
                {
                    MessageBox.Show("Error Generated. Details: " + ex.ToString());
                    Logger.Log("SelectQuery", ex);
                }
                
            }
        }

        

    }
}