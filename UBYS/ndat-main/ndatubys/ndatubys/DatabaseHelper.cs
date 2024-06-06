using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;
using System.Configuration; // Bu satırı ekleyin
using System.Data;

namespace ndatubys
{
    internal class DatabaseHelper
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public string ValidateUser(string KimlikNumarası, string Parola)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string studentQuery = "SELECT COUNT(*) FROM OGRENCI WHERE TcNo = @KimlikNumarası AND Parola = @Parola";
                using (SqlCommand studentCommand = new SqlCommand(studentQuery, connection))
                {
                    studentCommand.Parameters.AddWithValue("@KimlikNumarası", KimlikNumarası);
                    studentCommand.Parameters.AddWithValue("@Parola", Parola);

                    int studentCount = (int)studentCommand.ExecuteScalar();
                    if (studentCount > 0)
                    {
                        return "Student";
                    }
                }

                string teacherQuery = "SELECT COUNT(*) FROM OGRETIMELEMANI WHERE TcNo = @KimlikNumarası AND Parola = @Parola";
                using (SqlCommand teacherCommand = new SqlCommand(teacherQuery, connection))
                {
                    teacherCommand.Parameters.AddWithValue("@KimlikNumarası", KimlikNumarası);
                    teacherCommand.Parameters.AddWithValue("@Parola", Parola);

                    int teacherCount = (int)teacherCommand.ExecuteScalar();
                    if (teacherCount > 0)
                    {
                        return "Teacher";
                    }
                }
                string idareciQuery = "SELECT COUNT(*) FROM IDARECI WHERE TcNo = @KimlikNumarası AND Parola = @Parola";
                using (SqlCommand idareciCommand = new SqlCommand(idareciQuery, connection))
                {
                    idareciCommand.Parameters.AddWithValue("@KimlikNumarası", KimlikNumarası);
                    idareciCommand.Parameters.AddWithValue("@Parola", Parola);

                    int idareciCount = (int)idareciCommand.ExecuteScalar();
                    if (idareciCount > 0)
                    {
                        return "Idareci";
                    }
                }
                string syoneticiQuery = "SELECT COUNT(*) FROM SYONETICI WHERE TcNo = @KimlikNumarası AND Parola = @Parola";
                using (SqlCommand syoneticiCommand = new SqlCommand(syoneticiQuery, connection))
                {
                    syoneticiCommand.Parameters.AddWithValue("@KimlikNumarası", KimlikNumarası);
                    syoneticiCommand.Parameters.AddWithValue("@Parola", Parola);

                    int syoneticiCount = (int)syoneticiCommand.ExecuteScalar();
                    if (syoneticiCount > 0)
                    {
                        return "SistemYoneticisi";
                    }
                }


            }
            return null; // Geçersiz kullanıcı
        }
       

        public void UpdateNot(string ogrenciNo, int vizeNot, int finalNot)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE PUAN 
                    SET VizeNot = @VizeNot, 
                        FinalNot = @FinalNot, 
                        Ortalama = @Ortalama, 
                        HarfNotu = @HarfNotu 
                    WHERE OgrenciNo = @OgrenciNo";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OgrenciNo", ogrenciNo);
                    command.Parameters.AddWithValue("@VizeNot", vizeNot);
                    command.Parameters.AddWithValue("@FinalNot", finalNot);


                    // Ortalama hesaplama
                    float ortalama = (float)(vizeNot * 0.4) + (float)(finalNot * 0.6);
                    command.Parameters.AddWithValue("@Ortalama", ortalama);

                    // Harf notu hesaplama
                    string harfNotu = HesaplaHarfNotu(ortalama);
                    command.Parameters.AddWithValue("@HarfNotu", harfNotu);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private string HesaplaHarfNotu(float ortalama)
        {
            if (ortalama >= 90) return "AA";
            else if (ortalama >= 85) return "BA";
            else if (ortalama >= 80) return "BB";
            else if (ortalama >= 75) return "CB";
            else if (ortalama >= 70) return "CC";
            else if (ortalama >= 65) return "DC";
            else if (ortalama >= 60) return "DD";
            else if (ortalama >= 50) return "FD";
            else return "FF";
        }

        public DataTable GetUpdatedGrades()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT OgrenciNo, VizeNot, FinalNot, Ortalama, HarfNotu FROM PUAN";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
        }

    }
}
