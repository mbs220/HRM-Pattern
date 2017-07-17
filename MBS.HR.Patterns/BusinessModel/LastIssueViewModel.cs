using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.BusinessModel
{
    public class LastIssueViewModel
    {
        public LastIssueViewModel()
        {
            Console.WriteLine(nameof(LastIssueViewModel));
        }

        public int LastRecInterdictId { get; set; }

    }
}
