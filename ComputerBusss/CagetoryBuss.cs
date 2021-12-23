using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ComputerObject;
using ComputerDAO;

namespace ComputerBusss
{
    public class CagetoryBuss/*: iCagetoryBuss*/
    {
        //ICagetoryDAO pd = new CategoryDAO();
        //CategoryDAO pds = new CategoryDAO();
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
