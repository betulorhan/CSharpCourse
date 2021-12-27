using RecaptProject1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecaptProject1
{
    public class NorthwindContext : DbContext
    {        
        public DbSet<Product> Products { get; set; } // Veritabanındaki Products tablosu nesne olan Product ile eşleiştirildi.
        public DbSet<Category> Categories { get; set; } // Category sınıfındaki nesneleri contexte çektik.
    }
}
