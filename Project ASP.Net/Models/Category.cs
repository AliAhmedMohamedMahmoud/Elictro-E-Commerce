﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Project_ASP.Net.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Cat_Id { get; set; }
        [Required(ErrorMessage ="Category Name Is Requierd")]
        //[MinLength(length:3)]
        //[MaxLength(length:30)]
        [Range(minimum:5, maximum:30,ErrorMessage ="Category Name Must Between 5,30")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description Is Requierd")]
        [Range(maximum:20,minimum:100,ErrorMessage ="Description Must Between 20 ,100")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Picture Is Requierd")]
        [RegularExpression(pattern:@"\w+\.(jpg|png|jpeg)",ErrorMessage = "Picture Must End Path (.jpg,.png,.jpeg)")]
        public string picture { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}