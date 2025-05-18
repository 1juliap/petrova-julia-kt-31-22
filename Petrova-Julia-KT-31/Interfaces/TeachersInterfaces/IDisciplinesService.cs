using Petrova_Julia_KT_31.Database;
using Petrova_Julia_KT_31.Filters.TeacherFilters;
using Petrova_Julia_KT_31.Models;
using Microsoft.EntityFrameworkCore;

namespace Petrova_Julia_KT_31.Interfaces.TeachersInterfaces
{
    public interface IDisciplinesService
    {
        public Task AddDisciplineAsync(int teacherId, string name, CancellationToken cancellationToken);
        public Task UpdateDisciplineAsync(int disciplineId, string newName, CancellationToken cancellationToken);
        public Task DeleteDisciplineAsync(int disciplineId, CancellationToken cancellationToken);
    }

    public class DisciplinesService : IDisciplinesService
    {
        private readonly TeacherDbContext _dbContext;
        public DisciplinesService(TeacherDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddDisciplineAsync(int teacherId, string name, CancellationToken cancellationToken = default)
        {
            var discipline = await _dbContext.Set<Discipline>().FirstOrDefaultAsync(t => t.TeacherId == teacherId);

            if (discipline != null)
            {
                var newDiscipline = new Discipline
                {
                    Name = name,
                    TeacherId = teacherId
                };

                _dbContext.Disciplines.Add(newDiscipline);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateDisciplineAsync(int disciplineId, string newName, CancellationToken cancellationToken = default)
        {
            var discipline = await _dbContext.Set<Discipline>().FindAsync(disciplineId);

            if (discipline != null)
            {
                discipline.Name = newName;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteDisciplineAsync(int disciplineId, CancellationToken cancellationToken = default)
        {
            var discipline = await _dbContext.Set<Discipline>().FindAsync(disciplineId);

            if (discipline != null)
            {
                _dbContext.Disciplines.Remove(discipline);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
