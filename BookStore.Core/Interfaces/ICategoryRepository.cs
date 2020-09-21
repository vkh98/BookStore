using BookStore.Core.Entities;
using BookStore.Core.Interfaces.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookStore.Core.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();
    }
}
