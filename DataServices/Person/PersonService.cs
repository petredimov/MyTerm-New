using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContextNamespace.Models;
using DataContextNamespace;
using System.Data.Entity;

namespace DataServices
{
    public class PersonService : IPersonService
    {
        public List<Person> GetPerson()
        {
            using (var context = new DataContext())
            {
                return context.Persons.ToList();
            }
        }

        public Person GetPerson(int id)
        {
            using (var context = new DataContext())
            {
                return context.Persons.FirstOrDefault(c => c.ID == id);
            }
        }

        public Person InsertPerson(Person person)
        {
            using (var context = new DataContext())
            {
                Person newPerson = context.Persons.Add(person);
                context.SaveChanges();
                return newPerson;
            }
        }

        public void RemovePerson(int id)
        {
            using (var context = new DataContext())
            {
                Person person = context.Persons.FirstOrDefault(c=>c.ID == id);

                if (person != null)
                {
                    context.Persons.Remove(person);
                    context.SaveChanges();
                }
            }
        }

        public void UpdatePerson(Person person)
        {
            using (var context = new DataContext())
            {
                context.Entry(person).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
