using DatabaseService.Models;

namespace CarStore.Data.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Car> Cars { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentCategory { get; set; }
    }
}
