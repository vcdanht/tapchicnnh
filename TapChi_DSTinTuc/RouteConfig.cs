using DotNetNuke.Web.Mvc.Routing;

namespace TapChi.Modules.TapChi_DSBaiViet
{
    public class RouteConfig : IMvcRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapRoute("TapChi_DSDanhMuc", "TapChi_DSDanhMuc", "{controller}/{action}", new[]
            {"TapChi.Modules.TapChi_DSDanhMuc.Controllers"});
        }
    }
}
