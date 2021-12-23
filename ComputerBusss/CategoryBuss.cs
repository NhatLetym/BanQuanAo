using System;
using System.Collections.Generic;
using System.Text;
using ComputerObject;
using ComputerDAO;

namespace ComputerBusss
{
    public class CategoryBuss
    {
        CategoryDAO pd = new CategoryDAO();
        public List<LoaiSP> GetCategory()
        {
            return pd.GetCategory();
        }
        public List<LoaiSP> GetLoaiSP()
        {
            return pd.GetLoaiSP();
        }
    }
}
