using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Sellers
{
    //Displays all the sellers
    public class IndexModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public IndexModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //All available aellers .
        public IList<Seller> Seller { get;set; }

        //Gets all sellers using a linq  query.
        public  void OnGet()
        {
            Seller = (from seller in _context.Seller select seller).ToList();
        }
    }
}
