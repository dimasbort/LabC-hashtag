using System.Collections.Generic;
using ServiceLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DBModels.Entities;

namespace ServiceLayer.Services
{
    public class PersonService
    {
        private IUnitOfWork Database { get; set; }

        public PersonService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<Persons> GetListOfEmployees()
        {
            return Database.Persons.GetAll();
        }
    }
}
