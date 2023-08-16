using Microsoft.EntityFrameworkCore;
using Hospital.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospital.Data
{
    public class MyDBContext:DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options){ }

        public DbSet<Hospitals> hospitals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hospitals>()
                .Property(p => p.department)
                .HasConversion(new EnumToStringConverter<Department>());
        }
    }
}
