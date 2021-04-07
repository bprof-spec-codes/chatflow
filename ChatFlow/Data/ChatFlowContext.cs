using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class ChatFlowContext : IdentityDbContext<User>
    {
        // public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Threads> Threads { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public ChatFlowContext(DbContextOptions<ChatFlowContext> opt) : base(opt) 
        {

        }

        public ChatFlowContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    //UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ChatflowTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\ChatFlowTestDB.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Messages>(entity =>
            {
                entity
                .HasOne(message => message.Threads)
                .WithMany(threads => threads.Messages)
                .HasForeignKey(message => message.ThreadID);
                // .OnDelete needed??
            });

            modelBuilder.Entity<Threads>(entity =>
            {
                entity
                .HasOne(threads => threads.Room)
                .WithMany(room => room.Threads)
                .HasForeignKey(threads => threads.RoomID);
            });

            modelBuilder.Entity<RoomUser>(entity =>
            {
                entity
                .HasKey(roomUser => new { roomUser.RoomID, roomUser.UserID });
            });

            modelBuilder.Entity<RoomUser>(entity =>
            {
                entity
                .HasOne(roomUser => roomUser.Room)
                .WithMany(room => room.RoomUsers)
                .HasForeignKey(roomUser => roomUser.RoomID);
            });

            modelBuilder.Entity<RoomUser>(entity =>
            {
                entity
                .HasOne(roomUser => roomUser.User)
                .WithMany(user => user.RoomUsers)
                .HasForeignKey(roomUser => roomUser.UserID);
            });
        }
    }
}
