using BookStore.Core.Entities;
using System;

namespace BookStore.Core.DTOs
{
    public class BooksDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public CategoryDto Category { get; set; }
        public DateTime PublishDate { get; set; }


    }
}
