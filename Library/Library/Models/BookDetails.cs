using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class BookDetails
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategories SubCategoryDetail { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Authors AuthorDetail { get; set; }
    }
}
