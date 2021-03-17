using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestRazorTemplating.Models
{
    public class Spent
    {
        public int spentId { get; set; }
        public string spentName { get; set; }
        public DateTime date { get; set; }
        public double amount { get; set; }

    }
}
