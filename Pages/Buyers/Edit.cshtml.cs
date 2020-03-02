using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Buyers
{
    //Updates the buyer.
    public class EditModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public EditModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Binds the buyer model
        [BindProperty]
        public Buyer Buyer { get; set; }

        //Gets the buyer details for  update using a lamda query.
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

        //Updates  the buyer record.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Buyer).State = EntityState.Modified;

            try
            {
               _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyerExists(Buyer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks the existance of the buyer record.
        private bool BuyerExists(int id)
        {
            return _context.Buyer.Any(e => e.Id == id);
        }
    }
}
