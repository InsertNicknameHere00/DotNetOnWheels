namespace CarManagerAPI.ViewModels.Cars	
{
	using CarManagerAPI.Entities;
	using System.ComponentModel.DataAnnotations;

	public class IndexVM
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public string EngineType { get; set; }
		public int HPamount { get; set; }
		public decimal Price { get; set; }
		public string color { get; set; }
		public int mileage { get; set; }
		public int year { get; set; }
	}
}
