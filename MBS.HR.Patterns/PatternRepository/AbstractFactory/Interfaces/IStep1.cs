using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.Strategy;

namespace MBS.HR.Patterns.PatternRepository.AbstractFactory.Interfaces
{
    /// <summary>
    /// گام 1 - انتخاب حکم
    /// </summary>
    public interface IStep1
    {
        void Init(IssueInitialModel init);
        LastIssueViewModel FindLastIssue(IFindLastIssueStrategy stragety);
        CheckHasPermissionViewModel HasPermission(ICheckHasPermissionStrategy strategy);
        IssueInitialModel InitialValue { get; }
        LastIssueViewModel LastIssue { get; }
        CheckHasPermissionViewModel Permission { get; }
    }
}
