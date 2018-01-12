using DataContextNamespace;
using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public class LineService : ILineService
    {
        public List<Line> GetLine()
        {
            using (var context = new DataContext())
            {
                return context.Lines.ToList();
            }
        }

        public Line GetLine(int id)
        {
            using (var context = new DataContext())
            {
                return context.Lines.FirstOrDefault(c => c.Id == id);
            }
        }

        public Line InsertLine(Line line)
        {
            using (var context = new DataContext())
            {
                Line newLine = context.Lines.Add(line);
                context.SaveChanges();
                return newLine;
            }
        }

        public void RemoveLine(int id)
        {
            using (var context = new DataContext())
            {
                Line line = context.Lines.FirstOrDefault(c=> c.Id == id);
                if (line != null)
                {
                    context.Lines.Remove(line);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateLine(Line line)
        {
            using (var context = new DataContext())
            {
                context.Entry(line).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
