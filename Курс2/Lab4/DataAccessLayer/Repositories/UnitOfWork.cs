using DataAccessLayer.Interfaces;
using DBModels.Entities;

namespace DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private string _connectionString;
        private PersonRepository personRepository;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IRepository<Persons> Persons
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(_connectionString);
                return personRepository;
            }
        }
    }
}
