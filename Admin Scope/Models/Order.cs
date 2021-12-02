using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Scope.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }


        public string Name { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
