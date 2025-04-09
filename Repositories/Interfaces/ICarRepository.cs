using CarManagerAPI.Entities;

namespace CarManagerAPI.Repositories.Interfaces
{
        public interface ICarRepository
        {
            Task<List<Car>> GetAllCarsAsync();
            Task<Car> GetCarByIdAsync(int id);
        Task<Car> GetCarByModelAsync(string model);
        Task<Car> GetCarByEngineTypeAsync(string engine);
        Task<List<Car>> GetCarsByEngineTypeAsync(string engine);
        Task<Car> GetCarByBrandAsync(string brand);
        Task<List<Car>> GetCarsByBrandAsync(string brand);
        Task <Car> AddCarAsync(Car car);
        Task<bool> UpdateCarAsync(int id, Car car);
        Task<bool> DeleteCarAsync(int id);
        }
    }