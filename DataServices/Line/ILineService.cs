using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public interface ILineService
    {
        Line InsertLine(Line line);
        void UpdateLine(Line line);
        void RemoveLine(int id);
        Line GetLine(int id);
        List<Line> GetLine();
    }
}
