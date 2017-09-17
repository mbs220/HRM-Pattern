using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBS.HR.Patterns.BusinessModel
{
    [Serializable]
    public class CheckHasPermissionViewModel
    {
        public CheckHasPermissionViewModel()
        {
            Console.WriteLine(nameof(CheckHasPermissionViewModel));
        }


        public bool HasPermission { get; set; }

    }
}
