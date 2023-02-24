using System.ComponentModel.DataAnnotations;

namespace ProjetosFrontEnd.Models;

public class Users
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O UserName precisa ser preenchido.")]
    [MaxLength(100, ErrorMessage = "O UserName é muito longo.")]
    public string UserName { get; set; }
    [Required(ErrorMessage = "A senha precisa ser preenchida.")]
    [MinLength(8, ErrorMessage = "A senha é muita curta, mínimo de 8 caracteres.")]
    public string Password { get; set; }
    public int CollaboratorsId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
