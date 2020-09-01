using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using StudentRegistration.Models.ConDb;

namespace StudentRegistration.Data
{
    public partial class ConDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly IHttpContextAccessor httpAccessor;

        public ConDbContext(IHttpContextAccessor httpAccessor, DbContextOptions<ConDbContext> options):base(options)
        {
            this.httpAccessor = httpAccessor;
        }

        public ConDbContext(IHttpContextAccessor httpAccessor)
        {
            this.httpAccessor = httpAccessor;
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<StudentRegistration.Models.ConDb.Student>()
                  .HasOne(i => i.Gender)
                  .WithMany(i => i.Students)
                  .HasForeignKey(i => i.GenderID)
                  .HasPrincipalKey(i => i.GenderID);
            builder.Entity<StudentRegistration.Models.ConDb.Student>()
                  .HasOne(i => i.Class1)
                  .WithMany(i => i.Students)
                  .HasForeignKey(i => i.CurrentClassID)
                  .HasPrincipalKey(i => i.ClassID);


            this.OnModelBuilding(builder);
        }


        public DbSet<StudentRegistration.Models.ConDb.Class1> Class1s
        {
          get;
          set;
        }

        public DbSet<StudentRegistration.Models.ConDb.Gender> Genders
        {
          get;
          set;
        }

        public DbSet<StudentRegistration.Models.ConDb.Student> Students
        {
          get;
          set;
        }
    }
}
