using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramingFundamentalsProject.TrainerApp
{
    internal class TrainerDAO
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=trainer_search_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Create a new Trainer
        public void Create(Trainer trainer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Trainers (Name, Place, Skill) VALUES (@Name, @Place, @Skill)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", trainer.name);
                cmd.Parameters.AddWithValue("@Place", trainer.place);
                cmd.Parameters.AddWithValue("@Skill", trainer.skill);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Read a Trainer by ID
        public Trainer Read(int id)
        {
            Trainer trainer = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Place, Skill FROM Trainers WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    trainer = new Trainer((int)reader["Id"], reader["Name"].ToString(),
                         reader["Place"].ToString(), reader["Skill"].ToString());
                }
            }
            return trainer;
        }

        // Update a Trainer
        public void Update(Trainer trainer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Trainers SET Name = @Name, Place = @Place, Skill = @Skill WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", trainer.id);
                cmd.Parameters.AddWithValue("@Name", trainer.name);
                cmd.Parameters.AddWithValue("@Place", trainer.place);
                cmd.Parameters.AddWithValue("@Skill", trainer.skill);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete a Trainer by ID
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Trainers WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // List all Trainers
        public List<Trainer> ListAll()
        {
            List<Trainer> trainers = new List<Trainer>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, Name, Place, Skill FROM Trainers";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Trainer trainer = new Trainer((int)reader["Id"], reader["Name"].ToString(),
                         reader["Place"].ToString(), reader["Skill"].ToString());
                    trainers.Add(trainer);
                }
            }
            return trainers;
        }
    }
}