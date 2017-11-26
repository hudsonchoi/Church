
namespace Dothan.Core
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming","CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    public interface IEditableCollection : IUndoableObj
    {

        void RemoveChild(Core.BusinessBase child);
    }
}
