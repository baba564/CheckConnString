using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckConnectionString.SQLconnect
{
    public class SqlConnect
    {
        public static void CheckConnect(string connectionString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Do work here; connection closed on following line.
                    connection.Close();
                    var connectionS= connection.ConnectionString;
                    MessageBox.Show($"Zalogowano pomyślnie. Connection string: {connectionS}","Pomyślnie zalogowano",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show($"Bład logowania: {e}","Error", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}
