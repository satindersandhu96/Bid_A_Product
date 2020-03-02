using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Products
{
    //Gets all the products.
    public class IndexModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public IndexModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Holds all products.
        public IList<Product> Product { get;set; }

        //Return all the product records using a linq query.
        public void  OnGetAsync()
        {
            Product = (from product in _context.Product select product).ToList();
        }
    }
}
