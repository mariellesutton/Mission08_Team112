using Microsoft.EntityFrameworkCore;

namespace Mission08_Team112.Models;

/// <summary>
/// Repository implementation using Entity Framework (SQLite). Used for dependency injection.
/// </summary>
public class EFTaskRepository : ITaskRepository
{
    private readonly TaskContext _context;

    public EFTaskRepository(TaskContext context)
    {
        _context = context;
    }

    public List<Task> Tasks => _context.Tasks.Include(t => t.Category).ToList();

    public List<Category> Categories => _context.Categories.OrderBy(c => c.CategoryName).ToList();

    public List<Task> GetIncompleteTasks() =>
        _context.Tasks.Include(t => t.Category).Where(t => !t.Completed).ToList();

    public void AddTask(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public void UpdateTask(Task task)
    {
        _context.Tasks.Update(task);
        _context.SaveChanges();
    }

    public void DeleteTask(Task task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
    }

    public Task GetTaskById(int id) =>
        _context.Tasks.Include(t => t.Category).FirstOrDefault(t => t.TaskId == id);

    public void MarkTaskComplete(int id)
    {
        var task = _context.Tasks.Find(id);
        if (task != null)
        {
            task.Completed = true;
            _context.SaveChanges();
        }
    }
}
