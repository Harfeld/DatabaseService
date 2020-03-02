using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DatabaseService.Data
{
    public class CraftsManDbContext : DbContext
    {
        public DbSet<CraftsMan> CraftsMen { get; set; }
        public DbSet<ToolBox> ToolBoxes { get; set; }
        public DbSet<Tool>  Tools { get; set; }

        public CraftsManDbContext() { }

        public CraftsManDbContext(DbContextOptions<CraftsManDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            onModelCreatingCraftsMan(modelBuilder);
            onModelCreatingToolBox(modelBuilder);
            onModelCreatingTool(modelBuilder);
            onModelCreatingSeedData(modelBuilder);
        }

        private void onModelCreatingCraftsMan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CraftsMan>();
        }
        
        private void onModelCreatingToolBox(ModelBuilder modelBuilder) {
            modelBuilder.Entity<ToolBox>()
                .HasOne(tb => tb.Owner);
        }

        private void onModelCreatingTool(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tool>()
                .HasOne(t => t.ToolBox);
        }

        private void onModelCreatingSeedData(ModelBuilder modelBuilder)
        {
            Guid jId = Guid.NewGuid();
            Guid mId = Guid.NewGuid();
            Guid redBoxId = Guid.NewGuid();
            Guid blackBoxId = Guid.NewGuid();

            modelBuilder.Entity<CraftsMan>().HasData(
                new CraftsMan
                {
                    Id = jId,
                    FirstName = "Jonas",
                    SurName = "HangMountain",
                    DateOfEmployment = DateTime.Today,
                    FieldOfWork = "Plumber"
                },
                new CraftsMan
                {
                    Id = mId,
                    FirstName = "Morten",
                    SurName = "Rosetwig",
                    DateOfEmployment = DateTime.Today,
                    FieldOfWork = "Carpenter"
                }
            );

            modelBuilder.Entity<ToolBox>().HasData(
                new ToolBox
                {
                    OwnerId = jId,
                    Acquired = DateTime.Today,
                    Brand = "redBox",
                    Model = "bigBox",
                    Color = "red",
                    SerialNumber = "10101",
                    Id = redBoxId
                },
                new ToolBox
                {
                    OwnerId = mId,
                    Acquired = DateTime.Today,
                    Brand = "blackBox",
                    Model = "smallBox",
                    Color = "black",
                    SerialNumber = "01010",
                    Id = blackBoxId
                }
            );

            modelBuilder.Entity<Tool>().HasData(
                new Tool { 
                    Acquired = DateTime.Today,
                    Type = "Hammer",
                    Brand = "Mjolner",
                    SerialNumber = "11000",
                    Model = "7",
                    Id = Guid.NewGuid(),
                    ToolBoxId = redBoxId
                },
                new Tool {
                    Acquired = DateTime.Today,
                    Type = "Saw",
                    Brand = "Biter",
                    SerialNumber = "00111",
                    Model = "4",
                    Id = Guid.NewGuid(),
                    ToolBoxId = blackBoxId
                }
            );
        }
    }
}
