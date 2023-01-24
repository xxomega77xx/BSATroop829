using BSATroop829.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public DbSet<Models.MeritBadgesViewModel> MeritBadges { get; set; }
        public DbSet<Models.LoggingViewModel> LogEnties { get; set; }
        public DbSet<Models.GirlTroopOrgChartViewModel> GirlTroopOrgChart { get; set; }
        public DbSet<Models.BoyTroopOrgChartViewModel> BoyTroopOrgChart { get; set; }
    }
}