using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StartUp.Data.Models
{
   /// <summary>
   /// Public class for creating new stores
   /// </summary>
    public class Store
    {
        /// <summary>
        /// Public controller used to make new stores with given name.
        /// </summary>
        /// <param name="name"></param>
        public Store(string name)
        {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
