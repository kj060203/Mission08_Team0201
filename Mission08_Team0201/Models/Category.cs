using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0201.Models
{
    public class Category
    {
            [Key]
            public int CategoryId { get; set; } // Primary Key

            [Required]
            public string CategoryName { get; set; } // Home, School, Work, Church
        }
    }