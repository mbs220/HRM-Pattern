using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;

namespace MBS.HR.Patterns.BusinessLayer
{
    [Serializable]
    sealed class DefaultImplementation : PerOrganSettingFactory
    {

        
        public DefaultImplementation(IssueInitialModel init) 
            : base(Enums.Organ.Shared, init)
        {
            
        }
        
    }
}
