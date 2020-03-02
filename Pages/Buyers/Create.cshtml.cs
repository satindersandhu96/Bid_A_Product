using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Buyers
{
    //Adds a  new buyer.
    public class CreateModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public CreateModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Gets the all new buyer form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the Buyer model
        [BindProperty]
        public Buyer Buyer { get; set; }

        //Adds a buyer record to the databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Buyer.Add(Buyer);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}