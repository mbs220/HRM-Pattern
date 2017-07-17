using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;

namespace MBS.HR.Patterns.PatternRepository.Strategy.Implementations
{
    class CheckHasPermissionStrategy: ICheckHasPermissionStrategy
    {
        /// <summary>
        /// استراتژی بررسی دسترسی صدور حکم
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public CheckHasPermissionViewModel CheckPermission(PerOrganSettingFactory context)
        {
            Console.WriteLine(nameof(CheckPermission));
            return new CheckHasPermissionViewModel { HasPermission = true };
        }
    }
}
