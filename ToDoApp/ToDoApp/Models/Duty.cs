using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models
{
    public class Duty
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } =string.Empty;
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

       [Column(TypeName = "nvarchar(20)")]
        public Priority? Priority { get; set; } 
       [Column(TypeName = "nvarchar(20)")]
        public Status? Status { get; set; }

        public TimeSpan?  Duration { get; set; }

        public DateTime DueDate { get; set; }
    }
}
