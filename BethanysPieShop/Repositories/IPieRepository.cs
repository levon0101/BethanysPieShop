﻿using System.Collections.Generic;
using BethanysPieShop.Models;

namespace BethanysPieShop.Repositories
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }

        IEnumerable<Pie> PiesOfTheWeek { get; }

        Pie GetPieById(int pieId);

    }
}
