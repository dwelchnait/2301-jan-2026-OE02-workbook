using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteDemos
{
    //we will need to go to NuGet Packages and include the following
    // MicroSoft.EntityFrameworkCore
    // MicroSoft.EntityFrameworkCore.Tools
    // MicroSoft.EntityFrameworkCore.SQLite

    //these packages are add to your project under Dependencies
    //this has to be done ONCE for your project

    //your project needs to use software from EF to interface
    //  with your persistent data
    //do obtain the use of the existing EF software we "inherit" a
    //  specific call of EF which is responsible for mapping and transferring
    //  data from your datastore to your program
    //The EF class you need to inherit is called DbContext
    //an inherited class is normally referred to as the "base" class
    public class AppDBContext : DbContext
    {
        //define a container within our application that will represent
        //  the entity of our datastore
        public DbSet<Person> People { get; set; }

        //configure the location of the datastore
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Force SQLite to use a single database file in the project root.
            // Prevents "no such table" errors caused by different working directories
            //adjusted path, one needs to know the location of your .exe
            //      AppDomain.CurrentDomain.BaseDirectory
            //once the .exe location is known, I can combine that location with
            //      relative address to reach the desired location of the SQLite file
            var dbPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "demo.db");

            //however we need to know the location of your application on the drive
            //phyiscal absolute address location
            dbPath = Path.GetFullPath(dbPath);

            //setup the datastore connection
            //need to identify the type of datastore
            optionsBuilder.UseSqlite(dbPath); //line in error
            //optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        //map the datastore entity to our application class (entity)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                //map
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Age)
                      .IsRequired();

                entity.Property(e => e.Mark)
                     .IsRequired();

                //one can also add validation for your data inside the mapping
                entity.ToTable(t => t.HasCheckConstraint("CK_Person_Age","[Age] >= 0"));
                //what if the condition needs to have a logical operator
                //when coding the constraint condition, think SQL (and, or, not)
                entity.ToTable(t => t.HasCheckConstraint("CK_Person_Mark", "[Mark] >= 0 and [Mark] <= 100"));
            });
        }
    }
}

