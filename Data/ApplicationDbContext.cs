using AISAutoForms.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//using AISAutoForms.ViewModels;

namespace AISAutoForms.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Bryan: All tables should be defined here
        public DbSet<Student> Students { get; set; }
        public DbSet<ChgCourse> ChgCourses { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Approver> Approvers { get; set; }
        public DbSet<Registrar> Registrars { get; set; }
        public DbSet<ApproverMaint> ApproverMaints { get; set; }
        public DbSet<AddCourse> AddCourses { get; set; }
        public DbSet<EnrCourse> EnrCourses { get; set; }
        public DbSet<WitdCourse> WitdCourses { get; set; }
        //public DbSet<AISAutoForms.ViewModels.ChangeCourseVM> ChangeCourseVM { get; set; } = default!;


        //    protected override void OnModelCreating(ModelBuilder modelbuilder)
        //    {
        //        // This is all the configuration of the database relationship
        //        // One to One section
        //        modelbuilder.Entity<ChgCourse>()
        //            .HasOne(a => a.Account)
        //            .WithOne(b => b.ChgCourse)
        //            .HasForeignKey<Account>(b => b.AccountId);

        //        modelbuilder.Entity<ChgCourse>()
        //            .HasOne(a => a.Registrar)
        //            .WithOne(b => b.ChgCourse)
        //            .HasForeignKey<Registrar>(b => b.RegistrarId);

        //        // One to Many section
        //        modelbuilder.Entity<Student>()
        //            .HasMany(a => a.ChgCourses)
        //            .WithOne(b => b.Student)
        //            .HasForeignKey(b => b.ChgCourseId);

        //    modelbuilder.Entity<ChgCourse>()
        //            .HasMany(a => a.AddCourses)
        //            .WithOne(b => b.ChgCourse)
        //            .HasForeignKey(b => b.AddCourseId);

        //    modelbuilder.Entity<ChgCourse>()
        //            .HasMany(a => a.EnrCourses)
        //            .WithOne(b => b.ChgCourse)
        //            .HasForeignKey(b => b.EnrCourseId);

        //    modelbuilder.Entity<ChgCourse>()
        //            .HasMany(a => a.WitdCourses)
        //            .WithOne(b => b.ChgCourse)
        //            .HasForeignKey(b => b.WitdCourseId);

        //    modelbuilder.Entity<ChgCourse>()
        //            .HasMany(a => a.Approvers)
        //            .WithOne(b => b.ChgCourse)
        //            .HasForeignKey(b => b.ApproverId);

        //}

    }
}
