using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Buyers
{
    //Gets all the buyers.
    public class IndexModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public IndexModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Holds all the buyers.
        public IList<Buyer> Buyer { get;set; }

        //Gets all the buyers using a linq query.
        public void OnGet()
        {
            Buyer = (from buyer in _context.Buyer select buyer).ToList();
        }
    }
}
