using CarStore.Data.Interfaces;
using DatabaseService.Models;

namespace CarStore.Data.Mocks
{
    public class MockCategory : IAllCategory
    {
        public IEnumerable<Category> AllCategories => new List<Category>
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "Классические",
                Description = "Автомобили с ДВС"
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Электро",
                Description = "Автомобили электрическим двигателем"
            }
        };
    }
}
