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
    //Gets the Buyer details.
    public class DetailsModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public DetailsModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Holds the buyer model.
        public Buyer Buyer { get; set; }

        //Gets the buyer model using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buyer =  _context.Buyer.FirstOrDefault(m => m.Id == id);

            if (Buyer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
