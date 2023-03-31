using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions<EducationDbContext> options) : base(options) { }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .Property(x => x.Price)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CourseId = Guid.NewGuid(),
                    Description = "C# basic course",
                    Title = "From noob to pro C#",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddYears(2),
                    Price = 56
                },
                new Curso
                {
                    CourseId = Guid.NewGuid(),
                    Description = "Java course",
                    Title = "Java Spring Master",
                    CreationDate = DateTime.Now,
                    PublishDate = DateTime.Now.AddYears(2),
                    Price = 25
                },
                new Curso
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