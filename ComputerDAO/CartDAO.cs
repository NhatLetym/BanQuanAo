using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ComputerObject;

namespace ComputerDAO
{
    public class CartDAO
    {
        DataHelper dh = new DataHelper();
        public List<Cart> GetCarts()
        {
            DataTable dt = dh.GetDataTable("Select*from Cart");
            return ToList(dt);
        }

        private List<Cart> ToList(DataTable dt)
        {
            throw new NotImplementedException();
        }
    }
}
