using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class DisciplineRepository : Repository<Discipline>, IDisciplineRepository
    {
        public DisciplineRepository(ApplicationDbContext context) : base(context)
        { }


        public IEnumerable<Discipline> GetAllDisciplinesData()
        {
            return _appContext.Disciplines
                .OrderBy(d => d.Name)
                .ToList();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
