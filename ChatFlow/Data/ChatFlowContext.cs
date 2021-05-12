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
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Threads> Threads { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

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
                    UseSqlServer(@"Server = tcp:chatflow.database.windows.net, 1433; Initial Catalog = ChatflowDB; Persist Security Info = False; User ID = chatflowAdmin; Password = Passw0rd.56; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
                    //UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ChatflowTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "e3b75db1-ab66-4847-9d19-3daf24eef74c", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "5610f2d4-92f9-4ad1-b921-a98e5cba7747", Name = "Teacher", NormalizedName = "TEACHER" },
                new { Id = "117f7d38-f42f-4773-b196-fdc275380901", Name = "Student", NormalizedName = "STUDENT" }
                );

            var admin = new User
            {
                Id = "b09ea12e-9e51-419f-826a-cbd38f3664df",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                SecurityStamp = string.Empty,
                FirstName = "Chatflow",
                LastName = "Admin"
            };

            var andris = new User
            {
                Id = "fc5ddfbf-adbb-485b-9198-d5697f670632",
                Email = "kovacs.andras@uni-obuda.hu",
                NormalizedEmail = "KOVACS.ANDRAS@UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "kovacs.andras",
                NormalizedUserName = "KOVACS.ANDRAS",
                SecurityStamp = string.Empty,
                FirstName = "András",
                LastName = "Kovács"
            };

            var miki = new User
            {
                Id = "cd078415-b771-4375-9079-e0d497567e85",
                Email = "sipos.miklos@uni-obuda.hu",
                NormalizedEmail = "SIPOS.MIKLOS@UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "sipos.miklos",
                NormalizedUserName = "SIPOS.MIKLOS",
                SecurityStamp = string.Empty,
                FirstName = "Miklós",
                LastName = "Sipos"
            };

            var boldi = new User
            {
                Id = "70c69d55-28b8-4528-9c27-a4129f12659d",
                Email = "boldibihari@stud.uni-obuda.hu",
                NormalizedEmail = "BOLDIBIHARI@STUD.UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "boldi.bihari",
                NormalizedUserName = "BOLDI.BIHARI",
                SecurityStamp = string.Empty,
                FirstName = "Boldizsár",
                LastName = "Bihari"
            };

            var roli = new User
            {
                Id = "cd6687c1-30fb-4a21-b7d9-005986669286",
                Email = "bogdanroland@stud.uni-obuda.hu",
                NormalizedEmail = "BOGDANROLAND@STUD.UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "bogdan.roland",
                NormalizedUserName = "BOGDAN.ROLAND",
                SecurityStamp = string.Empty,
                FirstName = "Roland",
                LastName = "Bogdán"
            };

            var simon = new User
            {
                Id = "796f78d1-9d03-4e0c-bd88-e22338e01425",
                Email = "buzasi.simon@stud.uni-obuda.hu",
                NormalizedEmail = "BUZASI.SIMON@STUD.UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "buzasi.simon",
                NormalizedUserName = "BUZASI.SIMON",
                SecurityStamp = string.Empty,
                FirstName = "Simon",
                LastName = "Buzási"
            };

            var tomi = new User
            {
                Id = "cf7d31a0-20a7-4676-8e1f-c69d9470dc76",
                Email = "tamas.lengyel@stud.uni-obuda.hu",
                NormalizedEmail = "TAMAS.LENGYEL@STUD.UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "tamas.lengyel",
                NormalizedUserName = "TAMAS.LENGYEL",
                SecurityStamp = string.Empty,
                FirstName = "Tamás",
                LastName = "Lengyel"
            };

            var dariusz = new User
            {
                Id = "523fdb57-cdc3-4f91-bad8-12e80dfef125",
                Email = "dariusz@stud.uni-obuda.hu",
                NormalizedEmail = "DARIUSZ@STUD.UNI-OBUDA.HU",
                EmailConfirmed = true,
                UserName = "dariusz.szabo",
                NormalizedUserName = "DARIUSZ.SZABO",
                SecurityStamp = string.Empty,
                FirstName = "Dáriusz",
                LastName = "Szabó"
            };

            admin.PasswordHash = new PasswordHasher<User>().HashPassword(null, "admin");
            andris.PasswordHash = new PasswordHasher<User>().HashPassword(null, "andras");
            miki.PasswordHash = new PasswordHasher<User>().HashPassword(null, "miklos");
            boldi.PasswordHash = new PasswordHasher<User>().HashPassword(null, "boldi");
            roli.PasswordHash = new PasswordHasher<User>().HashPassword(null, "roland");
            simon.PasswordHash = new PasswordHasher<User>().HashPassword(null, "simon");
            tomi.PasswordHash = new PasswordHasher<User>().HashPassword(null, "tamas");
            dariusz.PasswordHash = new PasswordHasher<User>().HashPassword(null, "dariusz");

            modelBuilder.Entity<User>().HasData(admin);
            modelBuilder.Entity<User>().HasData(andris);
            modelBuilder.Entity<User>().HasData(miki);
            modelBuilder.Entity<User>().HasData(boldi);
            modelBuilder.Entity<User>().HasData(roli);
            modelBuilder.Entity<User>().HasData(simon);
            modelBuilder.Entity<User>().HasData(tomi);
            modelBuilder.Entity<User>().HasData(dariusz);

            //Admin
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "e3b75db1-ab66-4847-9d19-3daf24eef74c",
                UserId = "b09ea12e-9e51-419f-826a-cbd38f3664df"
            });

            //Teacher
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "5610f2d4-92f9-4ad1-b921-a98e5cba7747",
                UserId = "fc5ddfbf-adbb-485b-9198-d5697f670632"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "5610f2d4-92f9-4ad1-b921-a98e5cba7747",
                UserId = "cd078415-b771-4375-9079-e0d497567e85"
            });

            //Student
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "117f7d38-f42f-4773-b196-fdc275380901",
                UserId = "70c69d55-28b8-4528-9c27-a4129f12659d"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "117f7d38-f42f-4773-b196-fdc275380901",
                UserId = "cd6687c1-30fb-4a21-b7d9-005986669286"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "117f7d38-f42f-4773-b196-fdc275380901",
                UserId = "796f78d1-9d03-4e0c-bd88-e22338e01425"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "117f7d38-f42f-4773-b196-fdc275380901",
                UserId = "cf7d31a0-20a7-4676-8e1f-c69d9470dc76"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "117f7d38-f42f-4773-b196-fdc275380901",
                UserId = "523fdb57-cdc3-4f91-bad8-12e80dfef125"
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity
                .HasOne(message => message.Threads)
                .WithMany(threads => threads.Messages)
                .HasForeignKey(message => message.ThreadID)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Threads>(entity =>
            {
                entity
                .HasOne(threads => threads.Room)
                .WithMany(room => room.Threads)
                .HasForeignKey(threads => threads.RoomID)
                .OnDelete(DeleteBehavior.SetNull); 
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

            modelBuilder.Entity<Reaction>(entity =>
            {
                entity
                .HasOne(reaction => reaction.Message)
                .WithMany(message => message.Reactions)
                .HasForeignKey(reaction => reaction.MessageID)
                .OnDelete(DeleteBehavior.Cascade);
                entity
                .HasOne(reaction => reaction.Thread)
                .WithMany(thread => thread.Reactions)
                .HasForeignKey(reaction => reaction.ThreadID)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
