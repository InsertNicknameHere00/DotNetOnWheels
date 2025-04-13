using System.ComponentModel.DataAnnotations;

namespace CarManagerAPI.ViewModels.Cars	
{
	public class CarsVM
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string EngineType { get; set; }
		public int HPamount { get; set; }
		public decimal Price { get; set; }
		public string color { get; set; }
		public int Mileage { get; set; }
		public int Year { get; set; }
		public string[] Features { get; set; }
		public int Owners { get; set; }
		public string Image { get; set; }
		public string Transmission { get; set; }
	}
}
