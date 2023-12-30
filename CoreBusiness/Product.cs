using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public int? CategoryId  { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public int? Points { get; set; }
       
        public string? Address { get; set; }
       
        public string? City { get; set; }
     
        public string? PostalCode { get; set; }
      
        public string? FirstName { get; set; }
    
        public string? LastName { get; set; }
    
        public string? Phone { get; set; }

        public Category Category { get; set; }
    }
}
