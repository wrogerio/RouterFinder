using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RouterFinder.Domain.Entities;
using System;

namespace RouterFinder.Infra.EntityConfig
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            // Primary Key
            builder.HasKey(r => r.Id);

            // Properties
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.routeFrom).IsRequired().HasMaxLength(100);
            builder.Property(r => r.routeTo).IsRequired().HasMaxLength(100);
            builder.Property(r => r.routeValue).IsRequired().HasDefaultValue(0);
            builder.Property(r => r.routeDescription).HasMaxLength(150);

            builder.HasData(new Route { Id = Guid.NewGuid(), routeFrom = "GRU", routeTo = "BRC", routeValue = 10, routeDescription = "GRU -> BRC" });
            builder.HasData(new Route { Id = Guid.NewGuid(), routeFrom = "GRU", routeTo = "CDG", routeValue = 75, routeDescription = "GRU -> CDG" });
            builder.HasData(new Route { Id = Guid.NewGuid(), routeFrom = "GRU", routeTo = "SCL", routeValue = 20, routeDescription = "GRU -> SCL" });
            builder.HasData(new Route { Id = Guid.NewGuid(), routeFrom = "GRU", routeTo = "ORL", routeValue = 56, routeDescription = "GRU -> ORL" });
            builder.HasData(new Route { Id = Guid.NewGuid(), routeFrom = "BRC", routeTo = "SCL", routeValue = 5, routeDescription = "BRC -> SCL" });
            builder.HasData(new Route { Id = Guid.NewGuid(), routeFrom = "ORL", routeTo = "CDG", routeValue = 5, routeDescription = "ORL -> CDG" });
            builder.HasData(new Route { Id = Guid.NewGuid(), routeFrom = "SCL", routeTo = "ORL", routeValue = 20, routeDescription = "SCL -> ORL" });
        }
    }
}