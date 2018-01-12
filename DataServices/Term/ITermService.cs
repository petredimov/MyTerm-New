using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ITermService
    {
        Term InsertTerm(Term term);
        void UpdateTerm(Term term);
        void RemoveTerm(int id);
        Term GetTerm(int id);
        List<Term> GetTerms();
    }
}
