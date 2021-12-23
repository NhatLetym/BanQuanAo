using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerObject
{
    [Table("SanPham")]
    public partial class Product
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string Maloai { get; set; }
        public string DonVi { get; set; }
        public string Mota { get; set; }
        public string Anh { get; set; }
        public string AnhTo { get; set; }
        public double GiaBan { get; set; }
        public int Soluong { get; set; }
        public Product(string masp, string tensp, string maloai, string donvi, string mota, string anh, string anhto, double giaban, int soluong)
        {
            this.MaSP = masp;
            this.TenSP = tensp;
            this.Maloai = maloai;
            this.DonVi = donvi;
            this.Mota = mota;
            this.Anh = anh;
            this.AnhTo = anhto;
            this.GiaBan = giaban;
            this.Soluong = soluong;
        }

        public Product()
        {
        }
    }
    //using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations.Schema;
    //using System.ComponentModel.DataAnnotations;

    //[Table ("SanPham")]
    //public class Product
    //{
    //    //public string MaSP { get; set; }


    //    //public Product()
    //    //{
    //    //    //GiamGias = new HashSet<Discount>();
    //    //}

    //    [Key]
    //    [StringLength(50)]
    //    public string MaSP { get; set; }

    //    [StringLength(100)]
    //    public string TenSP { get; set; }

    //    [StringLength(50)]
    //    public string MaLoai { get; set; }

    //    [StringLength(50)]
    //    public string Donvi { get; set; }

    //    [StringLength(500)]
    //    public string MoTa { get; set; }

    //    [StringLength(100)]
    //    public string Anh { get; set; }


    //    public int SoLuong { get; set; }

    //    [StringLength(100)]
    //    public string AnhTo { get; set; }

    //    public Product(string masp, string tensp, string maloai, string donvi, string mota, string anh, int soluong, string anhto)
    //    {
    //        this.MaSP = masp;
    //        this.TenSP = tensp;
    //        this.MaLoai = maloai;
    //        this.Donvi = donvi;
    //        this.MoTa = mota;
    //        this.Anh = anh;
    //        this.SoLuong = soluong;
    //        this.AnhTo = anhto;
    //    }
    //}
}
