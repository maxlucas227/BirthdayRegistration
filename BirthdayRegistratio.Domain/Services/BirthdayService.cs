using BirthdayRegistration.Domain.Entities;
using BirthdayRegistration.Domain.Interfaces.Repositories;
using BirthdayRegistration.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayRegistration.Domain.Services
{
    public class BirthdayService : IBirthdayService
    {
        private readonly IBirthdayPersonRepository _repository;

        public BirthdayService(IBirthdayPersonRepository repository)
        {
            this._repository = repository;
        }
        public int DaysToBirthday(int day, int month)
        {
            var yearToday = DateTime.Today.Year;
            var nextBirthday = new DateTime(yearToday, month, day);

            var daysToNextBirthday = (int)nextBirthday.Subtract(DateTime.Today).TotalDays;

            if (daysToNextBirthday >= 0)
                return daysToNextBirthday;

            else
                return 365 + daysToNextBirthday;
        }
        public IEnumerable<BirthdayPerson> BirthdayToday()
        
        {
            DateTime today = DateTime.Today;

           return _repository.ReadAll().Where(Birthdayperson => Birthdayperson.Birthdate.Day == today.Day && Birthdayperson.Birthdate.Month == today.Month).ToList();
        }
    }
}
