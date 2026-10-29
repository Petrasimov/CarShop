using DatabaseService.Models;
using System.Collections;

namespace CarStore.Data.Interfaces
{
    public interface IAllCars
    {
        /// <summary>
        /// Возвращает все товары
        /// </summary>
        IEnumerable<Car> Cars { get; }
        /// <summary>
        /// Возвращает только избранные товары
        /// </summary>
        IEnumerable<Car> GetFavCars { get; }
        /// <summary>
        /// Возвращает конкретный товар по идентификатору
        /// </summary>
        /// <param name="carId">Идентификатор товара</param>
        /// <returns></returns>
        Car? GetOneCar(int carId);
    }
}
