using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NasCon_proj.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace NasCon_proj.Controllers
{
    public class AdminController
    {
        private MySqlConnection connection;

        public AdminController()
        {
            connection = DatabaseHelper.GetConnection();
        }


        public Dictionary<string, Dictionary<string, int>> GetEventRegistrationSummary()
        {
            Dictionary<string, Dictionary<string, int>> summary = new Dictionary<string, Dictionary<string, int>>();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT Events.Name, 
                         SUM(CASE WHEN Registrations.RegistrationType = 'Individual' THEN 1 ELSE 0 END) AS IndividualRegistrations,
                         SUM(CASE WHEN Registrations.RegistrationType = 'Team' THEN 1 ELSE 0 END) AS TeamRegistrations
                  FROM Events
                  LEFT JOIN Registrations ON Events.EventID = Registrations.EventID
                  GROUP BY Events.Name";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string eventName = reader["Name"].ToString();
                    int individualRegistrations = Convert.ToInt32(reader["IndividualRegistrations"]);
                    int teamRegistrations = Convert.ToInt32(reader["TeamRegistrations"]);

                    summary[eventName] = new Dictionary<string, int>
            {
                { "IndividualRegistrations", individualRegistrations },
                { "TeamRegistrations", teamRegistrations }
            };
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return summary;
        }

        public Dictionary<string, List<(int Rating, string Comment)>> GetFeedbackSummary()
        {
            Dictionary<string, List<(int Rating, string Comment)>> summary = new Dictionary<string, List<(int Rating, string Comment)>>();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT Events.Name, Feedback.Ratings, Feedback.Comments
                         FROM Events
                         LEFT JOIN Feedback ON Events.EventID = Feedback.EventID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string eventName = reader["Name"].ToString();
                    int rating = Convert.ToInt32(reader["Ratings"]);
                    string comment = reader["Comments"].ToString();

                    if (!summary.ContainsKey(eventName))
                    {
                        summary[eventName] = new List<(int Rating, string Comment)>();
                    }

                    summary[eventName].Add((rating, comment));
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return summary;
        }




    }


}
