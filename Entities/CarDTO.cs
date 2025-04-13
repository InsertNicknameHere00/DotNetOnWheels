namespace CarManagerAPI.Entities
{
	public class CarDTO
	{
		public int Id { get; set; }
		public string make { get; set; }
		public string model { get; set; }
		public int year { get; set; }
		public string color { get; set; }
		public int mileage { get; set; }
		public decimal price { get; set; }
		public string fuelType { get; set; }
		public string transmission { get; set; }
		public string engine { get; set; }
		public int horsepower { get; set; }
		public string[] features { get; set; }
		public int owners { get; set; }
		public string image { get; set; }
	}
}
