using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using ComputerDAO;
using ComputerObject;

namespace ComputerDAO
{
    public interface IProductDAO
    {
        List<Product> GetProduct();
        Product GetProduct(string MaSP);
    }
    //public GetProductCategory{}
}
