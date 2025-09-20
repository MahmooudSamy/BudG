using System.Threading.Tasks;

namespace BudG.UI.Interface
{
    public interface IGenericViewModel
    {
        Task LoadAsync(int? id);
        bool HasChanges { get; set; }
    }
}
