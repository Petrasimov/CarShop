using CarStore.Data.Interfaces;
using DatabaseService.Models;

namespace CarStore.Data.Mocks
{
    public class MockCars : IAllCars
    {
        public IEnumerable<Car> Cars => new List<Car> {
            new Car
            {
                Name = "Audi A4",
                ShortDescription = "Краткое описание",
                LongDescription = "Полное описание",
                Img = "/img/cars/a4.jpg",
                Price = 10000,
                IsFavourite = true,
                Available = true,
                CategoryId = 1,
            },
            new Car
            {
                Name = "Ford Fiesta",
                ShortDescription = "Краткое описание",
                LongDescription = "Полное описание",
                Img = "/img/cars/fiesta.jpg",
                Price = 8000,
                IsFavourite = true,
                Available = true,
                CategoryId = 1,
            },
            new Car
            {
                Name = "Super car",
                ShortDescription = "Краткое описание",
                LongDescription = "Полное описание",
                Img = "/img/cars/i.webp",
                Price = 10000,
                IsFavourite = true,
                Available = true,
                CategoryId = 2,
            },
            new Car
            {
                Name = "Mercedes SLS",
                ShortDescription = "Краткое описание",
                LongDescription = "Полное описание",
                Img = "/img/cars/mers.jpg",
                Price = 10000,
                IsFavourite = true,
                Available = true,
                CategoryId = 1,
            },
            new Car
            {
                Name = "Tesla 3",
                ShortDescription = "Краткое описание",
                LongDescription = "Полное описание",
                Img = "/img/cars/tesla.jpg",
                Price = 10000,
                IsFavourite = true,
                Available = true,
                CategoryId = 2,
            },
            new Car
            {
                Name = "Toyota Electra",
                ShortDescription = "Краткое описание",
                LongDescription = "Полное описание",
                Img = "/img/cars/toyota.jpg",
                Price = 10000,
                IsFavourite = true,
                Available = true,
                CategoryId = 2,
            },
        };

        public IEnumerable<Car> GetFavCars => Cars.Where(c=>c.IsFavourite==true);

        public Car? GetOneCar(int carId)
        {
            return Cars.Where(c=>c.CarId == carId).FirstOrDefault();
        }
    }
}
