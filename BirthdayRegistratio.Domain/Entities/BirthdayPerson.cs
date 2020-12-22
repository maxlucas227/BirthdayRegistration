using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayRegistration.Domain.Entities
{
    public class BirthdayPerson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
