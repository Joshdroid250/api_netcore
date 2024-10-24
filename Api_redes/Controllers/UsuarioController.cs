
using Microsoft.AspNetCore.Mvc;

using Api_redes.Models;



namespace Api_redes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly TuDbContext _tuDbContext;

        public UsuarioController(TuDbContext _context)
        {
            _tuDbContext = _context;
        }

        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista() { 
            List<User> users = new List<User>();

            try
            {
                users = _tuDbContext.Users.ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = users });
            }
            catch (Exception ex) {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = users });

            }
        }
    }
}
