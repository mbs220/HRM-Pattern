using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.PatternRepository.Strategy.Implementations
{
    [Serializable]
    public class DnnLogStrategy : ILoggerStrategy
    {
        public void LogError(Exception ex)
        {
            //dnn log
        }
    }
}
