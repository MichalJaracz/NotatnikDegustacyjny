using MySql.Data.MySqlClient;
using System;

namespace AndroidApp1
{
    public class UsersDatabaseHelper
    {
        private string connectionString = "Server=localhost;Port=3306;database=users_db;User Id=root@localhost;Password=12345678@.;SslMode=None;";

        public bool TestConnection()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    return true; // Połączenie udane
                }
            }
            catch (Exception)
            {
                return false; // Błąd połączenia
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}