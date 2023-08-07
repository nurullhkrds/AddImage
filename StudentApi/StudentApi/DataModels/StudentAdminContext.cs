using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StudentApi.DataModels
{
    public class StudentAdminContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=NURULLAH\\SQLEXPRESS;" +
                "database=UploadFile;integrated security=true;" +
                "Trusted_Connection=True;TrustServerCertificate=True;");
        }
      


        public DbSet<Student> Student { get; set; }
       

    }
}
