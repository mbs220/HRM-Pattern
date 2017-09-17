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

             //_factory.Organ
             //_factory.LogError.LogError
            IFindLastIssueStrategy findLastIssue = new FindLastIssueDefaultStrategy();
            ICheckHasPermissionStrategy checkPermission = new CheckHasPermissionStrategy();

            _factory.FindLastIssue(findLastIssue);
            _factory.HasPermission(checkPermission);
            _factory.CalculateOutputs();
            _factory.CalculateWages();
            _factory.CalculateRecSummary();

            return _factory;
        }
        public  IStep2 ExecuteSecond()
        {
            _factory.InitialValue.EmployeeTypeId = -1000;

            var reason = BusinessModel.Enums.
                CalculationReason.ReCalculateByOtherChanges;

            //اگر اصلا تغییری نداشته نباید مجدد فرخوانی شود
            _factory.CalculateOutputs(reason);
            _factory.CalculateWages(reason);
            _factory.CalculateRecSummary(reason);

            return _factory;
        }
        public  IStep3 ExecuteThird()
        {
            _factory.InitialValue.OrderTypeId = 505;
            //ذخیره در ذیتایبس
            return _factory;
        }
    }
}
