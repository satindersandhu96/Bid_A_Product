using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Bids
{
    //Returns all bids 
    public class IndexModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public IndexModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Holds all the bids .
        public IList<Bid> Bid { get;set; }

        //Returns all the bids including relationships using a lamda query.
        public void OnGet()
        {
            Bid =  _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller).ToList();
        }
    }
}
