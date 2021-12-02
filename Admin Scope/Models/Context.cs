using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin_Scope.Models;

namespace Admin_Scope.Models
{
    public class Context:DbContext
    {
        internal object orderitem;

        public Context(DbContextOptions<Context>options):base(options)
        {

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Admin_Scope.Models.OrderItem> OrderItem { get; set; }
    }
}
