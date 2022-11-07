using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class SubCategories
    {
        [Key]
        public int SubCategoryId { get; set; }

        [Required]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Categories CategoryDetail { get; set;}

    }
}
