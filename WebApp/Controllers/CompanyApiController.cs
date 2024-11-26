using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Movies;

namespace WebApp.Controllers;

[ApiController]
[Route("/api/companies")]
public class CompanyApiController: ControllerBase
{
    private readonly MoviesDbContext _context;

    public CompanyApiController(MoviesDbContext context)
    {
        _context = context;
    }

    public IActionResult GetByName(string fragment)
    {
        return Ok(_context
            .ProductionCompanies
            .Where(c => c.CompanyName != null && c.CompanyName.ToLower().Contains(fragment.ToLower()))
            .AsNoTracking()
            .AsEnumerable()
        );
    }
}