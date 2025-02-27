using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersApi.Data;
using UsersApi.Models;

namespace UsersApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersApiDBContext _context;

        public UsersController(UsersApiDBContext context)
        {
            _context = context;
        }

        // GET: api/users - Listar todos os usuários
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/users/{id} - Buscar um usuário pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            return user;
        }

        // POST: api/users - Criar um novo usuário
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // PUT: api/users/{id} - Atualizar um usuário existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest(new { message = "O ID fornecido não corresponde ao usuário." });
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            user.Nome = updatedUser.Nome;
            user.Login = updatedUser.Login;
            user.Funcao = updatedUser.Funcao;

            if (!string.IsNullOrWhiteSpace(updatedUser.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(updatedUser.Password);
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/users/{id} - Remover um usuário
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
