using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0201.Models
{
    public class TaskModel
    {
            [Key]
            public int TaskId { get; set; } // Primary Key

            [Required]
            public string TaskName { get; set; } // Task Description

            [DataType(DataType.Date)]
            public DateTime? DueDate { get; set; } // Optional Due Date

            [Required]
            public int Quadrant { get; set; } // 1, 2, 3, or 4

            [Required]
            [ForeignKey("Category")]
            public int CategoryId { get; set; } // Foreign Key to Category Table

            public CategoryModel? Category { get; set; } // Navigation Property

            public bool Completed { get; set; } // True if task is done
        }
    }
