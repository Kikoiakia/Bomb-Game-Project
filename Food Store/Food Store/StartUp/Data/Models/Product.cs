using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace StartUp.Data.Models
{
    public class Product
    {
        


 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

     
        [Range(0, 5000, ErrorMessage = "Price should be greater than 0 or equal to 0 and lower than 5000")]
        public double Price { get; set; }

        
        [Range(0,100, ErrorMessage = "Stock should be greater than 0 or equal to 0 and lower than 100")]
        public int Stock { get; set; }


        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ExpiryDate { get; set; }


        public int ProductStoreId { get; set; }

        public Store Store { get; set; }
    }
}
