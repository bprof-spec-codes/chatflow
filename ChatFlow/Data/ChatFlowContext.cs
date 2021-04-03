using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Data
{
    class ChatFlowContext : DbContext
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
                    UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ChatflowTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
        }
    }
}
