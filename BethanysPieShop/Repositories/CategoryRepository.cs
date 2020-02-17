using System.Collections.Generic;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;//.Include(c => c.Pies);
    }
}
