using DotNetNuke.Web.Mvc.Routing;

namespace TapChi.Modules.TapChi_DSBaiViet
{
    public class RouteConfig : IMvcRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapRoute("TapChi_QuanLyTinTUc", "TapChi_QuanLyTinTUc", "{controller}/{action}", new[]
            {"TapChi.Modules.TapChi_QuanLyTinTUc.Controllers"});
        }
    }
}
