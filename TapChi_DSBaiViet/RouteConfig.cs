using DotNetNuke.Web.Mvc.Routing;

namespace TapChi.Modules.TapChi_DSBaiViet
{
    public class RouteConfig : IMvcRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapRoute("TapChi_DSBaiViet", "TapChi_DSBaiViet", "{controller}/{action}", new[]
            {"TapChi.Modules.TapChi_DSBaiViet.Controllers"});
        }
    }
}
