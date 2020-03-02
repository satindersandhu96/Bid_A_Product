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
    //Delete the Buyer record.
    public class DeleteModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public DeleteModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Binds the buyer model.
        [BindProperty]
        public Buyer Buyer { get; set; }

        //Gets the buyer to be deleted using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buyer = _context.Buyer.FirstOrDefault(m => m.Id == id);

            if (Buyer == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes the buyer record uses a linq query to get the buyer.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Buyer = (from buyer in _context.Buyer

                     where buyer.Id == id
                     select buyer).FirstOrDefault();

            if (Buyer != null)
            {
                _context.Buyer.Remove(Buyer);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
