using NasCon_proj.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace NasCon_proj.Controllers
{
    public class EventController
    {
        private MySqlConnection connection;

        public EventController()
        {
            connection = DatabaseHelper.GetConnection();
        }

        public List<Event> GetEvents(string categoryName)
        {
            List<Event> events = new List<Event>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT 
                        Events.EventID, 
                        Events.Name, 
                        Events.CategoryName, 
                        Events.Description, 
                        Events.Date, 
                        Events.Venue, 
                        Events.RegistrationPrice, 
                        Events.EventType, 
                        Events.Capacity
                    FROM 
                        Events";

                if (!string.IsNullOrEmpty(categoryName) && categoryName != "All")
                {
                    query += " WHERE Events.CategoryName = @CategoryName";
                }

                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (!string.IsNullOrEmpty(categoryName) && categoryName != "All")
                {
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                }

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    events.Add(new Event
                    {
                        EventID = Convert.ToInt32(row["EventID"]),
                        Name = row["Name"].ToString(),
                        CategoryName = row["CategoryName"].ToString(),
                        Description = row["Description"].ToString(),
                        Date = Convert.ToDateTime(row["Date"]),
                        Venue = row["Venue"].ToString(),
                        RegistrationPrice = Convert.ToDecimal(row["RegistrationPrice"]),
                        EventType = Convert.ToBoolean(row["EventType"]),
                        Capacity = Convert.ToInt32(row["Capacity"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return events;
        }

        public List<string> GetEventCategories()
        {
            List<string> categories = new List<string>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT DISTINCT CategoryName FROM Events";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    categories.Add(row["CategoryName"].ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return categories;
        }
    

        public Event GetEventByName(string eventName)
        {
            Event selectedEvent = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT * FROM Events WHERE Name = @EventName";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EventName", eventName);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        selectedEvent = new Event
                        {
                            EventID = Convert.ToInt32(reader["EventID"]),
                            Name = reader["Name"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(), 
                            Description = reader["Description"].ToString(), 
                            Date = Convert.ToDateTime(reader["Date"]),
                            Venue = reader["Venue"].ToString(),
                            RegistrationPrice = Convert.ToDecimal(reader["RegistrationPrice"]),
                            EventType = Convert.ToBoolean(reader["EventType"]),
                            Capacity = Convert.ToInt32(reader["Capacity"]),
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return selectedEvent;
        }

        public bool RegisterForEvent(int userID, int eventID, int? teamID, string registrationType)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string checkQuery = @"SELECT COUNT(*) FROM Registrations WHERE UserID = @UserID AND EventID = @EventID";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@UserID", userID);
                checkCmd.Parameters.AddWithValue("@EventID", eventID);

                int existingRegistrations = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (existingRegistrations > 0)
                {
                    return false;
                }

                string query = @"INSERT INTO Registrations (UserID, EventID, TeamID, RegistrationType, RegistrationDate) 
                                 VALUES (@UserID, @EventID, @TeamID, @RegistrationType, @RegistrationDate)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@EventID", eventID);
                cmd.Parameters.AddWithValue("@TeamID", (object)teamID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@RegistrationType", registrationType);
                cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

      

        public List<Event> GetBookedEvents(int userID)
        {
            List<Event> bookedEvents = new List<Event>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT Events.EventID, Events.Name, Events.Date, Events.Venue, Events.RegistrationPrice, Events.CategoryName, Events.Description
                                 FROM Events
                                 INNER JOIN Registrations ON Events.EventID = Registrations.EventID
                                 WHERE Registrations.UserID = @UserID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userID);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    bookedEvents.Add(new Event
                    {
                        EventID = Convert.ToInt32(row["EventID"]),
                        Name = row["Name"].ToString(),
                        Date = Convert.ToDateTime(row["Date"]),
                        Venue = row["Venue"].ToString(),
                        RegistrationPrice = Convert.ToDecimal(row["RegistrationPrice"]),
                        CategoryName = row["CategoryName"].ToString(),
                        Description = row["Description"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return bookedEvents;
        }
        public List<FoodDeal> GetFoodDeals()
        {
            List<FoodDeal> foodDeals = new List<FoodDeal>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Query to retrieve available food deals
                string query = "SELECT * FROM FoodDeals";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    foodDeals.Add(new FoodDeal
                    {
                        DealID = Convert.ToInt32(row["DealID"]),
                        DealName = row["DealName"].ToString(),
                        Price = Convert.ToDecimal(row["Price"]),
                        Description = row["Description"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return foodDeals;
        }

       

        public bool RegisterParticipantForFoodDeal(int userID, int dealID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string checkQuery = @"SELECT COUNT(*) FROM ParticipantFoodDeals WHERE UserID = @UserID AND DealID = @DealID";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@UserID", userID);
                checkCmd.Parameters.AddWithValue("@DealID", dealID);

                int existingRecords = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (existingRecords > 0)
                {
                    Console.WriteLine("User has already registered the deal.");
                    return false; // User has already registered the deal
                }

                string query = @"INSERT INTO ParticipantFoodDeals (UserID, DealID) 
                         VALUES (@UserID, @DealID)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@DealID", dealID);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<FoodDeal> GetRegisteredFoodDealsByUserID(int userID)
        {
            List<FoodDeal> registeredFoodDeals = new List<FoodDeal>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT FoodDeals.DealID, FoodDeals.DealName, FoodDeals.Price, FoodDeals.Description
                         FROM FoodDeals
                         INNER JOIN ParticipantFoodDeals ON FoodDeals.DealID = ParticipantFoodDeals.DealID
                         WHERE ParticipantFoodDeals.UserID = @UserID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userID);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    registeredFoodDeals.Add(new FoodDeal
                    {
                        DealID = Convert.ToInt32(row["DealID"]),
                        DealName = row["DealName"].ToString(),
                        Price = Convert.ToDecimal(row["Price"]),
                        Description = row["Description"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return registeredFoodDeals;
        }



        public List<Event> GetSponsoredEvents(int userID)
        {
            List<Event> sponsoredEvents = new List<Event>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT Events.EventID, 
                         Events.Name, 
                         Events.CategoryName, 
                         Events.Description, 
                         Events.Date, 
                         Events.Venue, 
                         Events.RegistrationPrice, 
                         Events.EventType, 
                         Events.Capacity
                  FROM Events
                  INNER JOIN Sponsorship ON Events.EventID = Sponsorship.EventID
                  WHERE Sponsorship.UserID = @UserID";
        
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userID);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    sponsoredEvents.Add(new Event
                    {
                        EventID = Convert.ToInt32(row["EventID"]),
                        Name = row["Name"].ToString(),
                        CategoryName = row["CategoryName"].ToString(),
                        Description = row["Description"].ToString(),
                        Date = Convert.ToDateTime(row["Date"]),
                        Venue = row["Venue"].ToString(),
                        RegistrationPrice = Convert.ToDecimal(row["RegistrationPrice"]),
                        EventType = Convert.ToBoolean(row["EventType"]),
                        Capacity = Convert.ToInt32(row["Capacity"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return sponsoredEvents;
        }


        public bool RegisterSponsorship(int userID, int sponsorID, int eventID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string checkQuery = "SELECT COUNT(*) FROM Sponsors WHERE SponsorID = @SponsorID AND UserID = @UserID";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@SponsorID", sponsorID);
                checkCmd.Parameters.AddWithValue("@UserID", userID);

                int sponsorCount = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (sponsorCount == 0)
                {
                    Console.WriteLine("The specified SponsorID does not belong to the given UserID.");
                    return false;
                }

                string query = @"INSERT INTO Sponsorship (SponsorID, UserID, EventID) 
                         VALUES (@SponsorID, @UserID, @EventID)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@SponsorID", sponsorID);
                cmd.Parameters.AddWithValue("@EventID", eventID);
                cmd.Parameters.AddWithValue("@UserID", userID);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


        public List<SponsorM> GetSponsorPackagesByUserID(int userID)
        {
            List<SponsorM> packages = new List<SponsorM>();

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"SELECT SponsorID, CompanyName, PackageName, Benefits, Cost
                         FROM Sponsors
                         WHERE UserID = @UserID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userID);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    packages.Add(new SponsorM
                    {
                        PackageID = Convert.ToInt32(row["SponsorID"]),
                        CompanyName = row["CompanyName"].ToString(),
                        PackageName = row["PackageName"].ToString(),
                        Benefits = row["Benefits"].ToString(),
                        Cost = Convert.ToDecimal(row["Cost"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return packages;
        }

        public bool UpdateEvent(Event updatedEvent)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"UPDATE Events SET 
                            Name = COALESCE(@Name, Name),
                            CategoryName = COALESCE(@CategoryName, CategoryName),
                            Description = COALESCE(@Description, Description),
                            Date = COALESCE(@Date, Date),
                            Venue = COALESCE(@Venue, Venue),
                            RegistrationPrice = COALESCE(@RegistrationPrice, RegistrationPrice),
                            Capacity = COALESCE(@Capacity, Capacity)
                        WHERE EventID = @EventID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EventID", updatedEvent.EventID);
                cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(updatedEvent.Name) ? DBNull.Value : (object)updatedEvent.Name);
                cmd.Parameters.AddWithValue("@CategoryName", string.IsNullOrEmpty(updatedEvent.CategoryName) ? DBNull.Value : (object)updatedEvent.CategoryName);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(updatedEvent.Description) ? DBNull.Value : (object)updatedEvent.Description);
                cmd.Parameters.AddWithValue("@Date", updatedEvent.Date == DateTime.Today ? DBNull.Value : (object)updatedEvent.Date);
                cmd.Parameters.AddWithValue("@Venue", string.IsNullOrEmpty(updatedEvent.Venue) ? DBNull.Value : (object)updatedEvent.Venue);
                cmd.Parameters.AddWithValue("@RegistrationPrice", updatedEvent.RegistrationPrice == 0 ? DBNull.Value : (object)updatedEvent.RegistrationPrice);
                cmd.Parameters.AddWithValue("@Capacity", updatedEvent.Capacity == 0 ? DBNull.Value : (object)updatedEvent.Capacity);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT * FROM Users";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    users.Add(new User
                    {
                        UserID = Convert.ToInt32(row["UserID"]),
                        Username = row["Username"].ToString(),
                        Email = row["Email"].ToString(),
                        RoleID = Convert.ToInt32(row["RoleID"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return users;
        }

        public bool UpdateUser(int userID, string username, string password, string email)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"UPDATE Users 
                         SET Username = COALESCE(@Username, Username), 
                             PasswordHash = COALESCE(@PasswordHash, PasswordHash), 
                             Email = COALESCE(@Email, Email) 
                         WHERE UserID = @UserID";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@Username", string.IsNullOrEmpty(username) ? DBNull.Value : (object)username);
                cmd.Parameters.AddWithValue("@PasswordHash", string.IsNullOrEmpty(password) ? DBNull.Value : (object)password);
                cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? DBNull.Value : (object)email);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteUser(int userID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "DELETE FROM Users WHERE UserID = @UserID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userID);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool RegisterTeam(int leaderID, string teamName)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Check if the team name already exists
                string checkQuery = "SELECT COUNT(*) FROM Teams WHERE TeamName = @TeamName";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@TeamName", teamName);

                int existingTeams = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (existingTeams > 0)
                {
                    Console.WriteLine("Team name already exists.");
                    return false; // Team name already exists
                }

                // Insert the team into the database
                string query = "INSERT INTO Teams (TeamName, LeaderID) VALUES (@TeamName, @LeaderID)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@TeamName", teamName);
                cmd.Parameters.AddWithValue("@LeaderID", leaderID);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        // Method to get expired events
        public List<Event> GetExpiredEvents()
        {
            List<Event> expiredEvents = new List<Event>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT * FROM Events WHERE Date < CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Event evt = new Event
                        {
                            EventID = Convert.ToInt32(reader["EventID"]),
                            Name = reader["Name"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            Description = reader["Description"].ToString(),
                            Date = Convert.ToDateTime(reader["Date"]),
                            Venue = reader["Venue"].ToString(),
                            RegistrationPrice = Convert.ToDecimal(reader["RegistrationPrice"]),
                            EventType = Convert.ToBoolean(reader["EventType"]),
                            Capacity = Convert.ToInt32(reader["Capacity"])
                        };
                        expiredEvents.Add(evt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return expiredEvents;
        }

        public bool SubmitFeedback(int userId, int eventId, int rating, string comments)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"INSERT INTO Feedback (UserID, EventID, Ratings, Comments, FeedbackDate) 
                                 VALUES (@UserID, @EventID, @Ratings, @Comments, @FeedbackDate)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserID", userId);
                cmd.Parameters.AddWithValue("@EventID", eventId);
                cmd.Parameters.AddWithValue("@Ratings", rating);
                cmd.Parameters.AddWithValue("@Comments", comments);
                cmd.Parameters.AddWithValue("@FeedbackDate", DateTime.Now);


                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        // Method to delete an event by eventID
        public bool DeleteEvent(int eventID)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "DELETE FROM Events WHERE EventID = @EventID";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EventID", eventID);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        public bool AddEvent(string name, string categoryName, string description, DateTime date, string venue, decimal registrationPrice, bool eventType, int capacity)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"INSERT INTO Events (Name, CategoryName, Description, Date, Venue, RegistrationPrice, EventType, Capacity) 
                        VALUES (@Name, @CategoryName, @Description, @Date, @Venue, @RegistrationPrice, @EventType, @Capacity)";

                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.Parameters.AddWithValue("@Venue", venue);
                cmd.Parameters.AddWithValue("@RegistrationPrice", registrationPrice);
                cmd.Parameters.AddWithValue("@EventType", eventType);
                cmd.Parameters.AddWithValue("@Capacity", capacity);

                int rowsAffected = cmd.ExecuteNonQuery();

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }


    }


}
