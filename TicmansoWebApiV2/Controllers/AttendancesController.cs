using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using TicmansoV2.Shared;
using TicmansoWebApiV2.Context;

namespace TicmansoWebApiV2.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly TicmansoDbContext _context;

        public AttendancesController(TicmansoDbContext context)
        {
            _context = context;
        }

        // GET: api/Attendance/2023-04-16/1
        [HttpGet("{date}/{userId}")]
        [Produces("application/json")]
        public ActionResult<AttendanceDTO> GetAttendance(DateTime date, string userId)
        {
            var attendance = _context.Attendances
                .Where(a => a.Date == date && a.UserId == userId)
                .Select(a => new AttendanceDTO
                {
                    Date = a.Date,
                    EntryTime = a.EntryTime,
                    DepartureTime = a.DepartureTime,
                    UserId = a.UserId
                })
                .AsEnumerable()
                .FirstOrDefault();

            if (attendance == null) return NotFound("No se ha encontrado jornada para este usuario");

            return attendance;
        }

        // PUT: api/Attendance/2023-04-16/1
        [HttpPut("{date}/{userId}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateAttendance(DateTime date, string userId, AttendanceDTO attendanceDTO)
        {
            var attendance = await _context.Attendances.FindAsync(date, userId);
            if (attendance == null) return NotFound();

            attendance.EntryTime = attendanceDTO.EntryTime;
            attendance.DepartureTime = attendanceDTO.DepartureTime;

            _context.Attendances.Update(attendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Attendance
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<AttendanceDTO>> CreateAttendance(AttendanceDTO attendanceDTO)
        {
            var existingAttendance = _context.Attendances
                .Where(a => a.Date == attendanceDTO.Date && a.UserId == attendanceDTO.UserId)
                .AsEnumerable()
                .FirstOrDefault();

            if (existingAttendance != null)
            {
                return Conflict("Ya existe un registro de asistencia para la fecha y el usuario especificados.");
            }

            
            var attendance = new Attendance
            {
                Date = attendanceDTO.Date,
                EntryTime = attendanceDTO.EntryTime,
                DepartureTime = attendanceDTO.DepartureTime,
                UserId = attendanceDTO.UserId
            };

            
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttendance), new { date = attendance.Date, userId = attendance.UserId }, attendanceDTO);
        }

        // DELETE: api/Attendance/2023-04-16/1  
        [HttpDelete("{date}/{userId}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteAttendance(DateTime date, string userId)
        {
            var attendance = await _context.Attendances.FindAsync(date, userId);
            if (attendance == null) return NotFound();

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
