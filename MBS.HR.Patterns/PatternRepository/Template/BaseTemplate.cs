using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.PatternRepository.AbstractFactory.Interfaces;

namespace MBS.HR.Patterns.PatternRepository.Template
{
    public abstract class BaseTemplate
    {
        public abstract IStep1 ExecuteFirst();
        public abstract IStep2 ExecuteSecond();
        public abstract IStep3 ExecuteThird();

        public void DoStep1()
        {
             // just for test
        }

    }
}
