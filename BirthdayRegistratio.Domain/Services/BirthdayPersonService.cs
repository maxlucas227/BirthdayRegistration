using BirthdayRegistration.Domain.Entities;
using BirthdayRegistration.Domain.Interfaces.Repositories;
using BirthdayRegistration.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayRegistration.Domain.Services
{
    public class BirthdayPersonService : IRegisterBirthdayPerson
    {
        private readonly IBirthdayPersonRepository _repository;

        public BirthdayPersonService(IBirthdayPersonRepository repository)
        {
            this._repository = repository;
        }

        public void RegisterPerson(BirthdayPerson birthDayperson)
        {
            if (birthDayperson.Name == "")
                return;

            birthDayperson.Id = Guid.NewGuid();
            _repository.Create(birthDayperson);
        }
        public void EditPerson(BirthdayPerson person, Guid id)
        {
            _repository.Update(person, id);
        }
        public IEnumerable<BirthdayPerson> GetAllPerson()
        {
            return _repository.ReadAll();
        }
        public void DeleteBirthdayPerson(Guid id)
        {
            _repository.Delete(id);
        }
        public IEnumerable<BirthdayPerson> SearchByName(string search)
        {
            return _repository.ReadAll()
                .Where(person => person.Name.ToLower().Contains(search.ToLower()) || person.Surname.ToLower().Contains(search.ToLower()));
        }
    }
}
