using System.ComponentModel.DataAnnotations;

namespace Technical_task.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
