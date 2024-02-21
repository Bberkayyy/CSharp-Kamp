using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Course>(a =>
        {
            a.ToTable("Courses").HasKey(x => x.Id);
            a.Property(x => x.Id).HasColumnName("Id");
            a.Property(x => x.CategoryId).HasColumnName("CategoryId");
            a.Property(x => x.InstructorId).HasColumnName("InstructorId");
            a.Property(x => x.Name).HasColumnName("Name");
            a.Property(x => x.Description).HasColumnName("Description");
            a.Property(x => x.ImageUrl).HasColumnName("ImageUrl");
            a.Property(x => x.Price).HasColumnName("Price");
            a.Property(x => x.ComplatedBar).HasColumnName("ComplatedBar");

            a.HasOne(x => x.Category);
            a.HasOne(x => x.Instructor);
        });
        modelBuilder.Entity<Category>(a =>
        {
            a.ToTable("Categories").HasKey(x => x.Id);
            a.Property(x => x.Id).HasColumnName("Id");
            a.Property(x => x.Name).HasColumnName("Name");

            a.HasMany(x => x.Courses);
        });
        modelBuilder.Entity<Instructor>(a =>
        {
            a.ToTable("Instructors").HasKey(x => x.Id);
            a.Property(x => x.Id).HasColumnName("Id");
            a.Property(x => x.FirstName).HasColumnName("FirstName");
            a.Property(x => x.LastName).HasColumnName("LastName");
            a.Property(x => x.Title).HasColumnName("Title");
            a.Property(x => x.Description).HasColumnName("Description");
            a.Property(x => x.ImageUrl).HasColumnName("ImageUrl");

            a.HasMany(x => x.Courses);
        });
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
}
