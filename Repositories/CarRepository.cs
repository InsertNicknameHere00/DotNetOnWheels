using CarManagerAPI.Data;
using CarManagerAPI.Entities;
using CarManagerAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace CarManagerAPI.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDbContext _context;

        public CarRepository(CarDbContext context)
        {
            _context = context;
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            var tempCar = await _context.Cars.FindAsync(car.Id);
            if (tempCar == null)
            {
                Car newcar = new Car();
                newcar.Name = car.Name;
                newcar.Model = car.Model;
                newcar.Brand = car.Brand;
                newcar.Price = car.Price;
                newcar.HPamount = car.HPamount;
                newcar.EngineType = car.EngineType;
                _context.Cars.Add(newcar);
                await _context.SaveChangesAsync();
                return newcar;
            }
            return null;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            var cartemp = await _context.Cars.ToListAsync();
            return cartemp;
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            var cartemp = await _context.Cars.FindAsync(id);
            if (cartemp != null)
            {
                cartemp.Name = car.Name;
                cartemp.Model = car.Model;
                cartemp.Brand = car.Brand;
                cartemp.Price = car.Price;
                cartemp.EngineType = car.EngineType;
                cartemp.HPamount = car.HPamount;
                cartemp.features = car.features;
                cartemp.color = car.color;
                cartemp.mileage = car.mileage;
                cartemp.owners = car.owners;
                cartemp.year = car.year;
                cartemp.image = car.image;

                _context.Cars.Update(cartemp);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            var cartemp = await _context.Cars.FindAsync(id);
            if (cartemp != null)
            {
                return cartemp;
            }
            return null;
        }

        public async Task<Car> GetCarByBrandAsync(string brand)
        {
            var cartemp = await _context.Cars.FindAsync(brand);
            return cartemp;
        }

        public async Task<Car> GetCarByEngineTypeAsync(string engine)
        {
            var cartemp = await _context.Cars.FindAsync(engine);
            if (cartemp != null)
            {
                return cartemp;
            }
            return null;
        }

        public async Task<List<Car>> GetCarsByBrandAsync(string brand)
        {
            var cartemp = await _context.Cars/*.Where(x=>x.Brand == brand)*/.ToListAsync();
            if (cartemp != null)
            {
                List<Car> filteredCars = new List<Car>();
                foreach (var car in cartemp)
                {
                    if (car.Brand == brand)
                    {
                        filteredCars.Add(car);
                    }
                }
                return filteredCars;
            }
            return null;
        }

        public async Task<List<Car>> GetCarsByEngineTypeAsync(string engine) {
            var cartemp = await _context.Cars.ToListAsync();
            if (cartemp != null)
            {
                List<Car> filteredCars = new List<Car>();
                foreach (var car in cartemp)
                {
                    if (car.EngineType == engine)
                    {
                        filteredCars.Add(car);
                    }
                }
                return filteredCars;
            }
            return null;
        }

        public async Task<Car> GetCarByModelAsync(string model)
        {
            var cartemp = await _context.Cars.FindAsync(model);
            if (cartemp != null)
            {
                return cartemp;
            }
            return null;
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var cartemp = await _context.Cars.FindAsync(id);
            if (cartemp != null)
            {
                _context.Cars.Remove(cartemp);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<string> CompareCarsHP(int firstcarID, int secondcarID) {
        var cartemp1= await _context.Cars.FindAsync(firstcarID);
            var cartemp2= await _context.Cars.FindAsync(secondcarID);
            if (cartemp1 != null && cartemp2 != null) {
                if (cartemp1.HPamount > cartemp2.HPamount) {
                    return cartemp1.Model + " has more horsepower than " + cartemp2.Model;
                }
                else
                {
                    return cartemp2.Model + " has more horsepower than " + cartemp1.Model;
                }
            }
            return "failed";
        }

        public async Task<string> CompareCarsPrice(int firstcarID, int secondcarID)
        {
            var cartemp1 = await _context.Cars.FindAsync(firstcarID);
            var cartemp2 = await _context.Cars.FindAsync(secondcarID);
            if (cartemp1 != null && cartemp2 != null)
            {
                if (cartemp1.Price > cartemp2.Price)
                {
                    return cartemp1.Model + " costs more than " + cartemp2.Model;
                }
                else
                {
                    return cartemp2.Model + " costs more than " + cartemp1.Model;
                }
            }
            return "failed";
        }

        public async Task<List<Car>> FetchDummyData() {

            string url = "https://freetestapi.com/api/v1/cars";

            using HttpClient client = new HttpClient();

            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var carsTemp = JsonSerializer.Deserialize<List<Car>>(json);
                 await _context.AddAsync(carsTemp);
                _context.SaveChanges();
                return await GetAllCarsAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            return await GetAllCarsAsync();
        }

    }
}
