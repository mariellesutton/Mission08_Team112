namespace Mission08_Team112.Models;

public interface ITaskRepository
{
    List<Task> Tasks { get; }
    List<Category> Categories { get; }

    /// <summary>Returns only tasks where Completed is false (for Quadrants view).</summary>
    List<Task> GetIncompleteTasks();

    void AddTask(Task task);
    void UpdateTask(Task task);
    void DeleteTask(Task task);
    Task GetTaskById(int id);
    void MarkComplete(int id);
}
