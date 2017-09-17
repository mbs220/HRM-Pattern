using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.BusinessModel
{
    [Serializable]
    public class GlobalSystemSetting
    {
        public GlobalSystemSetting()
        {
            Console.WriteLine(nameof(GlobalSystemSetting));
        }
    }
}
