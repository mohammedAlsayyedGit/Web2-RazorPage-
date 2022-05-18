using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BindingRoute.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BindingRoute.Pages.Customer
{
    public class EditAddModel : PageModel
    {
        private Data.CustomerService service;

        public EditAddModel(CustomerService service)
        {
            this.service = service;
        }
        [ViewData]
        public string Title { get; set; }

        [BindProperty]
        public Data.Customer Customer { get; set; }

        public async Task<IActionResult> OnGet(int Id)
        {
            Title = "Edit Customer";
             Customer = await service.getCustomer(Id);
             //ViewData["list"] = new SelectList(_context.Categories, "Id", "category");
            if (Customer == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();
            Data.Customer oldCustomer =await service.getCustomer(Customer.Id);
            if (oldCustomer == null) return Page();
            try
            {
                oldCustomer.Name = Customer.Name;
                oldCustomer.Email = Customer.Email;
                oldCustomer.Mobile = Customer.Mobile;
                oldCustomer.IsActive = Customer.IsActive;
                oldCustomer.Level = Customer.Level;
                oldCustomer.CreatedOn = Customer.CreatedOn;
                //service.DB.Add(Customer);
            }
            catch (Exception er)
            {throw; }
            return RedirectToPage("./Index");
        }

    }
}
