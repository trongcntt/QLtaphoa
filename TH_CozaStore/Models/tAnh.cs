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
    
    public partial class tAnh
    {
        public string MaSP { get; set; }
        public string TenFileAnh { get; set; }
        public Nullable<short> ViTri { get; set; }
    
        public virtual tSanPham tSanPham { get; set; }
    }
}
