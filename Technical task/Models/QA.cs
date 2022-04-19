using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_task.Models
{
    public class QA
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string question { get; set; }
        public string answer { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string correct { get; set; }
        
        public int parentId { get; set; }
        [ForeignKey("parentId")]
        public virtual Test Test { get; set; }
    }
}
