using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using lib;

namespace Mesaurement_REST.DBUTil
{
    public class ManageMesaurement
    {
        private const string connString = @"Server=tcp:my-db-data.database.windows.net;
                                            Initial Catalog=myDatabase;User ID=luka2193;Password=Mwx88rey;
                                            Connect Timeout=60;
                                            Encrypt=True;
                                            TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False";

        private const string GET_ALL_SQL = "select * from Measurement";

        private const string GET_ONE_SQL = "SELECT * FROM Measurement WHERE Id = @Id";

        private const string INSERT_SQL = "insert into Measurement (Id, Pressure, Humidity, Temperature, Time) values (@Id, @Pressure, @Humidity, @Temperature, @Time)";

        private const string DELETE_SQL = "DELETE FROM Measurement WHERE Id = @Id";


        //En Hent-alle metode som skal create en list af alle users
        public IList<Mesaurement> GetAll()
        {
            IList<Mesaurement> users = new List<Mesaurement>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(GET_ALL_SQL, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read()) users.Add(ReadNextMeasurement(reader));
                }
            }

            return users;
        }

        //Opret tager alle vores varibler og indsætter dem som parameter som vi kan POST.
        public bool CreateMeasaurement(Mesaurement mesaurement)
        {
            var OK = true;
            using var conn = new SqlConnection(connString);
            conn.Open();

            using var cmd = new SqlCommand(INSERT_SQL, conn);
            cmd.Parameters.AddWithValue("@Id", mesaurement.Id);
            cmd.Parameters.AddWithValue("@Pressure", mesaurement.Pressure);
            cmd.Parameters.AddWithValue("@Humidity", mesaurement.Humidity);
            cmd.Parameters.AddWithValue("@Temperature", mesaurement.Temperature);
            cmd.Parameters.AddWithValue("@Time", mesaurement.Time);
            try
            {
                var rows = cmd.ExecuteNonQuery();
                OK = rows == 1;
            }
            catch (Exception)
            {
                OK = false;
            }

            return OK;
        }

        public Mesaurement GetById(int id)
        {
            var measurement = new Mesaurement();
            using var conn = new SqlConnection(connString);
            conn.Open();
            using (var cmd = new SqlCommand(GET_ONE_SQL, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                var reader = cmd.ExecuteReader();
                if (reader.Read()) measurement = ReadNextMeasurement(reader);
            }

            return measurement;
        }

        public Mesaurement DeleteMesurement(int id)
        {
            var measurement = GetById(id);
            if (measurement.Id != -1)
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(DELETE_SQL, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        var rows = cmd.ExecuteNonQuery();
                    }
                }

            return measurement;
        }

        //Den læser parameters igennem i User
        private Mesaurement ReadNextMeasurement(SqlDataReader reader)
        {
            var measurement = new Mesaurement();
            measurement.Id = reader.GetInt32(0);
            measurement.Pressure = reader.GetInt32(1);
            measurement.Humidity = reader.GetInt32(2);
            measurement.Temperature = reader.GetInt32(3);
            measurement.Time = reader.GetInt32(4);

            return measurement;
        }
    }
}