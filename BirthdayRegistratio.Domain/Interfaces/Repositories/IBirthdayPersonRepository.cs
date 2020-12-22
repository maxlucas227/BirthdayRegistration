using BirthdayRegistration.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BirthdayRegistration.Domain.Interfaces.Repositories
{
    public interface IBirthdayPersonRepository
    {
        void Create(BirthdayPerson birthDayperson);
        IEnumerable<BirthdayPerson> ReadAll();
        void Update(BirthdayPerson birthDayperson, Guid id);
        void Delete(Guid id);
    }
}
