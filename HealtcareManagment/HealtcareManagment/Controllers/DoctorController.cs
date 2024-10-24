using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealtcareManagment.Data;
using HealtcareManagment.Models;

namespace HealtcareManagment.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DoctorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetAllDoctors")]
    public async Task<IActionResult> GetAllDoctors()
    {
        var doctors = await _context.Doctors.Include(d => d.User).ToListAsync();
        return Ok(doctors);
    }
}
