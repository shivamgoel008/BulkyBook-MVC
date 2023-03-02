

using Microsoft.EntityFrameworkCore;
using BulkyBookWeb.Models;
namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        // constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
        }
        // categories is the table name
        // get is getter and set is setter
        public DbSet<Category> Categories { get; set; }
    }
}
