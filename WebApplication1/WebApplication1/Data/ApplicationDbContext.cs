using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListFriend>()
                .HasKey(c => new { c.idUser, c.idFriend});
        }

        public DbSet<Gender> Gender { get; set; }
        public DbSet<ImagePost> ImagePost { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<TypeOfNotification> TypeOfNotifications { get; set; }
        public DbSet<TypeOfPost> TypeOfPost { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ListFriend> ListFriend { get; set; }
        public DbSet<Notification> Notification { get; set; }


    }
}
