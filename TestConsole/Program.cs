using DataContextNamespace.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            XmlDocument document = new XmlDocument();
            document.Load(@"D:\Code\MyTerm\getodata.xml");

            //document.ChildNodes[0].ChildNodes.


        }
    }
}
