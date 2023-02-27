using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetosFrontEnd.Models;
using ProjetosFrontEnd.Utils;
using System.Diagnostics;

namespace ProjetosFrontEnd.Controllers
{
    public class UsersController : Controller
    {
        private readonly IHttpClientFactory clientFactory;
        List<Users> users;

        public UsersController(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Autenticar([FromForm] LoginUser user)
        {
            try
            {
                user = await AuxiliarRequisicao.RequisitarAPI<LoginUser>(HttpMethod.Post, "Users/login", clientFactory, JsonConvert.SerializeObject(user));
                TempData["TokenUser"] = user.Token;
                return RedirectToAction("Index", "Project", user);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Users");
            }
        }

    }
}