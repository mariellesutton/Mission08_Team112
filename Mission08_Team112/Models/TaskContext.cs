using Microsoft.EntityFrameworkCore;

namespace Mission08_Team112.Models;

/// <summary>
/// Database context for the Quadrant Task app. Uses SQLite.
/// </summary>
public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }
}
