using System;
using System.Collections.Generic;
using System.Text;
using ComputerDAO;
using ComputerObject;

namespace ComputerBusss
{
    public interface IProductBuss
    {
        Product GetProducts(string MaSP);

        List<Product> GetProducts();
    }
}
