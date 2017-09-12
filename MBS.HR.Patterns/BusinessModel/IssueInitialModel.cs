using Newtonsoft.Json;
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
        /// <summary>
        /// شناسه استخدامی
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// شناسه نوع حکم
        /// </summary>
        public int OrderTypeId { get; set; }
        /// <summary>
        /// تاریخ اجرای حکم
        /// </summary>
        [JsonProperty]
        public DateTime ImpleDate { get; set; }
        /// <summary>
        /// نوع استخدام
        /// </summary>
        public int EmployeeTypeId { get; set; }
        /// <summary>
        /// تاریخ خاتمه
        /// </summary>
        public DateTime? ExpireDate { get; set; }

        /// <summary>
        /// نوع حکم = اصلاحیه/لغو/عادی
        /// </summary>
        public Enums.IssueType IssueType { get; set; } = Enums.IssueType.Normal;
        // and ... ordertype, ...
    }
}
