//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tHoaDonBan
    {
        public string MaHD { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public Nullable<System.DateTime> NgayBan { get; set; }
        public Nullable<double> TongTien { get; set; }
    
        public virtual tChiTietHoaDon tChiTietHoaDon { get; set; }
        public virtual tKhachHang tKhachHang { get; set; }
        public virtual tNhanVien tNhanVien { get; set; }
    }
}
