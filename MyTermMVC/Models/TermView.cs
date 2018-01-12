using DataContextNamespace.Helpers;
using DataContextNamespace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTermMVC.Models
{
    public class TermView
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Scheduled { get; set; }
        public TermStatus Status { get; set; }

        public Term ToDbModel()
        {
            return new Term()
            {
                ID = this.ID,
                Description = this.Description,
                Duration = this.Duration,
                Scheduled = this.Scheduled,
                Status = this.Status,
                Title = this.Title
            };
        }
    }
}