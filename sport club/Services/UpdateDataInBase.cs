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
            else if (data is Sportsmen s)
            {
                bool IsValidPhone(string phone)
                {
                    if (string.IsNullOrWhiteSpace(phone)) return false;

                    var digits = new string(phone.Where(char.IsDigit).ToArray());
                    return digits.Length == 10 || (digits.Length == 11 && (digits.StartsWith("7") || digits.StartsWith("8")));
                }

                string FormatPhone(string raw)
                {
                    if (string.IsNullOrWhiteSpace(raw)) return raw;

                    // Оставляем только цифры
                    var digits = new string(raw.Where(char.IsDigit).ToArray());

                    // Если начинается с 8 и 11 цифр → меняем на 7
                    if (digits.Length == 11 && digits.StartsWith("8"))
                        digits = "7" + digits.Substring(1);

                    // Если 11 цифр и начинается с 7 → оставляем как есть
                    if (digits.Length == 11 && digits.StartsWith("7"))
                        return $"+7 ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9, 2)}";

                    // Если 10 цифр → добавляем +7
                    if (digits.Length == 10)
                        return $"+7 ({digits.Substring(0, 3)}) {digits.Substring(3, 3)}-{digits.Substring(6, 2)}-{digits.Substring(8, 2)}";

                    // Если не подошло → возвращаем как есть
                    return raw;
                }

                // 🔴 Сначала проверяем номер телефона
                if (!IsValidPhone(s.ParentPhone))
                {
                    MessageBox.Show("Некорректный номер телефона родителя!\nФормат: +7 (XXX) XXX-XX-XX",
                                   "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // прерываем выполнение, не сохраняем
                }

                // 🟢 Если номер валидный — продолжаем сохранение
                using var cmd = new SqliteCommand(
                    "UPDATE Sportsmen SET FullName = @FullName, Birthday = @Birthday, ParentPhone = @ParentPhone WHERE Id = @id",
                    conn);

                cmd.Parameters.AddWithValue("@FullName", s.FullName);
                cmd.Parameters.AddWithValue("@Birthday", s.Birthday);
                cmd.Parameters.AddWithValue("@ParentPhone", FormatPhone(s.ParentPhone));
                cmd.Parameters.AddWithValue("@id", s.Id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Данные успешно сохранены!");
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
