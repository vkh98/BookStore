using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Core.Entities
{
    //[Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(255, ErrorMessage = "Name cannot be longer than 255 characters!")]
        [Display(Name = "Book Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [Display(Name = "Book Category")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }


    }
}
