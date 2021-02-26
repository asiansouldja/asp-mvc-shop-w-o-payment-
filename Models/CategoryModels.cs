using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class CategoryModels
    {
        public int Id { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> products{get; set;} //колекціонує product


    }
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name ="Price")]
        public int Price { get; set; }
        [Required]
        [Display(Name="Image")]
        public string img { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name="Category")]
        public string categoryId { get; set; }

        public virtual CategoryModels CategoryModels { get; set; }
    }
    public class ProductImage // для багатьох картинок 1 товару
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // звязує картинки з продуктом по ид
        public string img { get; set; }

    }

    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }


}
