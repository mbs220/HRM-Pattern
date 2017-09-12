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
        /// <summary>
        /// شناسه حکم قبلی
        /// </summary>
        public int LastRecInterdictId { get; set; }
        /// <summary>
        /// آیتم های کارکردی حکم قبلی
        /// </summary>
        public List<OutputFactorItem> Outputs { get; set; }
        /// <summary>
        /// آیتم های حقوقی حکم قبل
        /// </summary>
        public List<WageFactorItem> Wages { get; set; }

    }
}
