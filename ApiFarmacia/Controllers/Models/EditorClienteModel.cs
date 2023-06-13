using System.ComponentModel.DataAnnotations;

namespace ApiFarmacia.Controller.Models
{
    public class EditorClienteModel
    {
        public int Id { get; set; }
        public string? Cpf { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo nome deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Defina uma senha")]
        public string Senha { get; set; }
        public string? Estado { get; set; }
        public string? Quadra { get; set; }
        public string? Conjunto { get; set; }
        public string? Telefone { get; set; }
    }
}
