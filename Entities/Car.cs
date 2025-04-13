using System.ComponentModel.DataAnnotations;

namespace CarManagerAPI.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string EngineType { get; set; }
        [Required]
        public int HPamount { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string color { get; set; }
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
		public string[] Features { get; set; }
		public int Owners { get; set; }
        public string? Image { get; set; }
        [Required]
		public string Transmission { get; set; }
	}
}
