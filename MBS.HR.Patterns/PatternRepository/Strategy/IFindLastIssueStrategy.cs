using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;
using MBS.HR.Patterns.PatternRepository.AbstractFactory.Interfaces;

namespace MBS.HR.Patterns.PatternRepository.Strategy
{
    public interface IFindLastIssueStrategy
    {
        LastIssueViewModel FindLastIssue(PerOrganSettingFactory context);

    }
}
