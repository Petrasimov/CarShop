using DatabaseService.Models;

namespace CarStore.Data.Interfaces
{
    public interface IAllCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
