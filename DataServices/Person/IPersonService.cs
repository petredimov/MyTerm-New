using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface IPersonService
    {
        Person InsertPerson(Person Person);
        void UpdatePerson(Person Person);
        void RemovePerson(int id);
        Person GetPerson(int id);
        List<Person> GetPerson();
    }
}
