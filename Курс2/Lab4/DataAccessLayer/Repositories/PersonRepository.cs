using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DataAccessLayer.Interfaces;
using DBModels.Entities;

namespace DataAccessLayer.Repositories
{
    internal class PersonRepository : IRepository<Persons>
    {
        private readonly string _connectionString;
        public PersonRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Persons item)
        {
            throw new NotImplementedException();
        }

        public void Update(Persons item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DateTime Date)
        {
            throw new NotImplementedException();
        }

        public Persons Get(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Persons> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var persons = new List<Persons>();

                try
                {
                    var command = new SqlCommand("GetListOfPersons", connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    var reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var person = new Persons();
                            person.Id = reader.GetInt32(0);
                            person.FIO = reader.GetString(1);
                            person.PhoneNumber = reader.GetString(2);
                            person.Job = reader.GetString(3);
                            person.BirthDay = reader.GetDateTime(4);

                            persons.Add(person);
                        }
                    }
                    reader.Close();

                    return persons;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
