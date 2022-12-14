using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using TH_CozaStore.Models;
using PagedList.Mvc;
using System.Data.Entity;
using System.Web.Security;

namespace TH_CozaStore.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
            
            // GET: Home
            public ActionResult IndexKH(int? page, string loaiSP)
            {
            
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();

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
            public PartialViewResult LoaiSPKH()
            {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            return PartialView(db.tLoaiSP.ToList());
            }
            public ActionResult DetailKH(string maSp)
            {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            return View(db.tSanPham.Where(n => n.MaSP.Equals(maSp)).FirstOrDefault());
            }
        public ActionResult AddCart(string maSP, float giaTien,string anh)
            {
          
           
            if (Session["cart"] != null)
                {
                    List<tChiTietHoaDon> cart = (List<tChiTietHoaDon>)Session["Cart"];
                    var kt = cart.FirstOrDefault(n => n.MaSP == maSP);
                if (kt == null)
                    {
                        tChiTietHoaDon hoadon = new tChiTietHoaDon() { MaSP = maSP, SoLuong = 1,GiaTienSP = giaTien,Anh = anh};

                        cart.Add(hoadon);
                        //Session["Cart"] = cart;
                    }
                    else
                    {
                        kt.SoLuong = kt.SoLuong + 1;

                    }
                    Session["Cart"] = cart;
               
            }
                else
                {
                    List<tChiTietHoaDon> cart = new List<tChiTietHoaDon>();
                    tChiTietHoaDon hoadon = new tChiTietHoaDon() { MaSP = maSP, SoLuong = 1, GiaTienSP = giaTien,Anh = anh};
                    cart.Add(hoadon);
                    Session["Cart"] = cart; 
                 }

                return RedirectToAction("IndexKH");
            }
            public ActionResult ViewCart()
            {
                List<tChiTietHoaDon> ds = (List<tChiTietHoaDon>)Session["Cart"];
                return View(ds);
            }

        public ActionResult DangNhapKH()
        {

            return View();
        }

        [HttpPost]
        public ActionResult DangNhapKH(string user, string password)
        {
            QuanLyTapHoa2Entities2 db = new QuanLyTapHoa2Entities2();
            var tKkhachHang = db.tTKKhachHang.SingleOrDefault(m => m.TenDNKH.ToLower() == user.ToLower() && m.MKKH.ToLower() == password.ToLower());

            //Check code
            if (tKkhachHang != null)
            {
                Session["user"] = tKkhachHang;

                return RedirectToAction("IndexKH");
            }
            else
            {
                TempData["error"] = "Tài khoản đăng nhập sai!";
                return View("DangNhapKH");
            }
        }

        public ActionResult DangXuatKH()
        {
            Session.Remove("user");
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhapKH");
        }

    }
    }
