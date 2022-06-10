using System;

namespace RouterFinder.Web.Models
{
    public class Route
    {
        public Guid Id { get; set; }
        public string routeFrom { get; set; }
        public string routeTo { get; set; }
        public double routeValue { get; set; }
    }
}
