using Microsoft.EntityFrameworkCore;

namespace AHY.CQRS.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[] {
            new Student(){Name="Hakan",Age=20,Surname="Yıldız",Id=1},
            new Student(){Name="Reyhan",Age=21,Surname="Çetmen",Id=2}
            }
            );
        }
        public DbSet<Student> Students { get; set; }
    }
}
