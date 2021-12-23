using System;
using System.Collections.Generic;
using System.Text;
using ComputerObject;
using ComputerDAO;

namespace ComputerBusss
{
    public class CartBuss
    {
        CartDAO pd = new CartDAO();
        public List<Cart> GetCarts()
        {
            return pd.GetCarts();

        }
    }
}
