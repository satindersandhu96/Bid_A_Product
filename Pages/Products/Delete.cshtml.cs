using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bid_A_Product.BusinessLayer;
using Bid_A_Product.Models;

namespace Bid_A_Product.Pages.Products
{

    //Removes a product record from the database.
    public class DeleteModel : PageModel
    {
        //Holds Database context 
        private readonly Bid_A_Product.Models.Bid_A_ProductDatabaseContext _context;

        public DeleteModel(Bid_A_Product.Models.Bid_A_ProductDatabaseContext context)
        {
            _context = context;
        }

        //Binds the product .
        [BindProperty]
        public Product Product { get; set; }

        //Gets the product for deletion using the lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product =  _context.Product.FirstOrDefault(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }


        //Removes the product from the databse. Uses a linq query to get the product.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = (from product in _context.Product
                       where product.Id == id
                       select product).FirstOrDefault();

            if (Product != null)
            {
                _context.Product.Remove(Product);
                 _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
