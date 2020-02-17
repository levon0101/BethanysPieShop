using System.Collections.Generic;
using System.Linq;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Repositories
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<Pie> AllPies => _appDbContext.Pies.Include(p => p.Category);


        public IEnumerable<Pie> PiesOfTheWeek => _appDbContext.Pies.Include(p => p.Category).Where(p=> p.IsPieOfTheWeek);


        public Pie GetPieById(int pieId)
        {
            return _appDbContext.Pies.Include(p => p.Category).FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
