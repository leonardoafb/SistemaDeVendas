using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class PrimeiroCadastroController : Controller
    {
        public IActionResult Index()
        {
            //ViewBag.ListaVendedores = new VendedorModel().ListarTodosVendedores();
            return View();
        }

        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                // ViewBag.Vendedor = new PrimeiroCadastroModel().RetornarPrimeiroCadId(id);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(PrimeiroCadastroModel primeiroCadastro)
        {
            if (ModelState.IsValid)
            {
                primeiroCadastro.Gravar();
                return RedirectToAction("Login", "Home");
            }
            else
            {
                TempData["ErrorCadastro"] = "E-mail ou Senha inválidos!";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

   

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}