using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.Entities
{

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(255, ErrorMessage = "Category Name cannot be longer than 255 characters!")]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Display order is required.")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }

        public ICollection<Book> Books { get; set; }

        public Category()
        {
            Books = new Collection<Book>();
        }
    }
}
