using BirthdayRegistration.Domain.Interfaces.Repositories;
using BirthdayRegistration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using BirthdayRegistration.Domain.Interfaces.Services;

namespace BirthdayRegistration.Infrastructure.Repositories
{
    public class BirthdayPersonFileRepository :  IBirthdayPersonRepository
    {
        public void Create(BirthdayPerson person)
        {
            var file = new StreamWriter(@"D:\BirthdayRegistrationFileDb.txt", true);
            file.WriteLine(person.Id + "," + person.Name + "," + person.Surname + "," + person.Birthdate);
            file.Close();
        }
        public void Delete(Guid id)
        {
            var persons = ReadAll();
            List<BirthdayPerson> listNewFile = new List<BirthdayPerson>();

            foreach (var BirthdayPerson in persons)
            {
                if (id != BirthdayPerson.Id)
                    listNewFile.Add(BirthdayPerson);
            }
            File.Delete(@"D:\BirthdayRegistrationFileDb.txt");
            var file = new StreamWriter(@"D:\BirthdayRegistrationFileDb.txt", true);
            file.Close();

            foreach (var person in listNewFile)
            {
                Create(person);
            }
            file.Close();
        }

        public IEnumerable<BirthdayPerson> ReadAll()
        {
            var persons = new List<BirthdayPerson>();
            var file = new StreamReader(@"D:\BirthdayRegistrationFileDb.txt");
            var fileLine = file.ReadLine();

            while (!string.IsNullOrEmpty(fileLine))
            {
                var data = fileLine.Split(',');
                var person = new BirthdayPerson();

                person.Id = Guid.Parse(data[0]);
                person.Name = (data[1]);
                person.Surname = (data[2]);
                person.Birthdate = DateTime.Parse(data[3]);

                persons.Add(person);

                fileLine = file.ReadLine();
            }
            file.Close();

            return persons;
        }
        public void Update(BirthdayPerson birthdayPerson, Guid id)
        {
            Delete(id);
            Create(birthdayPerson);
        }
    }
}
