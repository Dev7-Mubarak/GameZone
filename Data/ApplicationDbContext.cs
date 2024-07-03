using GameZone.Models;
using GameZone.Models.Eunms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace GameZone.Data
{    
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Comment> Comments { get; set; } = default!;
        public DbSet<Tweet> Tweets { get; set; } = default!;
        public DbSet<Game> Games { get; set; } = default!;
        public DbSet<Device> Devices { get; set; } = default!;
        public DbSet<GameDevice> GameDevices { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Rest> Rests { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;

        //public DbSet<Reservation> Reservations { get; set; } = default!;
        //public DbSet<Transactions> Transactions { get; set; } = default!;
        //public DbSet<Wallet> Wallets { get; set; } = default!;
        //public DbSet<PaymentMethod> paymentMethods { get; set; } = default!;
        //public DbSet<Owner> Owners { get; set; } = default!;
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Reservation>()
            //    .Property(x => x.Satuts)
            //    .HasConversion(
            //        x => (int)x,
            //        x => (ReservationStatus)x 
            //    );

            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("RoleUsers");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

            builder.Entity<Category>()
                .HasData(new Category[]
                {
                     new Category{ Id = 1, Name = "Sports"},
                     new Category{ Id = 2, Name = "Action"},
                     new Category{ Id = 3, Name = "Adventure"},
                     new Category{ Id = 4, Name = "Racing"},
                     new Category{ Id = 5, Name = "Fighting"},
                     new Category{ Id = 6, Name = "Film"},
                });

            builder.Entity<Device>()
                .HasData(new Device[]
                {
                    new Device{ Id = 1, Name = "PlaySation", Icon = "bi bi-playstation"},
                    new Device{ Id = 2, Name = "Xboc", Icon = "bi bi-xbox"},
                    new Device{ Id = 3, Name = "Nitendo", Icon = "bi bi-nintendo-swith"},
                    new Device{ Id = 4, Name = "PC", Icon = "bi bi-pc-dispaly"},
                });

            builder.Entity<GameDevice>()
              .HasKey(x => new { x.GameId, x.DeviceId });

            builder.Entity<RestDivce>()
             .HasKey(x => new { x.RestId, x.DeviceId });

            //builder.Entity<>
            var userId = Guid.NewGuid().ToString();
            var roleAdminId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Owner",
                    NormalizedName = "owner",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });

        }

    }
}