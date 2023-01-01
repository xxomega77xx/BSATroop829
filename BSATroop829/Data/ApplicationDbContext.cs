﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BSATroop829.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Models.SummerCampViewModel> SummerCamp { get; set; }
        public DbSet<Models.TroopEaglesViewModel> TroopEagles { get; set; }
        public DbSet<Models.PhotoGalleryVeiwModel> PhotoGallery { get; set; }
        public DbSet<Models.MeritBadgeCounselorsViewModel> MeritBadgeCounselors { get; set; }
        public DbSet<Models.FileManagerViewModel> FileManager { get; set; }
    }
}