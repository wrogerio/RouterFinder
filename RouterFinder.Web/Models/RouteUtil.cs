using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouterFinder.Web.Models
{
    public static class RouteUtil
    {
        // base url
        private static string baseUrl = "https://localhost:44305";
        
        public static async Task<List<Route>> getRoutes()
        {
            List<Route> routes = new List<Route>();
            var client = new RestClient($"{baseUrl}/api/routerFinder");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            routes = JsonConvert.DeserializeObject<List<Route>>(response.Content);
            return routes.OrderBy(x => x.routeFrom).ToList();
        }
    }
}
