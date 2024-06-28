using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.MVC.Models.Entities;
using System.Security.Principal;

namespace StudentPortal.Web.MVC.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}
