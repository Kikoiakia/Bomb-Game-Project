using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;


namespace StartUp.Data.Models
{
    /// <summary>
    /// Public class for creating new products
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Product()
        {
            
        }

        /// <summary>
        /// Public constructor used to take a product's name, price, how many in stock, expiry date of the product and the store ID it's assigned to.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="stock"></param>
        /// <param name="expiryDate"></param>
        /// <param name="productStoreId"></param>
        public Product(string name, double price, int stock, DateTime expiryDate, int productStoreId)
        {
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.ExpiryDate = expiryDate;
            this.ProductStoreId = productStoreId;
        }
 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

     
        [Range(0, 5000, ErrorMessage = "Price should be greater than or equal to 0 and lower than 5000")]
        public double Price { get; set; }

        
        [Range(0,100, ErrorMessage = "Stock should be greater than or equal to 0 and lower than 100")]
        public int Stock { get; set; }


        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ExpiryDate { get; set; }


        public int ProductStoreId { get; set; }

        public Store Store { get; set; }
    }
}
