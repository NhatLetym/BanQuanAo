using System;
using System.Collections.Generic;
using System.Text;
using ComputerObject;
using System.Data;


namespace ComputerDAO
{
     
    public partial class CategoryDAO
    {
        DataHelper dh = new DataHelper();
        public List<LoaiSP> GetCategory()
        {
            DataTable dt = dh.GetDataTable("Select * from LoaiSanPham");
            return ToList(dt);
        }
        public List<LoaiSP> GetLoaiSP()
        {
            DataTable dt = dh.GetDataTable("Select * from LoaiSanPham");
            List<LoaiSP> L = new List<LoaiSP>();
            foreach (DataRow r in dt.Rows)
            {
                LoaiSP fd = new LoaiSP(r[0].ToString(), r[1].ToString());
                L.Add(fd);
            }
            return L;
        }
        public List<LoaiSP> ToList(DataTable dt)
        {
            List<LoaiSP> ll = new List<LoaiSP>();
            foreach (DataRow dr in dt.Rows)
            {
                LoaiSP l = new LoaiSP(dr[0].ToString(), dr[1].ToString());
                ll.Add(l);

            }
            return ll;
        }
    }  

}
