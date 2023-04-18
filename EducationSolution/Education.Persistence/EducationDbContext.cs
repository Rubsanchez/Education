using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext() { }

        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;database=Education;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(x => x.Price)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "C# basic course",
                    Title = "From noob to pro C#",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddYears(2),
                    Price = 56
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Java course",
                    Title = "Java Spring Master",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddYears(2),
                    Price = 25
                },
                new Course
                {
                    CourseId = Guid.NewGuid(),
                    Description = ".NET Core Unit test course",
                    Title = ".NET Core Master Unit Test",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddYears(2),
                    Price = 1000
                }
            );            
        }
    }
}