using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace StartUp.Data.Models
{
    public class Product
    { 
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public double Price { get; set; }
    }
}