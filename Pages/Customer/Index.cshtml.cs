using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BindingRoute.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BindingRoute.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly CustomerService service;

        public IndexModel(Data.CustomerService service)
        {
            this.service = service;
        }

        public List<Data.Customer> list { get; set; }
        public void OnGet()
        {
            list = service.DB;
        }
    }
}
