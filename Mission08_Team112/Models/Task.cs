namespace Mission08_Team112.Models;
using System.ComponentModel.DataAnnotations;

    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task name is required")]
        public string TaskName { get; set; }

        public string? DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required")]
        [Range(1, 4, ErrorMessage = "Quadrant must be between 1 and 4")]
        public int Quadrant { get; set; }

        // Foreign Key Relationship
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool Completed { get; set; } = false;
        
        
    }
