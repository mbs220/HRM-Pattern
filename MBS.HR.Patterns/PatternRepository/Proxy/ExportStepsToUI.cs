using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;
using MBS.HR.Patterns.PatternRepository.AbstractFactory.Interfaces;
using MBS.HR.Patterns.PatternRepository.Strategy;
using MBS.HR.Patterns.PatternRepository.Strategy.Implementations;

namespace MBS.HR.Patterns.PatternRepository.Proxy
{
    public  class ExportStepsToUI: IIssueProxy
    {
        private readonly PerOrganSettingFactory _factory;
        public ExportStepsToUI(PerOrganSettingFactory factory)
        {
            _factory = factory;
        }
        public  IStep1 ExecuteFirst()
        {
            IFindLastIssueStrategy findLastIssue = new FindLastIssueDefaultStrategy();
            ICheckHasPermissionStrategy checkPermission = new CheckHasPermissionStrategy();

            _factory.FindLastIssue(findLastIssue);
            _factory.HasPermission(checkPermission);

            return _factory;
        }
        public  IStep2 ExecuteSecond()
        {
            return _factory;
        }
        public  IStep3 ExecuteThird()
        {
            return _factory;
        }
    }
}
