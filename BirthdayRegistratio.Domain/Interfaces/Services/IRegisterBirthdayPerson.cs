using BirthdayRegistration.Domain.Entities;

namespace BirthdayRegistration.Domain.Interfaces.Services
{
    public interface IRegisterBirthdayPerson
    {
        void RegisterPerson(BirthdayPerson person);
    }
}
