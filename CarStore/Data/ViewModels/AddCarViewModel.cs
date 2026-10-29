using DatabaseService.Models;

namespace CarStore.Data.ViewModels
{
    public class AddCarViewModel
    {
        public Car? Car { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
