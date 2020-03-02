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

    //Removes the Bid record from the database
    public class DeleteModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public DeleteModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Binds the Bid model 
        [BindProperty]
        public Bid Bid { get; set; }

        //Deletes  the bid uses a lamda query to show the bid to user including relationships.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bid =  _context.Bid
                .Include(b => b.Buyer)
                .Include(b => b.Product)
                .Include(b => b.Seller).FirstOrDefault(m => m.Id == id);

            if (Bid == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the bid from the databse. Alinq query is uses to get bit record from databse.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bid = (from bid in _context.Bid

                   where bid.Id == id
                   select bid).FirstOrDefault();

            if (Bid != null)
            {
                _context.Bid.Remove(Bid);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
