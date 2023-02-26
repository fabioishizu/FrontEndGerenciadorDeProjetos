using ProjetosFrontEnd.Models;

namespace ProjetosFrontEnd.Views.ViewModel;

public class ProjectViewModel
{
    public List<Project> Projects { get; set; }
    public Project Project { get; set; }
    public string Token { get; set; }

}
