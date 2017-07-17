using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;

namespace MBS.HR.Patterns.BusinessLayer
{
    class BusImplementation : PerOrganSettingFactory
    {
       

        public BusImplementation(Enums.Organ org, IssueInitialModel init) : base(org, init)
        {
        }
    }
}
