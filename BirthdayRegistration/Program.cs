using BirthdayRegistration.Domain.Entities;
using BirthdayRegistration.Domain.Services;
using BirthdayRegistration.Infrastructure.Repositories;
using System;
using System.IO;

namespace BirthdayRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayPersonService service = new BirthdayPersonService(new BirthdayPersonFileRepository());
            BirthdayService daysLeft = new BirthdayService(new BirthdayPersonFileRepository());
            BirthdayService birthdayToday = new BirthdayService(new BirthdayPersonFileRepository());
            var file = new StreamWriter(@"D:\BirthdayRegistrationFileDb.txt", true);
            file.Close();
            int select = 0;

            do
            {
                Console.WriteLine("Birthdays of the Day " + DateTime.Today);

                foreach (var person in birthdayToday.BirthdayToday())
                    Console.WriteLine(person.Name + " " + person.Surname);

                Console.WriteLine();
                Console.WriteLine("####### ### #######");
                Console.WriteLine("Choose the options you want");
                Console.WriteLine("1 - Register person");
                Console.WriteLine("2 - Edit record");
                Console.WriteLine("3 - Show logs");
                Console.WriteLine("4 - Delete records");
                Console.WriteLine("5 - Search person by name");
                Console.WriteLine("6 - Close");
                Console.WriteLine();
                select = int.Parse(Console.ReadLine());
                BirthdayPerson birthdayPerson;

                switch (select)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Selected - Register person");
                        Console.WriteLine();
                        birthdayPerson = new BirthdayPerson();
                        Console.WriteLine("Enter the person's name");
                        birthdayPerson.Name = Console.ReadLine();
                        Console.WriteLine("Enter the person's last name");
                        birthdayPerson.Surname = Console.ReadLine();
                        Console.WriteLine("Enter the person's date of birth in the dd / MM / yyyy template");
                        birthdayPerson.Birthdate = Convert.ToDateTime(Console.ReadLine());
                        service.RegisterPerson(birthdayPerson);
                        Console.WriteLine("Congratulations you have been registered!");
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Selected - Edit record");
                        Console.WriteLine();
                        birthdayPerson = new BirthdayPerson();
                        Console.WriteLine("Enter the ID of the person you want to edit");
                        birthdayPerson.Id = Guid.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the name you want to edit");
                        birthdayPerson.Name = Console.ReadLine();
                        Console.WriteLine("Enter the last name you want to edit");
                        birthdayPerson.Surname = Console.ReadLine();
                        Console.WriteLine("Enter the new birth date of the person dd / MM / yyyy");
                        birthdayPerson.Birthdate = Convert.ToDateTime(Console.ReadLine());
                        service.EditPerson(birthdayPerson, birthdayPerson.Id);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Selected - Show logs");
                        Console.WriteLine();
                        var persons = service.GetAllPerson();
                        foreach (var onePerson in persons)
                        {
                            Console.WriteLine("Id: " + onePerson.Id);
                            Console.WriteLine("Name or surname: " + onePerson.Name + " " + onePerson.Surname);
                            Console.WriteLine("Date of birth: " + onePerson.Birthdate);
                            Console.WriteLine("Missing " + daysLeft.DaysToBirthday(onePerson.Birthdate.Day, onePerson.Birthdate.Month) + " days for this person's birthday!");
                            Console.WriteLine();
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Selected - Delete record");
                        Console.WriteLine();
                        Console.WriteLine("Enter the ID of the person you want to remove: ");
                        var id = Guid.Parse(Console.ReadLine());
                        service.DeleteBirthdayPerson(id);
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Selected - Search for person by name");
                        Console.WriteLine();
                        Console.WriteLine("Enter the name of the person you want to search: ");
                        var search = Console.ReadLine();
                        var result = service.SearchByName(search);
                        foreach (var onePerson in result)
                        {
                            Console.WriteLine("Id: " + onePerson.Id);
                            Console.WriteLine("Name and surname: " + onePerson.Name + " " + onePerson.Surname);
                            Console.WriteLine("Date of birth: " + onePerson.Birthdate);
                            Console.WriteLine("Missing " + daysLeft.DaysToBirthday(onePerson.Birthdate.Day, onePerson.Birthdate.Month) + " days for this person's birthday!");
                            Console.WriteLine();
                        }
                        break;
                }
            } while (select != 6);
        }
    }
}
