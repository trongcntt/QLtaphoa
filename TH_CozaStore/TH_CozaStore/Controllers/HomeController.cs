using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TH_CozaStore.Models;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity;

namespace TH_CozaStore.Controllers
{
    public class HomeController : Controller
    {
        QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
        // GET: Home
        public ActionResult Index(int? page, string loaiSP)
        { 
            List<tSanPham> listSp;
            if (loaiSP != null)
            {
                listSp = db.tSanPham.Where(n => n.MaLoai.Equals(loaiSP)).ToList();
                ViewBag.qg = loaiSP;
            }
            else
            {
                listSp = db.tSanPham.ToList();
            }
            int pagesize = 10;
            int pagenumber = (page ?? 1);
            return View(listSp.ToPagedList(pagenumber, pagesize));
        }
        public PartialViewResult LoaiSP()
        {
            return PartialView(db.tLoaiSP.ToList());
        }
        public ActionResult Detail(string maSp)
        {
            return View(db.tSanPham.Where(n => n.MaSP.Equals(maSp)).FirstOrDefault());
        }
        [HttpGet]
        public ViewResult ThemSP()
        {
            ViewBag.MaSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.MaSP), "MaSP", "MaSP");
            ViewBag.TenSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.TenSP), "TenSP", "TenSP");
            ViewBag.GiaBan = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GiaBan), "GiaBan", "GiaBan");
            ViewBag.GiaNhap = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GiaNhap), "GiaNhap", "GiaNhap");
            ViewBag.loaiSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.loaiSP), "loaiSP", "loaiSP");
            ViewBag.MaLoaiSP = new SelectList(db.tLoaiSP.ToList().OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "MaLoaiSP");       
            ViewBag.GioiThieu = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GioiThieu), "GioiThieu", "GioiThieu");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSP(tSanPham sanPham, HttpPostedFileBase fileAnh)
        {

            if (ModelState.IsValid)
            {
                db.tSanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }
        public ActionResult DangNhap()
        {
            return View();
        }
       
    }
}