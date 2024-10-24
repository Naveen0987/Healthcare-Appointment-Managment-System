using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealtcareManagment.Data;
using HealtcareManagment.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HealtcareManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly SymmetricSecurityKey _jwtKey;

    public UsersController(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;

        // Retrieve the JWT key from Program.cs (not generated randomly)
        var jwtKey = configuration["JwtSettings:Secret"];
        //_jwtKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtKey));
        _jwtKey = new SymmetricSecurityKey(Convert.FromBase64String(jwtKey));
    }

    // Register a new user
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        // Check if username already exists
        if (await _context.Users.AnyAsync(u => u.Username == user.Username))
        {
            return BadRequest(new { message = "Username already exists." });
        }

        // Check if email already exists
        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
        {
            return BadRequest(new { message = "Email already exists." });
        }

        // Hash the password before saving
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
        user.CreatedAt = DateTime.Now;
        user.UpdatedAt = DateTime.Now;

        // Add the user to the Users table
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User registered successfully" });
    }

    // Login user and return JWT
    [HttpPost("Login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        Console.WriteLine($"Login Attempt - Username: {username}, Password: {password}");

        var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return Unauthorized(new { message = "Invalid credentials" });
        }

        bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        Console.WriteLine($"Password Match: {passwordMatch}");
        if (!passwordMatch)
        {
            return Unauthorized(new { message = "Invalid credentials" });
        }

        // Generate JWT token
        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }

    // Get all users with role "Patient"
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetPatients()
    {
        var patients = await _context.Users
                        .Where(u => u.Role == "Patient").ToListAsync();
        return Ok(patients);
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(_jwtKey, SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
