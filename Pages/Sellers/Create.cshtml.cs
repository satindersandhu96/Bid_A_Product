using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Sellers
{

    //Creats  a Seller 
    public class CreateModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public CreateModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Gets the  create seller form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the Seller model.
        [BindProperty]
        public Seller Seller { get; set; }

        //Adds  a seller to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seller.Add(Seller);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}