using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Infrastructure.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookStoreContext context) : base(context)
        {

        }
        public BookStoreContext ApplicationContext { get { return Context as BookStoreContext; } }
        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return ApplicationContext.Categories
                .Select(q => new SelectListItem
                {
                    Text = q.Name,
                    Value = q.Id.ToString()
                });
        }
    }
}
