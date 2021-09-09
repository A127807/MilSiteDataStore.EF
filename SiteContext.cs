using Microsoft.EntityFrameworkCore;
using MilSiteCore.Models;
using System;
using System.Collections.Generic;

namespace MilSiteDataStore.EF
{
	public class SiteContext : DbContext
	{
		public SiteContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Location> Locations { get; set; }
		public DbSet<LocationType> LocationTypes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Location>()
				.HasMany(l => l.LocationsTypes)
				.WithOne(lt => lt.Location)
				.HasForeignKey(lt => lt.LocId);

			//seeding
			modelBuilder.Entity<Location>().HasData(
				new Location { LocId = 1, LocName = "Old River", MaxStay = 365, NumSpaces = 40, DateCreated = DateTime.ParseExact("2021-01-01", "yyyy-MM-dd", null), DateUpdated = DateTime.ParseExact("2021-01-02", "yyyy-MM-dd", null)}, 
				new Location { LocId = 2, LocName = "Invansic", MaxStay = 36, NumSpaces = 4, DateCreated = DateTime.ParseExact("2021-01-01", "yyyy-MM-dd", null), DateUpdated = DateTime.ParseExact("2021-01-02", "yyyy-MM-dd", null) },
				new Location { LocId = 2, LocName = "Neverland", MaxStay = 20, NumSpaces = 8, DateCreated = DateTime.ParseExact("2021-01-01", "yyyy-MM-dd", null), DateUpdated = DateTime.ParseExact("2021-01-02", "yyyy-MM-dd", null) }
				);
			modelBuilder.Entity<LocationType>().HasData(
				new LocationType { LocTypeId = 1, LocId = 1, LocType = "Marina"  },
				new LocationType { LocTypeId = 2, LocId = 2, LocType = "Campground" },
				new LocationType { LocTypeId = 3, LocId = 3, LocType = "Hotel" }
				);
		}
	}
}
