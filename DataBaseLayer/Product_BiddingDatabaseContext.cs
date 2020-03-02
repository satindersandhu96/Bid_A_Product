using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bid_A_Product.BusinessLayer;

namespace Bid_A_Product.Models
{
    //Connects the business layer to the databse and handles the CRUD operations.
    public class Bid_A_ProductDatabaseContext : DbContext
    {
        public Bid_A_ProductDatabaseContext (DbContextOptions<Bid_A_ProductDatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Bid_A_Product.BusinessLayer.Bid> Bid { get; set; }

        public DbSet<Bid_A_Product.BusinessLayer.Buyer> Buyer { get; set; }

        public DbSet<Bid_A_Product.BusinessLayer.Product> Product { get; set; }

        public DbSet<Bid_A_Product.BusinessLayer.Seller> Seller { get; set; }
    }
}
