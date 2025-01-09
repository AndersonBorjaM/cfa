using Domain.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.Database
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Client> Client { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Phone> Phone { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration): base(options)
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ApplicationConnection"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(builder => {

                builder.ToTable("Client");

                builder.HasKey(c => c.ClientId);

                builder.Property(c => c.ClientId);
                builder.Property(c => c.DocumentType).IsRequired();
                builder.Property(c => c.Document).IsRequired();
                builder.Property(c => c.Name).IsRequired();
                builder.Property(c => c.LastName).IsRequired();
                builder.Property(c => c.LastName2);
                builder.Property(c => c.Gender).IsRequired();
                builder.Property(c => c.DateOfBirth).IsRequired();
                builder.Property(c => c.Email).IsRequired();

                builder.HasMany(c => c.Addresses).WithOne(c => c.Client).HasForeignKey(c => c.ClientId).HasPrincipalKey(c => c.ClientId);
                builder.HasMany(c => c.Phones).WithOne(c => c.Client).HasForeignKey(c => c.ClientId).HasPrincipalKey(c => c.ClientId);
            });

            modelBuilder.Entity<Address>(builder => {

                builder.ToTable("Address");

                builder.HasKey(c => c.AddressId);

                builder.Property(c => c.AddressId);
                builder.Property(c => c.ClientId).IsRequired();
                builder.Property(c => c.AddressType).IsRequired();
                builder.Property(c => c.AddressText).IsRequired();
            });

            modelBuilder.Entity<Phone>(builder => {

                builder.ToTable("Phone");

                builder.HasKey(c => c.PhoneId);

                builder.Property(c => c.PhoneId);
                builder.Property(c => c.ClientId).IsRequired();
                builder.Property(c => c.PhoneType).IsRequired();
                builder.Property(c => c.PhoneNumber).IsRequired();
            });


        }

    }
}
