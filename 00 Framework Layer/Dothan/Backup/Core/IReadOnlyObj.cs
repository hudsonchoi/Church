
namespace Dothan.Core
{
    public interface IReadOnlyObj :IBusinessObj
    {
        bool CanReadProperty(string propertyName);
    }
}
