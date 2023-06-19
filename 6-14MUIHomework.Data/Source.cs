using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_14MUIHomework.Data
{
    public class Source
    {
        public int Id { get; set; }
        public string SourceName { get; set; }

        public List<Income> Incomes { get; set; }
    }
}
