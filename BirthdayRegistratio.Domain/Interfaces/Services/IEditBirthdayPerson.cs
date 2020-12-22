using BirthdayRegistration.Domain.Entities;
using System;

namespace BirthdayRegistration.Domain.Interfaces.Services
{
    public interface IEditBirthdayPerson
    {
        void EditPerson(BirthdayPerson birthdayPerson, Guid id);
    }
}
