using System;
using System.Linq;
using System.Web;
using ComputerObject;

namespace ComputerObject
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("LoaiSanPham")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public Category(string maloai, string tenloai)
        {
            this.CatId = maloai;
            this.CatName = tenloai;
        }

        [Key]
        [StringLength(50)]
        public string CatId { get; set; }
        [StringLength(100)]
        public string CatName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        //public class Product
        //{
        //    [Key]
        //    [StringLength(50)]
        //    public string CatId { get; set; }
        //    [StringLength(100)]
        //    public string CatName { get; set; }
        //    // GET: Product
        //    //public ActionResult Index()
        //    //{
        //    //    return View();
        //    //}

        //}


    }

}
