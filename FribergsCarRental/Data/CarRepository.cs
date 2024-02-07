using FribergsCarRental.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergsCarRental.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            applicationDbContext.Cars.Add(car);
            await applicationDbContext.SaveChangesAsync();
            return car;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await applicationDbContext.Cars.OrderBy(c => c.CarId).ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int? id)
        {
            var car = await applicationDbContext.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            return car;
        }

        public async Task<Car> EditCarAsync(Car car, int id)
        {
            var existingCar = await applicationDbContext.Cars.FirstOrDefaultAsync(c => c.CarId == id);

            if (existingCar != null)
            {
                existingCar.Brand = car.Brand;
                existingCar.Model = car.Model;
                applicationDbContext.SaveChanges();
                return existingCar;
            }
            return null;
        }

        public async Task DeleteCarAsync(int? id)
        {
            var existingCar = await applicationDbContext.Cars.FirstOrDefaultAsync(c => c.CarId == id);
            if (existingCar != null)
            {
                applicationDbContext.Cars.Remove(existingCar);
                applicationDbContext.SaveChanges();
            }
        }
    }
}
