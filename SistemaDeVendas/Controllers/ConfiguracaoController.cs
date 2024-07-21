using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private IHttpContextAccessor httpContext;

        public ConfiguracaoController(IHttpContextAccessor HttpContextAccessor)
        {
            httpContext = HttpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Senha(int? id)
        { 
            return View();

        }
        [HttpPost]
        public IActionResult Senha(SenhaModel Senha)
        {
            string primeiraSenha = Senha.Senha1.ToString();
            string segundaSenha = Senha.Senha2.ToString();

            if (primeiraSenha == segundaSenha)
            {
                Senha.Id = httpContext.HttpContext.Session.GetString("IdUsuarioLogado");
                Senha.AlterarSenha();
                return RedirectToAction("SenhaAlterada");
            }
            else
            {
                TempData["ErrorSenha"] = "As Senhas não coencidem!";
                //return RedirectToAction("Senha", "Configuracao");
            }

            return View();
        }

        public IActionResult SenhaAlterada()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}