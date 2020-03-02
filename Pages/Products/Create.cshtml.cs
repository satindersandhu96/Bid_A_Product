using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Products
{
    //Add  a new product.
    public class CreateModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public CreateModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Gets the product all form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the model product to page.
        [BindProperty]
        public Product Product { get; set; }

        //Adds a product record to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Product.Add(Product);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}