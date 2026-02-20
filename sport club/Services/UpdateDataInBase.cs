using Microsoft.Data.Sqlite;
using sport_club.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_club.Services
{
    internal class UpdateDataInBase
    {
        public static void Update(object data)
        {
            using var conn = new SqliteConnection($"Data Source={SportClubDatabase.ConnectionString}");
            conn.Open();
            if (data is Coaches client)
            {
                using var cmd = new SqliteCommand($"update Coaches SET FullName = @name, SportType = @sport WHERE Id = @id", conn);

                cmd.Parameters.AddWithValue("@name", client.FullName);
                cmd.Parameters.AddWithValue("@sport", client.SportType);
                cmd.Parameters.AddWithValue("@id", client.Id); // 👈 ID для поиска записи

                cmd.ExecuteNonQuery();
            }
            else if (data is Sportsmen dish)
            {
                using var cmd = new SqliteCommand($"update Sportsmen SET FullName = @Name, Birthday = @Price, ParentPhone = @category WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@Name", dish.FullName);
                cmd.Parameters.AddWithValue("@Price", dish.Birthday);
                cmd.Parameters.AddWithValue("@category", dish.ParentPhone);
                cmd.Parameters.AddWithValue("@id", dish.Id); // 👈 ID для поиска записи

                cmd.ExecuteNonQuery();
            }
            else if (data is Attendances attendances)
            {
                using var cmd = new SqliteCommand($"update Attendances SET TrainingDate = @trdata, Attended = @isattend WHERE Id = @id" , conn);
                cmd.Parameters.AddWithValue("@trdata", attendances.TrainingDate.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@isattend", attendances.IsAttended ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", attendances.Id); // 👈 ID для поиска записи
                cmd.ExecuteNonQuery();
            }

            conn.Close();
        }
    }
}
