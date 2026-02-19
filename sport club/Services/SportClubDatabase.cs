using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using sport_club.Models;

namespace sport_club.Services
{
    internal class SportClubDatabase
    {
        public static readonly string ConnectionString = 
            Path.Combine(AppContext.BaseDirectory, @"..\..\..\SportClub.db");

        private static List<T> GetRecords<T>(string query, Func<SqliteDataReader, T> mapper)
        {
            using var conn = new SqliteConnection($"Data source ={ConnectionString}");
            conn.Open();

            List<T> records = new();
            using var cmd = new SqliteCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                records.Add(mapper(reader));
            }

            return records;
        }

        public static List<Sportsmen> GetSportsmens()
        {
            return GetRecords(
                "SELECT * FROM Sportsmen",
                reader => new Sportsmen
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Birthday = reader.GetDateTime(2),
                    ParentPhone = reader.GetString(3),
                }
            );
        }

        public static List<Coaches> GetCoaches()
        {
            return GetRecords(
                "SELECT * FROM Coaches",
                reader => new Coaches
                {
                    Id = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    SportType = reader.GetString(2),
                }
            );
        }

        public static List<Attendances> GetAttendances()
        {
            return GetRecords(
                "SELECT * FROM Attendances",
                reader => new Attendances
                {
                    Id = reader.GetInt32(0),
                    SportsmenId = Attendances.GetSportsmen(reader.GetInt32(1)),
                    CoachesId = Attendances.GetCoaches(reader.GetInt32(2)),
                    TrainingDate = reader.GetDateTime(3),
                    IsAttended = reader.GetBoolean(4),
                }
            );
        }

        public static List<SkipperReport> GetSkippersReport(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT * FROM v_Skippers 
                WHERE TrainingDate BETWEEN @start AND @end
                ORDER BY TrainingDate DESC";

            using var conn = new SqliteConnection($"Data source ={ConnectionString}");
            conn.Open();

            using var cmd = new SqliteCommand(query, conn);
            cmd.Parameters.AddWithValue("@start", startDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@end", endDate.ToString("yyyy-MM-dd"));

            List<SkipperReport> reports = new();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                reports.Add(new SkipperReport
                {
                    SportsmanId = reader.GetInt32(0),
                    SportsmanName = reader.GetString(1),
                    Birthday = reader.GetDateTime(2),
                    ParentPhone = reader.GetString(3),
                    TrainingDate = reader.GetDateTime(4),
                    CoachName = reader.GetString(5),
                    SportType = reader.GetString(6)
                });
            }

            return reports;
        }

        public static List<CoachStatistics> GetCoachStatistics()
        {
            return GetRecords(
                "SELECT * FROM v_CoachStatistics ORDER BY AttendancePercentage DESC",
                reader => new CoachStatistics
                {
                    CoachId = reader.GetInt32(0),
                    CoachName = reader.GetString(1),
                    SportType = reader.GetString(2),
                    TotalTrainings = reader.GetInt32(3),
                    AttendedTrainings = reader.GetInt32(4),
                    SkippedTrainings = reader.GetInt32(5),
                    AttendancePercentage = reader.IsDBNull(6) ? null  : reader.GetDouble(6),
                }
            );
        }

        public static List<ChildActivity> GetChildActivityReport()
        {
            return GetRecords(
                "SELECT * FROM v_ChildActivity ORDER BY AttendancePercentage DESC",
                reader => new ChildActivity
                {
                    SportsmanId = reader.GetInt32(0),
                    SportsmanName = reader.GetString(1),
                    Birthday = reader.GetDateTime(2),
                    Age = reader.GetInt32(3),
                    TotalTrainings = reader.GetInt32(4),
                    AttendedCount = reader.GetInt32(5),
                    SkippedCount = reader.GetInt32(6),
                    AttendancePercentage = reader.IsDBNull(7) ? null : reader.GetDouble(7),
                }
            );
        }
    }
}