using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TH_CozaStore.Models;
namespace TH_CozaStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult IndexAdmin()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("DangNhapAdmin");
            }
            else
            {
                return View();

            }
           
        }

        public ActionResult DangNhapAdmin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DangNhapAdmin(string user, string password)
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            var nhanVien = db.tTkNhanVien.SingleOrDefault(m => m.tenTK.ToLower() == user.ToLower() && m.matKhau.ToLower() == password.ToLower());
                
            //Check code
            if(nhanVien != null)
            {
                Session["user"] = nhanVien;
                
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập sai!";
                return View("DangNhapAdmin");
            }    
        }
        public ActionResult DangXuatAdmin()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhapAdmin");
        }

        public ActionResult QuanLySanPham()
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            List<tSanPham> lstProducts = db.tSanPham.ToList();
            return View(lstProducts);
        }


        public ActionResult QLNV()
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            List<tNhanVien> lstProducts = db.tNhanVien.ToList();
            return View(lstProducts);
        }

        public ActionResult QLHoaDonBan()
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            List<tHoaDonBan> lstProducts = db.tHoaDonBan.ToList();
            return View(lstProducts);
        }

        public ActionResult QLHoaDonNhap()
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            List<tHoaDonNhap> lstProducts = db.tHoaDonNhap.ToList();
            return View(lstProducts);
        }


        public ActionResult QLKhachHang()
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            List<tKhachHang> lstProducts = db.tKhachHang.ToList();
            return View(lstProducts);
        }

        public ActionResult QLTKKhachHang()
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            List<tTKKhachHang> lstProducts = db.tTKKhachHang.ToList();
            return View(lstProducts);
        }



      
        public ActionResult DangNhap()
        {
            return View();
        }
        
        [HttpGet]
        public ViewResult ThemSP()
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();

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
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            ViewBag.MaSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.MaSP), "MaSP", "MaSP");
            ViewBag.TenSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.TenSP), "TenSP", "TenSP");
            ViewBag.GiaBan = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GiaBan), "GiaBan", "GiaBan");
            ViewBag.GiaNhap = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GiaNhap), "GiaNhap", "GiaNhap");
            ViewBag.loaiSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.loaiSP), "loaiSP", "loaiSP");
            ViewBag.MaLoaiSP = new SelectList(db.tLoaiSP.ToList().OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "MaLoaiSP");
            ViewBag.GioiThieu = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GioiThieu), "GioiThieu", "GioiThieu");
            if (ModelState.IsValid)
            {
                db.tSanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sanPham);
        }


        [HttpGet]

        public ActionResult SuaSP(string MaSP)
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            tSanPham sanpham = db.tSanPham.Find(MaSP);
            ViewBag.MaSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.MaSP), "MaSP", "MaSP");
            ViewBag.TenSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.TenSP), "TenSP", "TenSP");
            ViewBag.GiaBan = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GiaBan), "GiaBan", "GiaBan");
            ViewBag.GiaNhap = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GiaNhap), "GiaNhap", "GiaNhap");
            ViewBag.loaiSP = new SelectList(db.tSanPham.ToList().OrderBy(n => n.loaiSP), "loaiSP", "loaiSP");
            ViewBag.MaLoaiSP = new SelectList(db.tLoaiSP.ToList().OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "MaLoaiSP");
            ViewBag.GioiThieu = new SelectList(db.tSanPham.ToList().OrderBy(n => n.GioiThieu), "GioiThieu", "GioiThieu");
            return View(sanpham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult SuaSP(tSanPham sanpham)
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
      
        [HttpGet]

        public ViewResult XoaSP(string MaSP)
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            tSanPham sanpham = db.tSanPham.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
        [HttpPost, ActionName("XoaSP")]
        public ActionResult XacNhanXoa(string MaSP)
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            tSanPham sanpham = db.tSanPham.SingleOrDefault(n => n.MaSP == MaSP);
            var anhsp = from p in db.tAnh
                        where p.MaSP == sanpham.MaSP
                        select p;
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.tAnh.RemoveRange(anhsp);
            db.tSanPham.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}