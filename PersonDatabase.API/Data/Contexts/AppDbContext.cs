using Microsoft.EntityFrameworkCore;
using PersonDatabase.API.Models;

namespace PersonDatabase.API.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>().ToTable("Persons");
            builder.Entity<Person>().HasKey(p => p.Id);
            builder.Entity<Person>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Person>().Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            builder.Entity<Person>().HasMany(p => p.Addresses).WithOne(p => p.Person).HasForeignKey(p => p.PersonId);

            builder.Entity<Address>().ToTable("Addresses");
            builder.Entity<Address>().HasKey(a => a.Id);
            builder.Entity<Address>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Address>().Property(a => a.City).IsRequired().HasMaxLength(50);

            builder.Entity<Person>().HasData(new Person { Id = 100, FirstName = "Jack" }, new Person { Id = 101, FirstName = "Michelle" });
            builder.Entity<Address>().HasData(new Address { Id = 100, City = "Dublin", PersonId = 100 }, new Address { Id = 101, City = "Cork", PersonId = 100 });
        }
    }
}