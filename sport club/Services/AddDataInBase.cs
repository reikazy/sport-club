using Microsoft.Data.Sqlite;
using sport_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_club.Services
{
    public class AddDataInBase
    {
        public static Coaches AddCoaches(Coaches client)
        {
            using var conn = new SqliteConnection($"Data Source={SportClubDatabase.ConnectionString}");
            conn.Open();

            using var cmd = new SqliteCommand("INSERT INTO Coaches (FullName, SportType) VALUES (@name, @sport)", conn);
            cmd.Parameters.AddWithValue("@name", client.FullName);
            cmd.Parameters.AddWithValue("@sport", client.SportType);
            cmd.ExecuteNonQuery();

            client.Id = GetId();

            return client;
        }
        public static Sportsmen AddSportsmen(Sportsmen dishes)
        {
            using var conn = new SqliteConnection($"Data Source={SportClubDatabase.ConnectionString}");
            conn.Open();

            using var cmd = new SqliteCommand("INSERT INTO Sportsmen (FullName, Birthday, ParentPhone) VALUES (@name, @birthday, @phone)", conn);
            cmd.Parameters.AddWithValue("@name", dishes.FullName);
            cmd.Parameters.AddWithValue("@birthday", dishes.Birthday);
            cmd.Parameters.AddWithValue("@phone", dishes.ParentPhone);

            cmd.ExecuteNonQuery();
            using var cmdId = new SqliteCommand("SELECT last_insert_rowid()", conn);

            dishes.Id = Convert.ToInt32(cmdId.ExecuteScalar());

            return dishes;
        }
        public static Attendances AddAttendances(Attendances order)
        {
            using var conn = new SqliteConnection($"Data Source={SportClubDatabase.ConnectionString}");
            conn.Open();

            using var cmd = new SqliteCommand("INSERT INTO Attendances (SportsmenId, CoachesId, TrainingDate, IsAttended) VALUES (@spId, @coachId, @trdata, @isattend)", conn);
            cmd.Parameters.AddWithValue("@spId", order.SportsmenId);
            cmd.Parameters.AddWithValue("@coachId", order.CoachesId);
            cmd.Parameters.AddWithValue("@trdata", order.TrainingDate.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@isattend", order.IsAttended ? 1 : 0);
            cmd.ExecuteNonQuery();

            order.Id = GetId();

            return order;
        }

        public static int GetId()
        {
            using var conn = new SqliteConnection($"Data Source={SportClubDatabase.ConnectionString}");
            conn.Open();

            using var cmd = new SqliteCommand("SELECT last_insert_rowid();", conn);
            int id = Convert.ToInt32(cmd.ExecuteScalar());

            return id;



        }
    }
}
