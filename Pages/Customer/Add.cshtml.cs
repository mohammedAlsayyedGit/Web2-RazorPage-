using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BindingRoute.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BindingRoute.Pages.Customer
{
    public class AddModel : PageModel
    {

        private Data.CustomerService service;

        public AddModel(CustomerService service)
        {
            this.service = service;
        }


        [BindProperty]
        public Data.Customer Customer { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            Data.Customer x1 =await service.getCustomer(Customer.Email);

            if (x1 != null || (await service.getCustomer(Customer.Id)!=null))
            {
                ModelState.AddModelError("Email", "This is Exists");
                return Page();

            }

            try
            {
                service.DB.Add(Customer);
            }
            catch(Exception er)
            {
                throw er;
            }

            return RedirectToPage("./Index");

        }
    }
}
