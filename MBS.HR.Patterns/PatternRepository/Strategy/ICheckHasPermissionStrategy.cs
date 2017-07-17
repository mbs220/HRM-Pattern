using MBS.HR.Patterns.BusinessModel;
using MBS.HR.Patterns.PatternRepository.AbstractFactory;

namespace MBS.HR.Patterns.PatternRepository.Strategy
{
    public interface ICheckHasPermissionStrategy
    {
        CheckHasPermissionViewModel CheckPermission(PerOrganSettingFactory context);
    }
}