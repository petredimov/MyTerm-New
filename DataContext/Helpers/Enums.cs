using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContextNamespace.Helpers
{
    public enum TermStatus
    {
        NotSet,
        Opened,
        Scheduled,
        Closed
    }
    
    public enum ClientType
    {
        Company = 1,
        Person = 2
    }
}
