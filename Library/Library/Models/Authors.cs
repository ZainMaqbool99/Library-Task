using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }
    }
}
