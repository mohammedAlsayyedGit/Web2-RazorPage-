using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindingRoute.Data
{
    public enum Level {  level1, level2, level3}
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }

        public Level Level { get; set; } = Level.level1;

        public bool IsActive { get; set; }
        public Customer()
        {
            Id = 0;
            Name = String.Empty;
            Mobile = String.Empty;
            Email = String.Empty;
            Level = Level.level1;
            IsActive = false;
        }

    }
}
