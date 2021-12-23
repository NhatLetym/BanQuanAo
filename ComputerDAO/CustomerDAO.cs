using System;
using System.Collections.Generic;
using System.Text;
using ComputerObject;
using System.Data;

namespace ComputerDAO
{
    public class CustomerDAO
    {
        public Customer GetCustomer(string username, string pass)
        {
            DataHelper dh = new DataHelper();
            string sql = "Select *from KhachHang where(UserName='" + username + "') and(PassWord='" + pass + "')";
            DataTable dt = dh.GetDataTable(sql);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                Customer cs = new Customer(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString());
                return cs;
            }
        }
    }
}
