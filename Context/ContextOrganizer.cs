using Microsoft.EntityFrameworkCore;
using task_manager.Models;

namespace task_manager.Context
{
    public class ContextOrganizer : DbContext
    {
        public ContextOrganizer(DbContextOptions<ContextOrganizer> options) : base(options)
        {

        }

        public DbSet<Assignment> Assignment { get; set; }
    }
}