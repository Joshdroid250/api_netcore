
using Microsoft.AspNetCore.Mvc;

using Api_redes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Routing;



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
        [Route("")]

        public IActionResult GetAllUser() {
            List<User> users = new List<User>();

            try
            {
                users = _tuDbContext.Users.ToList();

                if (users == null || !users.Any())
                {
                    return StatusCode(StatusCodes.Status204NoContent, new { mensaje = "No hay usuarios disponibles", response = users });
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = users });
            }
            catch (Exception ex)
            {
                // Registro del error si es necesario (log)
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrió un error", detalle = ex.Message });
            }
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetUsersByID(int id)
        {
            User oUsers = _tuDbContext.Users.Find(id);

            if (oUsers == null)
            {
                return BadRequest("User not found");
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oUsers });
            }
            catch (Exception ex)
            {
                // Registro del error si es necesario (log)
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrió un error", detalle = ex.Message });
            }
        }

        [HttpPost]

        [Route("")]

        public IActionResult AddUser([FromBody] User oUser) {



            try
            {
                _tuDbContext.Users.Add(oUser);
                _tuDbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ocurrió un error", detalle = ex.Message });

            }
        }

        [HttpPut]

        [Route("")]

        public IActionResult UpdateUser([FromBody] User ouser)
        {
            User oUsers = _tuDbContext.Users.Find(ouser.Id);

            if (oUsers == null)
            {
                return BadRequest("User not found");
            }

            try
            {
                oUsers.Nombre = ouser.Nombre is null ? oUsers.Nombre : ouser.Nombre;
                oUsers.Contraseña = ouser.Contraseña is null ? oUsers.Contraseña : ouser.Contraseña;

                _tuDbContext.Users.Update(ouser);
                _tuDbContext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ocurrió un error", detalle = ex.Message });

            }
        }


        [HttpDelete]
        [Route("{id:int}")]

        public IActionResult DeleteUsersByID(int id)
        {
            User oUsers = _tuDbContext.Users.Find(id);

            if (oUsers == null)
            {
                return BadRequest("User not found");
            }

            try
            {
                _tuDbContext.Users.Remove(oUsers);
                _tuDbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                // Registro del error si es necesario (log)
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Ocurrió un error", detalle = ex.Message });
            }
        }

    }
}
