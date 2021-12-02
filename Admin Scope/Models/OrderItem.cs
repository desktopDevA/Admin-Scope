using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Scope.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItem_Id { get; set; }

        [ForeignKey("Order")]
        public int Order_Id { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public decimal Price { get; set; }

        [ForeignKey("Product")]
        public int Prod_Id { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }


    }
}
