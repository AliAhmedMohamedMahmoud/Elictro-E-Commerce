﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project_ASP.Net.Models
{
    public class Product
    {
        [Key]
        public int Pro_Id { get; set; }
        [Required(ErrorMessage = "Product Name Is Requierd")]
        //[Range(minimum: 5, maximum: 30, ErrorMessage = "Product Name Must Between 5,30")]
        [MinLength(length: 3, ErrorMessage = "Product Name Must More Than 3 char")]
        [MaxLength(30, ErrorMessage = "Product Name Must Less Than 30 char")]
        public string Pro_Name { get; set; }
<<<<<<< HEAD
        [Column(TypeName = "money")]
=======
        //[Required(ErrorMessage = "Product_Brand Is Requierd")]
        //[MinLength(length: 3, ErrorMessage = "Product_Brand Must More Than 3 char")]
        //[MaxLength(30, ErrorMessage = "Product_Brand Must Less Than 30 char")]
        //public string Product_Brand { get; set; }
        [Column(TypeName ="money")]
>>>>>>> 4176297c51c44b60eab138ab6bcedc50be01785b
        [Required(ErrorMessage = "Unit Price Is Requierd & Must be Number")]
        public decimal Unit_Price { get; set; }
        [Required(ErrorMessage = "Description Is Requierd")]
        //[Range(minimum: 20, maximum: 100, ErrorMessage = "Description Must Between 20 ,100")]
        [MinLength(20, ErrorMessage = "Product Name Must More Than 20 char")]
        [MaxLength(100, ErrorMessage = "Product Name Must Less Than 100 char")]
        public string Description { get; set; }
        public int Stock { get; set; }
        [NotMapped]
        public int NumSeller { get; set; }
        [Required(ErrorMessage = "Picture Is Requierd")]
        [RegularExpression(pattern: @"\w+\.(jpg|png|jpeg)", ErrorMessage = "Picture Must End Path (.jpg,.png,.jpeg)")]
        public string image { get; set; }
        [Column(TypeName = "money")]
        public int Discount { get; set; }
        [ForeignKey("Category")]
        public int cat_id { get; set; }

        // nav prop
        public virtual Category Category { get; set; }
        //public virtual List<Order> Orders { get; set; }=new List<Order>();
        public virtual List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    }
}
