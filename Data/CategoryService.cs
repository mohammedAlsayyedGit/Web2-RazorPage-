using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindingRoute.Data
{
    public class CategoryService
    {

        private static List<Category> _db = new List<Category>()
        {
            new Category{ Id=1, category= "Cleaner"},
            new Category{ Id=2,category= "Car"},
            new Category{ Id=3, category="Food"},

        };

        public List<Category> DB { get { return _db; } }
        public CategoryService()
        {
            
        }


        public async Task<Data.Category> getCategory(string category)
        {
            return   _db.Where(c => c.category.Equals(category, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public async Task<Data.Category> getCategory(int Id)
        {
            return _db.Where(c => c.Id==Id).FirstOrDefault();
        }

    }
}
