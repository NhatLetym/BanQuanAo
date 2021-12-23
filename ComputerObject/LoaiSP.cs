using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ComputerObject
{


    [Table("LoaiSanPham")]
    public partial class LoaiSP
    {
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }

        public LoaiSP(string maloai, string tenloai)
        {
            this.MaLoai = maloai;
            this.TenLoai = tenloai;
            
        }
    }

}
