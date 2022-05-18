using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BindingRoute.Pages.Category
{
    public class IndexModel : PageModel
    {
        private readonly Data.CategoryService _context;
        public IndexModel(Data.CategoryService context)
        {
            this._context = context;
            ToastData = new Toast();
        }

        [BindProperty]
        public Data.Category Category { get; set; }
        public IList<Data.Category> Categories { get; set; }
       
        public Toast ToastData { get; set; }


        public void OnGet()
        {
            Categories = _context.DB.ToList();

        }

        public async Task<IActionResult> OnPostAdd()
       {

           
            if (!ModelState.IsValid)
            {
                ToastData.isAdd = true;
                ToastData.ShowModel = true;
                Categories = _context.DB.ToList();
                return Page();
            }


            _context.DB.Add(Category);
            Categories = _context.DB.ToList();
            ToastData.Message = $"The Category [{Category.category}] has been added.";
            ToastData.ShowTost = true;
            return Page();
        }

        public async Task<IActionResult> OnPostUpdate()
        {

            if (!ModelState.IsValid)
            {
                ToastData.isAdd = false;
                ToastData.ShowModel = true;
                Categories = _context.DB.ToList();
                return Page();
            }

            Data.Category old = await _context.getCategory((int)Category.Id);
            if(old!=null)
            {
                old.category = Category.category;
            }

            ToastData.Message = $"The Category [{Category.category}] has been updated.";
            ToastData.ShowTost = true;
            Categories = _context.DB.ToList();
            return Page();
        }


        public async Task<IActionResult> OnGetDelete(int? id)
        {
            if (id == null) return NotFound();

            Data.Category old = await _context.getCategory((int)id);

            if (old == null) return NotFound();

            _context.DB.Remove(old);

            ToastData.Message = $"The Category [{old.category}] has been deleted.";
            ToastData.ShowTost = true;

            Categories = _context.DB.ToList();
            return Page();
        }

    }

    public class Toast
    {
        public bool ShowModel { get; set; } = false;
        public bool isAdd { get; set; } = false;

        public bool ShowTost { get; set; } = false;
        public string Message { get; set; } = "";
    }
}
