using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BindingRoute.Data
{
    [Table("tblCategory")]

    public class Category
    {
        [Required]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string category { get; set; }
    }
}
