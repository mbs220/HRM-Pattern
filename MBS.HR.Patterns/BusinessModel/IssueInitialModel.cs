using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.BusinessModel
{
    public class IssueInitialModel
    {
        public IssueInitialModel()
        {
            Console.WriteLine(nameof(IssueInitialModel));
        }

        public int EmployeeId { get; set; }
        public int OrderTypeId { get; set; }
        public DateTime ImpleDate { get; set; }
        public int EmployeeTypeId { get; set; }

        // and ... ordertype, ...
    }
}
