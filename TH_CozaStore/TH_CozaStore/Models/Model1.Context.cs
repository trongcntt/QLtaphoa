﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TH_CozaStore.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyTapHoa2Entities2 : DbContext
    {
        public QuanLyTapHoa2Entities2()
            : base("name=QuanLyTapHoa2Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tAccount> tAccount { get; set; }
        public virtual DbSet<tAnh> tAnh { get; set; }
        public virtual DbSet<tCaLam> tCaLam { get; set; }
        public virtual DbSet<tChiTietHDN> tChiTietHDN { get; set; }
        public virtual DbSet<tChiTietHoaDon> tChiTietHoaDon { get; set; }
        public virtual DbSet<tChucNang> tChucNang { get; set; }
        public virtual DbSet<tHoaDonBan> tHoaDonBan { get; set; }
        public virtual DbSet<tHoaDonNhap> tHoaDonNhap { get; set; }
        public virtual DbSet<tKhachHang> tKhachHang { get; set; }
        public virtual DbSet<tLoaiSP> tLoaiSP { get; set; }
        public virtual DbSet<tNhaCungCap> tNhaCungCap { get; set; }
        public virtual DbSet<tNhanVien> tNhanVien { get; set; }
        public virtual DbSet<TongLuong> TongLuong { get; set; }
        public virtual DbSet<tSanPham> tSanPham { get; set; }
        public virtual DbSet<tTKKhachHang> tTKKhachHang { get; set; }
        public virtual DbSet<tTkNhanVien> tTkNhanVien { get; set; }
    }
}
