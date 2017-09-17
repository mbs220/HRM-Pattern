using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.BusinessModel
{
    [Serializable]
    public class OutputFactorItem
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Value { get; set; }
    }
}
