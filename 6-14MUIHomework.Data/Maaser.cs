using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_14MUIHomework.Data
{
    public class Maaser
    {
        public int Id { get; set; }
        public string Recipient { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
