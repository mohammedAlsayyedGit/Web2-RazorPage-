using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BindingRoute.Data
{
    public enum Level
    { 
        level1, 
        level2,
        level3
    }
    public class Customer
    {

        [Required]
        [Range(1000, int.MaxValue, ErrorMessage = "The Id should have 4 digits or more")]
        [DisplayName("Customer ID")]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The maximum length is 50 characters")]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string Mobile { get; set; }

        [Required]
        [EmailAddress(ErrorMessage="Please enter right email")]
        public string Email { get; set; }

        public Level Level { get; set; } = Level.level1;

        public bool IsActive { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime CreatedOn { get; set; }

        //[Compare(nameof(Password))]


        public Customer()
        {
            Id = 0;
            Name = String.Empty;
            Mobile = String.Empty;
            Email = String.Empty;
            Level = Level.level1;
            IsActive = false;
            CreatedOn = DateTime.Today;
        }

    }
}
