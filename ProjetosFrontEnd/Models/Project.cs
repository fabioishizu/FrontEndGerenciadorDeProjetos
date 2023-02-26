using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ProjetosFrontEnd.Models;

public class Project
{
    [Key]
    [Required]
    public int ProjectId { get; set; }
    [Required(ErrorMessage = "O nome do projeto precisa ser preenchido.")]
    [MaxLength(100, ErrorMessage = "O nome do projeto é muito longo.")]
    public string Name { get; set; }
}
