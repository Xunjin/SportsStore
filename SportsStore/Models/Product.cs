using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    /// <summary>
    /// A Model class which brings 5 properties:
    /// 
    /// <see cref="ProductID"/>: used to identity the unique ID of the Product;
    /// <see cref="Name"/>: Naming of the product itself.
    /// <see cref="Description"/>: More in-depth description of the product may contain some jokes LUL
    /// <see cref="Price"/>: Price of the product
    /// <see cref="Category"/>: Defines a Category which helps bring products using menus or search query inputs.
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,
            ErrorMessage = "Please enter a positive price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

    }
}
