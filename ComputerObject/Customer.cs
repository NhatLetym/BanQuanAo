using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerObject
{
    public class Customer
    {
        public string MaKH { get; set; }
        public string TenKH { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Customer(string id, string tenkh, string sdt, string email, string username, string password)
        {
            this.MaKH = id;
            this.TenKH = tenkh;
            this.SDT = sdt;
            this.Email = email;
            this.UserName = username;
            this.Password = password;

        }
        public Customer() { }
    }
}
