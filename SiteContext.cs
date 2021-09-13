using Json.Net;
using Microsoft.EntityFrameworkCore;
using MilSiteCore.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MilSiteDataStore.EF
{
	public class SiteContext : DbContext
	{
		public SiteContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Location> Locations { get; set; }
		public DbSet<LocationType> LocationTypes { get; set; }

		public DbSet<Amenitie> Amenities { get; set; }

		public DbSet<Space> Spaces { get; set; }

		public DbSet<Image> Images { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Location>()
				.HasKey(l => l.LocId);
			modelBuilder.Entity<LocationType>()
				.HasKey(l => l.LocTypeId);
			modelBuilder.Entity<Amenitie>()
				.HasKey(s => s.AmID);
			modelBuilder.Entity<Space>()
				.HasMany(p => p.Images)
				.WithOne(s => s.Space)
				.HasForeignKey(s => s.SpaceId);


			//seeding
			modelBuilder.Entity<Location>().HasData(
				new Location { LocId = 1, LocName = "Old River", MaxStay = 365, NumSpaces = 40, DateCreated = DateTime.ParseExact("2021-01-01", "yyyy-MM-dd", null), DateUpdated = DateTime.ParseExact("2021-01-02", "yyyy-MM-dd", null) },
				new Location { LocId = 2, LocName = "Invansic", MaxStay = 36, NumSpaces = 4, DateCreated = DateTime.ParseExact("2021-01-01", "yyyy-MM-dd", null), DateUpdated = DateTime.ParseExact("2021-01-02", "yyyy-MM-dd", null) },
				new Location { LocId = 3, LocName = "Neverland", MaxStay = 20, NumSpaces = 8, DateCreated = DateTime.ParseExact("2021-01-01", "yyyy-MM-dd", null), DateUpdated = DateTime.ParseExact("2021-01-02", "yyyy-MM-dd", null) }
				);
			modelBuilder.Entity<LocationType>()
				.HasData(
				new LocationType { LocTypeId = 1, LocType = "Marina" },
				new LocationType { LocTypeId = 2, LocType = "Campground" },
				new LocationType { LocTypeId = 3, LocType = "Hotel" }
				);
			modelBuilder.Entity<Amenitie>()
				.HasData(
				new Amenitie { AmID = 1, IsFirewood = false, IsResturaunt = true, IsStore = true },
				new Amenitie { AmID = 2, IsFirewood = true, IsResturaunt = false, IsStore = true },
				new Amenitie { AmID = 3, IsFirewood = false, IsResturaunt = true, IsStore = true }
				);
			modelBuilder.Entity<Space>()
				.HasData(
				new Space { SpaceId = 1, SpaceNumber = 1, SpacePhotoId = 1 },
				new Space { SpaceId = 2, SpaceNumber = 2, SpacePhotoId = 2 },
				new Space { SpaceId = 3, SpaceNumber = 3, SpacePhotoId = 3 }
				);
			modelBuilder.Entity<Image>()
				.HasData(
				new Image { ImageId = 1, SpaceId = 1, Photo = "photo1" },
				new Image { ImageId = 2, SpaceId = 1, Photo = "photo2" },
				new Image { ImageId = 3, SpaceId = 2, Photo = "photo3" }

				);
		}
	}
}
