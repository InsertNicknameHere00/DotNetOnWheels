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
        public string Name { get; set; }
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
        public int mileage { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public List<string> features { get; set; }
        public int owners { get; set; }
        public string image { get; set; }
    }
}
