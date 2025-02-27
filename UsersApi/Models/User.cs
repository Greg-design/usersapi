using System.ComponentModel.DataAnnotations;
using BCrypt.Net;

namespace UsersApi.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "O campo Nome deve ter entre 3 e 200 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Login é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo Login deve ser um e-mail válido")]
        [StringLength(100, ErrorMessage = "O campo Login pode ter no máximo 100 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        [StringLength(200, ErrorMessage = "A senha deve ter entre 6 e 200 caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Função é obrigatório")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo Função deve ter entre 3 e 20 caracteres")]
        public string Funcao { get; set; }

        public void SetPassword(string passwordHash)
        {
            Password = BCrypt.Net.BCrypt.HashPassword(passwordHash);
        }

        public bool VerifyPassword(string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(passwordHash, Password);
        }
    }
}
