using BirthdayRegistration.Domain.Entities;
using System.Collections.Generic;

namespace BirthdayRegistration.Domain.Interfaces.Services
{
    public interface IBirthdayService
    {
        int DaysToBirthday(int day, int month);
        IEnumerable<BirthdayPerson> BirthdayToday();
    }
}

