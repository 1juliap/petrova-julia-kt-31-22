using Microsoft.EntityFrameworkCore;
using Petrova_Julia_KT_31.Database;
using Petrova_Julia_KT_31.Filters.TeacherFilters;
using Petrova_Julia_KT_31.Interfaces.TeachersInterfaces;
using Petrova_Julia_KT_31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrova_Julia_KT_31.Test
{
    public class TeacherIntegrationTests
    {
        private DbContextOptions<TeacherDbContext> _dbContextOptions;

        public TeacherIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
                .UseInMemoryDatabase(databaseName: "TeacherTestDb")
                .Options;
        }

        [Fact]
        public async Task GetTeachersWithAllAsync_FilterByDepartmentAcademicDegreeStaff_ReturnsCorrectTeachers()
        {
            //arrange
            using var ctx = new TeacherDbContext(_dbContextOptions);

            var departments = new List<Department>
        {
            new Department { DepartmentId = 1, Name = "Математика" },
            new Department { DepartmentId = 2, Name = "Физика" }
        };
            var degrees = new List<AcademicDegree>
        {
            new AcademicDegree { AcademicDegreeId = 1, Name = "Магистр" },
            new AcademicDegree { AcademicDegreeId = 2, Name = "Бакалавр" }
        };
            var staffs = new List<Staff>
        {
            new Staff { StaffId = 1, Name = "Профессор" },
            new Staff { StaffId = 2, Name = "Доцент" }
        };

            await ctx.Set<Department>().AddRangeAsync(departments);
            await ctx.Set<AcademicDegree>().AddRangeAsync(degrees);
            await ctx.Set<Staff>().AddRangeAsync(staffs);

            var teachers = new List<Teacher>
        {
            new Teacher
            {
                FirstName = "Алексей",
                LastName = "Алексеев",
                MiddleName = "Алексеевич",
                DepartmentId = 1,
                AcademicDegreeId = 1,
                StaffId = 1
            },
            new Teacher
            {
                FirstName = "Петр",
                LastName = "Петров",
                MiddleName = "Петрович",
                DepartmentId = 2,
                AcademicDegreeId = 2,
                StaffId = 2
            },
            new Teacher
            {
                FirstName = "Александра",
                LastName = "Александрова",
                MiddleName = "Александровна",
                DepartmentId = 1,
                AcademicDegreeId = 2,
                StaffId = 1
            }
        };
            await ctx.Set<Teacher>().AddRangeAsync(teachers);
            await ctx.SaveChangesAsync();

            var service = new TeacherService(ctx);

            //act
            var filter = new TeacherFilter
            {
                DepartmentName = "Математика",
                AcademicDegreeName = "Магистр",
                StaffName = "Профессор"
            };

            var result = await service.GetTeachersWithAllAsync(filter, CancellationToken.None);

            //assert
            Assert.Single(result);
            Assert.Equal("Алексей", result[0].FirstName);
            Assert.Equal("Алексеев", result[0].LastName);
        }
    }
}
