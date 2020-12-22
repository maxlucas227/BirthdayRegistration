using BirthdayRegistration.Domain.Entities;
using System.Collections.Generic;

namespace BirthdayRegistration.Domain.Interfaces.Services
{
    public interface ISearchByName  
    {
        IEnumerable<BirthdayPerson> SearchByName(string search);
    }
}
