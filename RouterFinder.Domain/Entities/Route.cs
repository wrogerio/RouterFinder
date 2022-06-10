using System;

namespace RouterFinder.Domain.Entities
{
    public class Route
    {
        // set the properties
        public Guid Id { get; set; }
        public string routeFrom { get; set; }
        public string routeTo { get; set; }
        public double routeValue { get; set; }
        public string routeDescription { get; set; }
    }
}