using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComputerObject
{
    [Table("GioHang")]
    public partial class Cart
    {
            //public int OrdID { get; set; }
            public string TenSP { get; set; }
            public string MaSP { get; set; }
            public int SoLuong { get; set; }
            public double GiaBan { get; set; }
            public double ThanhTien { get; set; }
            public Cart(string proid, string proname, int quanity, double price, double totalcost)
            {
                this.TenSP = proname;
                this.MaSP = proid;
                this.SoLuong = quanity;
                this.GiaBan = price;
                this.ThanhTien = totalcost;
            }
            public Cart() { }
    }
}

