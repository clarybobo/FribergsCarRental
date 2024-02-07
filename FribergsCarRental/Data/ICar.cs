using FribergsCarRental.Data.Models;

namespace FribergsCarRental.Data
{
    public interface ICar
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int? id);
        Task<Car> AddCarAsync(Car car);
        Task<Car> EditCarAsync(Car car, int id);
        Task DeleteCarAsync(int? id);
    }
}
