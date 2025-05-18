using Petrova_Julia_KT_31.Database;
using Petrova_Julia_KT_31.Filters.TeacherFilters;
using Petrova_Julia_KT_31.Models;
using Microsoft.EntityFrameworkCore;

namespace Petrova_Julia_KT_31.Interfaces.TeachersInterfaces
{
        public interface ITeacherService
        {
        public Task<Teacher[]> GetTeachersAsync(CancellationToken cancellationToken);
        public Task<Teacher[]> GetTeachersWithAllAsync(TeacherFilter filter, CancellationToken cancellationToken);

    }

        public class TeacherService : ITeacherService
        {
            private readonly TeacherDbContext _dbContext;
            public TeacherService(TeacherDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Teacher[]> GetTeachersAsync(CancellationToken cancellationToken = default)
            {
                var teachers = await _dbContext.Set<Teacher>().ToArrayAsync(cancellationToken);

                return teachers;
            }

            public Task<Teacher[]> GetTeachersWithAllAsync(TeacherFilter filter, CancellationToken cancellationToken = default)
                {
                    var teachers = _dbContext.Set<Teacher>().Where(w =>
                        (filter.DepartmentName == null || w.Department.Name == filter.DepartmentName) &&
                        (filter.AcademicDegreeName == null || w.AcademicDegree.Name == filter.AcademicDegreeName) &&
                        (filter.StaffName == null || w.Staff.Name == filter.StaffName))
                        .ToArrayAsync(cancellationToken);
                    return teachers;
            }
        }
}

