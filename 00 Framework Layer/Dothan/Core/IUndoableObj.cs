
namespace Dothan.Core
{
    public interface IUndoableObj :IBusinessObj
    {
        void CopyState();
        void UndoChanges();
        void AcceptChanges();
    }
}
