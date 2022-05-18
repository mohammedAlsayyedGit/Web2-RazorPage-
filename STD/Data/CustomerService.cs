using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BindingRoute.Data
{
    public class CustomerService
    {

        private static List<Customer> _db = new List<Customer>()
        {
            new Customer{ Id=1420, Email="ahmed@gtc.edu", Name="Ahmed Ali", Mobile="05997845123"},
            new Customer{ Id=1200, Email="khalid@gtc.edu", Name="khalid radi", Mobile="05997845523"},
            new Customer{ Id=1300, Email="soha@gtc.edu", Name="Soha Madi", Mobile="05997845145"},
            new Customer{ Id=1500, Email="Jalal@gtc.edu", Name="Jalal Amed", Mobile="059978445123"},
        };

        public List<Customer> DB { get { return _db; } }
        public CustomerService()
        {
            
        }


        public async Task<Data.Customer> getCustomer(string email)
        {
            return   _db.Where(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        }

        public async Task<Data.Customer> getCustomer(int Id)
        {
            return _db.Where(c => c.Id==Id).FirstOrDefault();
        }

    }
}
