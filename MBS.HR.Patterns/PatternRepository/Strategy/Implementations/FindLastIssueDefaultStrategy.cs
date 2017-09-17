using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;

namespace MBS.HR.Patterns.PatternRepository.Strategy.Implementations
{
    [Serializable]
    class FindLastIssueDefaultStrategy : IFindLastIssueStrategy
    {
        //استراتژی پیدا کردن حکم آخر در اینجا پیاده و سفارشی می شود
        public LastIssueViewModel FindLastIssue(PerOrganSettingFactory context)
        {
            Console.WriteLine(nameof(FindLastIssue));
            return new LastIssueViewModel {LastRecInterdictId = 1};

        }
    }
}
