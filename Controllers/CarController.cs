using CarManagerAPI.Entities;
using CarManagerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository _repository;
        public CarController(CarRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cartemp = await _repository.GetAllCarsAsync();
            return Ok(cartemp);
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetCarByID([FromQuery] int id)
        {
            var cartemp = await _repository.GetCarByIdAsync(id);
            return Ok(cartemp);
        }

        [HttpGet("GetByModel")]
        public async Task<IActionResult> GetCarByModel([FromQuery] string model)
        {
            var cartemp = await _repository.GetCarByModelAsync(model);
            return Ok(cartemp);
        }

        [HttpGet("GetByBrand")]
        public async Task<IActionResult> GetCarByBrand([FromQuery] string brand)
        {
            var cartemp = await _repository.GetCarByBrandAsync(brand);
            return Ok(cartemp);
        }

        [HttpGet("GetAllByBrand")]
        public async Task<IActionResult> GetCarsByBrand([FromQuery] string brand)
        {
            var cartemp = await _repository.GetCarsByBrandAsync(brand);
            return Ok(cartemp);
        }

        [HttpGet("GetByEngineType")]
        public async Task<IActionResult> GetCarByEngine([FromQuery] string engine)
        {
            var cartemp = await _repository.GetCarByEngineTypeAsync(engine);
            return Ok(cartemp);
        }

        [HttpGet("GetAllByEngineType")]
        public async Task<IActionResult> GetCarSByEngine([FromQuery] string engine)
        {
            var cartemp = await _repository.GetCarsByEngineTypeAsync(engine);
            return Ok(cartemp);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> AddCar([FromBody] Car car)
        {
            var cartemp = await _repository.AddCarAsync(car);
            return Ok(cartemp);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar([FromQuery] int id)
        {
            var cartemp = await _repository.DeleteCarAsync(id);
            return Ok(cartemp);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateCar([FromQuery] int id, [FromBody] Car car)
        {
            var cartemp = await _repository.UpdateCarAsync(id, car);
            return Ok(cartemp);
        }

        [HttpGet("CompareHP")]
        public async Task<IActionResult> CompareCarHP([FromQuery] int id1, [FromQuery] int id2) {
        var cartemp=await _repository.CompareCarsHP(id1, id2);
            return Ok(cartemp);
        }

        [HttpGet("ComparePrice")]
        public async Task<IActionResult> CompareCarPrice([FromQuery] int id1, [FromQuery] int id2)
        {
            var cartemp = await _repository.CompareCarsPrice(id1, id2);
            return Ok(cartemp);
        }
    }
}