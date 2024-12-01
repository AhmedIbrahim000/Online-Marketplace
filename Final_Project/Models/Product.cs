using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Product name")]
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        //[StringLength(200), Display(Name = "Image")]
        //public string ImagePath { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }
        ///
        public Category category { get; set; }

        [Display(Name = "Category name")]
        public int categoryId { get; set; }
    }
}