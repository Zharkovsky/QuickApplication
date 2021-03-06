﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Interfaces
{
    public interface IDisciplineRepository : IRepository<Discipline>
    {
        IEnumerable<Discipline> GetAllDisciplinesData();
    }
}
