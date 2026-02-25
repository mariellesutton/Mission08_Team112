namespace Mission08_Team112.Models;

    public interface ITaskRepository
    {
        List<Task> Tasks { get; }
        List<Category> Categories { get; }

        public void AddTask(Task task);
        public void UpdateTask(Task task);
        public void DeleteTask(Task task);

        public Task GetTaskById(int id);
        
        // NEW: Mark a task as completed (can be done inside UpdateTask, but a helper is nice)
        public void MarkTaskComplete(int id);
    }
