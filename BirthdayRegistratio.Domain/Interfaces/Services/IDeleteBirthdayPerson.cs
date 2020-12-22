using System;

namespace BirthdayRegistration.Domain.Interfaces.Services
{
    public interface IDeleteBirthdayPerson
    {
        void DeleteBirthdayPerson(Guid id);
    }
}