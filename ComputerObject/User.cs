using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace ComputerObject
{
    [Table("NguoiDung")]
    public partial class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User(string id, string username, string password)
        {
            this.UserID = id;
            this.UserName = username;
            this.Password = password;

        }
    }
}
