using sport_club.Models;
using Microsoft.Data.Sqlite;

namespace sport_club.Services
{
    internal class SportClubDatabase
    {
        public static readonly string ConnctionString = Path.Combine(AppContext.BaseDirectory, @"..\..\..\SportClub.db");

        public static List<Sportsmen> GetSportsmens()
        {
            using var conn = new SqliteConnection($"Data source ={ConnctionString}");
            conn.Open();

            List<Sportsmen> sportsmens = new();
            using var cmd = new SqliteCommand("SELECT * From Sportsmen", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                sportsmens.Add(new Sportsmen
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Birthday = reader.GetDateTime(2),
                    ParentPhone = reader.GetString(3),
                });
            }
            return sportsmens;
        }
        public static List<Coaches> GetCoaches()
        {
            using var conn = new SqliteConnection($"Data source ={ConnctionString}");
            conn.Open();

            List<Coaches> coaches = new();
            using var cmd = new SqliteCommand("SELECT * From Coaches", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                coaches.Add(new Coaches
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    SportType = reader.GetString(2),
                });
            }
            return coaches;
        }
        public static List<Attendances> GetAttendances()
        {
            using var conn = new SqliteConnection($"Data source ={ConnctionString}");
            conn.Open();

            List<Attendances> attendances = new();
            using var cmd = new SqliteCommand("SELECT * From Attendances", conn);

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                attendances.Add(new Attendances
                {
                    Id = reader.GetInt32(0),
                    SportsmenId = Attendances.GetSportsmen(reader.GetString(1)),
                    CoachesId = Attendances.GetCoaches(reader.GetInt32(2)),
                    TrainingDate = reader.GetDateTime(3),
                    IsAttended = reader.GetBoolean(4),
                });
            }
            return attendances;
        }
    }
}
