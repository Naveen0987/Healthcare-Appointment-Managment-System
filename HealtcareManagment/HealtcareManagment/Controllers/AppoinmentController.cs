using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealtcareManagment.Data;
using HealtcareManagment.Models;

namespace HealtcareManagment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AppointmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
    {
        appointment.CreatedAt = DateTime.Now;
        appointment.UpdatedAt = DateTime.Now;

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Appointment created successfully" });
    }

    [HttpGet("GetAppointmentsForPatient/{patientId}")]
    public async Task<IActionResult> GetAppointmentsForPatient(int patientId)
    {
        var appointments = await _context.Appointments
                                         .Include(a => a.Doctor)
                                         .Where(a => a.PatientId == patientId)
                                         .ToListAsync();

        return Ok(appointments);
    }
}
