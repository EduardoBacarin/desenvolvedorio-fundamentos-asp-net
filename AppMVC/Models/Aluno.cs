using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMVC.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {1} e {2} caracteres")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "O campo {0} está formatado errado")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {1} e {2} caracteres")]
        [EmailAddress(ErrorMessage = "O campo {0} não é válido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "O campo {0} deve ter entre {1} e {2} caracteres")]
        [EmailAddress(ErrorMessage = "O campo {0} não é válido")]
        [Display(Name = "Confirme o e-mail")]
        [Compare("Email", ErrorMessage = "Os e-mails não coincidem")]
        [NotMapped]
        public string? EmailConfirmacao { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(1, 5, ErrorMessage = "O valor deve ser de {1} a {2}")]
        public int Avaliacao { get; set; }
        public bool Ativo { get; set; }
    }
}
