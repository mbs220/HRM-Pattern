using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.PatternRepository.AbstractFactory.Interfaces;

namespace MBS.HR.Patterns.PatternRepository.Proxy
{
    public interface IIssueProxy
    {
        IStep1 ExecuteFirst();
        IStep2 ExecuteSecond();
        IStep3 ExecuteThird();


    }
}
