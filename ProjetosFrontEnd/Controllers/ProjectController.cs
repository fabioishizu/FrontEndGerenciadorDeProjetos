using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetosFrontEnd.Models;
using ProjetosFrontEnd.Utils;
using ProjetosFrontEnd.Views.ViewModel;
using System.Diagnostics;

namespace ProjetosFrontEnd.Controllers;

public class ProjectController : Controller
{
    private readonly IHttpClientFactory clientFactory;
    List<Project> project;
    

    public ProjectController(IHttpClientFactory clientFactory)
    {
        this.clientFactory = clientFactory;
    }

    public async Task<ActionResult> Index(LoginUser user, string token = null)
    {
        ProjectViewModel projectView = new ProjectViewModel();

        try
        {
            token = TempData["TokenUser"].ToString();
            project = await AuxiliarRequisicao.RequisitarAPI<List<Project>>(HttpMethod.Get, "Projeto", clientFactory, null, token);
            projectView.Projects = project;
            TempData["TokenUser"] = token;
            return View(projectView);
        }
        catch (Exception ex)
        {
            return View(ex.Message);
        }
    }

    public async Task<ActionResult> UpdateProject(Project project)
    {
        try
        {
            project = await AuxiliarRequisicao.RequisitarAPI<Project>(HttpMethod.Put, $"Projeto/{project.ProjectId}", clientFactory, JsonConvert.SerializeObject(project), TempData["TokenUser"].ToString());
            return RedirectToAction("Index", "Project");
        }
        catch(Exception)
        {
            return RedirectToAction("Index", "Project");
        }
    }

    public async Task<ActionResult> DeleteProject([FromRoute] int id, Project project)
    {
        try
        {
            project = await AuxiliarRequisicao.RequisitarAPI<Project>(HttpMethod.Delete, $"Projeto/{id}", clientFactory, null, TempData["TokenUser"].ToString());
            return RedirectToAction("Index", "Project");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", "Project");
        }
    }

    public async Task<ActionResult> InsertProject(Project project)
    {
        if(project.ProjectId > 0)
            return RedirectToAction("UpdateProject", "Project", project);

        project = await AuxiliarRequisicao.RequisitarAPI<Project>(HttpMethod.Post, $"Projeto", clientFactory, JsonConvert.SerializeObject(project), TempData["TokenUser"].ToString());
        return RedirectToAction("Index", "Project");
    }
}
