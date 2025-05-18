using Petrova_Julia_KT_31.Interfaces.TeachersInterfaces;
using Petrova_Julia_KT_31.Filters.TeacherFilters;
using Petrova_Julia_KT_31.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Petrova_Julia_KT_31.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController : ControllerBase
    {
        //private readonly ILogger<TeachersController> _logger;
        private readonly ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            //_logger = logger;
            _teacherService = teacherService;
        }

        [HttpGet("GetTeachers")]
        public async Task<IActionResult> GetTeachersAsync(CancellationToken cansellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersAsync(cansellationToken);
            return Ok(teachers);
        }

        [HttpGet("GetTeachersByCafedraDegreeStaff")]
        public async Task<IActionResult> GetTeachersWithAllAsync(TeacherFilter filter, CancellationToken cancellationToken = default)
        {
            var teachers = await _teacherService.GetTeachersWithAllAsync(filter, cancellationToken);
            return Ok(teachers);
        }
    }
}
