using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.PatternRepository.Strategy
{
    public interface ILoggerStrategy
    {
        void LogError(Exception ex);
    }
}
