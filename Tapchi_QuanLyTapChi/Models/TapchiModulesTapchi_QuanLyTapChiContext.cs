using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tapchi.Modules.Tapchi_QuanLyTapChi.Models
{
    public class TapchiModulesTapchi_QuanLyTapChiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TapchiModulesTapchi_QuanLyTapChiContext() : base("name=TapchiModulesTapchi_QuanLyTapChiContext")
        {
        }

        public System.Data.Entity.DbSet<Tapchi.Modules.TapchiDataModel.Models.ChuDe> ChuDes { get; set; }

        public System.Data.Entity.DbSet<Tapchi.Modules.TapchiDataModel.Models.DanhMuc> DanhMucs { get; set; }
    }
}
