using System;
using System.Collections.Generic;
using System.Text;
using ComputerObject;
using ComputerDAO;

namespace ComputerBusss
{
    public class LoginBuss
    {
        UserDAO ud = new UserDAO();
        CustomerDAO cd = new CustomerDAO();
        public Customer CheckCustomer(string us, string pw)
        {
            return cd.GetCustomer(us, pw);
        }
        public User CheckUser(string manv, string pw)
        {
            return ud.GetUser(manv, pw);
        }
    }
}
