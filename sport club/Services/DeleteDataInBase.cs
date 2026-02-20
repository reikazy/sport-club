using sport_club.Models;
using sport_club.Services;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_club.Services
{
    internal class DeleteDataInBase
    {
        public static void RemoveAttendance(int id)
        {
            using var conn = new SqliteConnection($"Data Source={SportClubDatabase.ConnectionString}");
            conn.Open();

            using var cmd = new SqliteCommand($"DELETE FROM Attendances WHERE id = {id}", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void RemoveCoache(int id)
        {
            using var conn = new SqliteConnection($"Data Source={SportClubDatabase.ConnectionString}");
            conn.Open();

            using var cmd = new SqliteCommand($"DELETE FROM Coaches WHERE id = {id}", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void RemoveSportsmen(int id)
        {
            using var conn = new SqliteConnection($"Data Source={SportClubDatabase.ConnectionString}");
            conn.Open();

            using var cmd = new SqliteCommand($"DELETE FROM Sportsmen WHERE id = {id}", conn);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
