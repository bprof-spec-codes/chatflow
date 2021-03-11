using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Data
{
    class ChatFlowContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<Messages> Messages { get; set; }

        public ChatFlowContext(DbContextOptions opt) : base(opt) 
        {

        }
        public ChatFlowContext()
        {
            this.Database.EnsureCreated();
        }
    }
}
