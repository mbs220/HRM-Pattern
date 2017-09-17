using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.BusinessModel
{
    public class Enums
    {
        public enum Organ
        {
            _5391 = 5391,
            _6397 = 6397,
            _191 = 191,
            _6007 = 6007,
            _6440 = 6440,
            _5555 = 5555,
            Shared = 0
        }

        public enum IssueType
        {
            Normal,// عادی
            Cancelation,// لغو
            Corrigendum // اصلاحیه
        }

        public enum IssueDateState
        {
            Postponement, // معوق
            Normal // عادی
        }

        public enum IssueItemType
        {
            Wage,Output
        }

        public enum IssueItemEnterType
        {
            FixValue,UserInput,LastIssue,ByFormula
        }
        public enum CalculationReason
        {
            Stop,/*اصلا اجرا نشود*/
            Init,/*اولین بار اجرا است*/
            ReCalculateByUserInput, /*مجدد محاسبه شود چون آیتم مقدار ورودی داشته*/
            ReCalculateByOtherChanges /*مجدد محاسبه شود چون تغییری در آیتمی دیگر داشته*/
        }
    }
}
