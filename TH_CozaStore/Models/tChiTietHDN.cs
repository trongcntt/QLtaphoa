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
    
    public partial class tChiTietHDN
    {
        public string MaHDN { get; set; }
        public string MaSP { get; set; }
        public Nullable<int> SLNhap { get; set; }
    
        public virtual tHoaDonNhap tHoaDonNhap { get; set; }
        public virtual tSanPham tSanPham { get; set; }
    }
}
