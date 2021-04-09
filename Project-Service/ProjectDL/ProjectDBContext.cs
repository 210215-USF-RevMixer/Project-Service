using Microsoft.EntityFrameworkCore;
using ProjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDL
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions options) : base(options)
        {
        }
        public ProjectDBContext()
        {
        }
        public DbSet<Pattern> Pattern { get; set; }
        public DbSet<Sample> Sample { get; set; }
        public DbSet<SamplePlaylist> SamplePlaylist { get; set; }
        public DbSet<SampleSets> SampleSet { get; set; }
        public DbSet<UsersSample> UsersSample { get; set; }
        public DbSet<UsersSampleSets> UsersSampleSets { get; set; }
        public DbSet<SavedProject> SavedProject { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pattern>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Sample>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SamplePlaylist>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SampleSets>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<UsersSample>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<UsersSampleSets>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SavedProject>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Track>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<UserProject>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            //a sample can have many tracks, but a track can only have one sample
            //if a sample is deleted, don't delete the whole track
            modelBuilder.Entity<Sample>()
                .HasMany(s => s.Track)
                .WithOne(t => t.Sample)
                .OnDelete(DeleteBehavior.SetNull);

            //a pattern can belong to many tracks, but a track can only have one pattern
            //even if a pattern is deleted, we don't necessarily want to delete the track
            modelBuilder.Entity<Pattern>()
                .HasMany(p => p.Tracks)
                .WithOne(t => t.Pattern)
                .OnDelete(DeleteBehavior.SetNull);

            //a saved project can have many userprojects (users who can edit one project), but a userproject can only have one project reference
            //when a project is deleted (only allowed by owner, ideally), the associated users who can edit will have access revoked from
            //the now non-existant project
            modelBuilder.Entity<SavedProject>()
                .HasMany(sp => sp.UserProjects)
                .WithOne(up => up.SavedProject)
                .OnDelete(DeleteBehavior.Cascade);

            //a saved project can have many tracks, but a track can only belong to one project
            //when a project is deleted, it's related tracks are also deleted
            modelBuilder.Entity<SavedProject>()
                .HasMany(sp => sp.Tracks)
                .WithOne(t => t.SavedProject)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UsersSample>()
                .HasMany(us => us.UserId)
                .HasMany(us => us.SampleId);

            modelBuilder.Entity<UsersSampleSets>()
                .HasMany(uss => uss.UserId)
                .HasMany(uss => uss.SampleId);
        }
    }
}
