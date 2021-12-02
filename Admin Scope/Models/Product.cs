using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Scope.Models
{
    public class Product
    {
        [Key]
        public int Prod_Id { get; set; }
        [Required(ErrorMessage ="this field is required")]
        public string Prod_Name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public decimal Price { get; set; }

      
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
