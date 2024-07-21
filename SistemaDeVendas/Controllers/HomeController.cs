using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Models;
using SistemaDeVendas.Uteis;

namespace SistemaDeVendas.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Menu()
        {
            ViewData["HideMenu"] = false;
            return View();
        }

        public IActionResult Login(int? id)
        {
            ViewData["HideMenu"] = false;

            if (id != null)
            {
                if (id == 0)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", string.Empty);
                    HttpContext.Session.SetString("NomeUsuarioLogado", string.Empty);
                }
               
            }
            return View();
            
        }

        [HttpPost]
        public IActionResult Login(LoginModel login)
        {
            ViewData["HideMenu"] = false;
            if (ModelState.IsValid)
            {
                bool loginOK = login.ValidarLogin();
                if (loginOK)
                {
                    HttpContext.Session.SetString("IdUsuarioLogado", login.Id);
                    HttpContext.Session.SetString("NomeUsuarioLogado", login.Nome);
                  return RedirectToAction("Menu", "Home");
                }
                else
                {
                    TempData["ErrorLogin"] = "E-mail ou Senha inválidos!";
                }
            }         

            return View();
        }

        public IActionResult Index()
        {
            ViewData["HideMenu"] = true;
            return View();
        }

        public IActionResult Error()
        {
            ViewData["HideMenu"] = false;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
