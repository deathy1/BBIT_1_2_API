using Microsoft.EntityFrameworkCore;

namespace BBIT_2_API.Models.Data
{
    public class DataContext : DbContext
    {
        //might be for relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////entity tables for relations
            //modelBuilder.Entity<Apartment>()
            //    .HasOne<Home>()
            //    .WithMany(x=>x.Apartments)
            //    .HasForeignKey(p => p.HomeId);

            //modelBuilder.Entity<Resident>()
            //        .HasOne<Apartment>()
            //        .WithMany(x => x.Residents)
            //        .HasForeignKey(p => p.ApartmentId);

            //modelBuilder.Entity<Resident>()
            //    .HasOne<Apartment>()
            //    .WithMany(x=>x.Residents)
            //    .HasForeignKey(p => p.ApartmentId);

            //modelBuilder.Entity<Home>()
            //    .HasMany<Apartment>()
            //    .WithOne(x => x.Home)
            //    .HasForeignKey(p => p.HomeId);

        }
        //datacontext is the source of data for the application
        public DataContext(DbContextOptions<DataContext> options) : base(options) //constructor - a method that is called when an object of this class is created
        {           
        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Resident> Residents { get; set; }

    }
}
