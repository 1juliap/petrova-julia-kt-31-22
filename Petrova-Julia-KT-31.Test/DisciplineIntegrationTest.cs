using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Petrova_Julia_KT_31.Controllers;
using Petrova_Julia_KT_31.Database;
using Petrova_Julia_KT_31.Interfaces.TeachersInterfaces;
using Petrova_Julia_KT_31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrova_Julia_KT_31.Test
{
    public class DisciplineIntegrationTest
    {
        private DbContextOptions<TeacherDbContext> _dbContextOptions;

        public DisciplineIntegrationTest()
        {
            _dbContextOptions = new DbContextOptionsBuilder<TeacherDbContext>()
                .UseInMemoryDatabase(databaseName: "DisciplinesTestDb")
                .Options;
        }

        [Fact]
        public async Task AddUpdateDeleteDiscipline_Flow_Success()
        {
            //arrange
            using var context = new TeacherDbContext(_dbContextOptions);

            // Добавляем преподавателя
            var teacher = new Teacher { FirstName = "Иван", LastName = "Иванов", MiddleName = "Иванович" };
            await context.Teachers.AddAsync(teacher);
            await context.SaveChangesAsync();

            var existingDiscipline = new Discipline
            {
                Name = "Existing Discipline",
                TeacherId = teacher.TeacherId
            };
            await context.Disciplines.AddAsync(existingDiscipline);
            await context.SaveChangesAsync();

            var logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<DisciplinesController>();
            var service = new DisciplinesService(context);
            var controller = new DisciplinesController(logger, service);

            CancellationToken token = CancellationToken.None;

            //act 1
            var addResult = await controller.AddDisciplineAsync(teacher.TeacherId, "Математика", token);
            Assert.IsType<OkObjectResult>(addResult);

            var disciplineInDb = await context.Disciplines.FirstOrDefaultAsync(d => d.Name == "Математика" && d.TeacherId == teacher.TeacherId);
            Assert.NotNull(disciplineInDb);

            //act 2
            var updateResult = await controller.UpdateDisciplineAsync(disciplineInDb.DisciplineId, "Математический анализ", token);
            Assert.IsType<OkObjectResult>(updateResult);

            var updatedDiscipline = await context.Disciplines.FindAsync(disciplineInDb.DisciplineId);
            Assert.Equal("Математический анализ", updatedDiscipline!.Name);

            //act 3
            var deleteResult = await controller.DeleteDisciplineAsync(updatedDiscipline.DisciplineId, token);
            Assert.IsType<OkObjectResult>(deleteResult);

            var deletedDiscipline = await context.Disciplines.FindAsync(updatedDiscipline.DisciplineId);
            Assert.Null(deletedDiscipline);
        }
    }
}
