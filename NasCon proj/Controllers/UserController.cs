using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasCon_proj.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace NasCon_proj.Controllers
{
    public class UserController
    {
        private MySqlConnection connection;

        public UserController()
        {
            connection = DatabaseHelper.GetConnection();
        }

        public bool RegisterUser(User user)
        {
            try
            {
                if (!IsPasswordValid(user.Password))
                {
                    MessageBox.Show("Password must be at least 8 characters long and contain at least one digit, one letter, and one special character.");
                    return false;
                }

                if (connection.State != ConnectionState.Open)
                    connection.Open();

                
                string query = "INSERT INTO Users (Username, PasswordHash, Email, RoleID) " +
                               "VALUES (@Username, @Password, @Email, @RoleID)";

               
                MySqlCommand cmd = new MySqlCommand(query, connection);

                
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@RoleID", user.RoleID);

                int rowsAffected = cmd.ExecuteNonQuery();

               
                connection.Close();

               
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        // Helper method to check if a password meets the specified constraints
        private bool IsPasswordValid(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsDigit) &&
                   password.Any(char.IsLetter) &&
                   password.Any(IsSpecialCharacter);
        }

        // Helper method to check if a character is a special character
        private bool IsSpecialCharacter(char c)
        {
            return !char.IsLetterOrDigit(c);
        }

        public User LoginUser(string email, string password)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // SQL command to retrieve user based on email and password
                string query = "SELECT * FROM Users WHERE Email = @Email AND PasswordHash = @Password";

                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User
                        {
                            UserID = Convert.ToInt32(reader["UserID"]),
                            Username = Convert.ToString(reader["Username"]),
                            Email = Convert.ToString(reader["Email"]),
                            RoleID = Convert.ToInt32(reader["RoleID"])
                        };
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
