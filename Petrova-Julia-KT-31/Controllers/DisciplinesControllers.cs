using Petrova_Julia_KT_31.Interfaces.TeachersInterfaces;
using Petrova_Julia_KT_31.Filters.TeacherFilters;
using Petrova_Julia_KT_31.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Petrova_Julia_KT_31.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinesController : Controller
        {
            private readonly ILogger<DisciplinesController> _logger;
            private readonly IDisciplinesService _disciplineService;

            public DisciplinesController(ILogger<DisciplinesController> logger, IDisciplinesService disciplineService)
            {
                _logger = logger;
                _disciplineService = disciplineService;
            }

            [HttpPost("AddDiscipline")]
            public async Task<IActionResult> AddDisciplineAsync(int teacherId, string name, CancellationToken cancellationToken = default)
            {
                try
                {
                    await _disciplineService.AddDisciplineAsync(teacherId, name, cancellationToken);
                    return Ok("Дисциплина успешно добавлена.");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Ошибка при добавлении дисциплины: {ex.Message}");
                }
            }

            [HttpPut("UpdateDiscipline/{disciplineId}")]
            public async Task<IActionResult> UpdateDisciplineAsync(int disciplineId, string newName, CancellationToken cancellationToken = default)
            {
                try
                {
                    await _disciplineService.UpdateDisciplineAsync(disciplineId, newName, cancellationToken);
                    return Ok("Дисциплина успешно обновлена.");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Ошибка при обновлении дисциплины: {ex.Message}");
                }
            }

            [HttpDelete("DeleteDiscipline/{disciplineId}")]
            public async Task<IActionResult> DeleteDisciplineAsync(int disciplineId, CancellationToken cancellationToken = default)
            {
                try
                {
                    await _disciplineService.DeleteDisciplineAsync(disciplineId, cancellationToken);
                    return Ok("Дисциплина успешно удалена.");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Ошибка при удалении дисциплины: {ex.Message}");
                }
            }
        }
    }
