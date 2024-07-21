using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaVendedores = new VendedorModel().ListarTodosVendedores();
            return View();
        }

        public IActionResult Senha()
        {
            
            return View();
        }

        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                ViewBag.Vendedor = new VendedorModel().RetornarVendedorId(id);
            }

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(VendedorModel vendedor)
        {
            if (ModelState.IsValid)
            {
                vendedor.Gravar();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirVendedor(int id)
        {
            new VendedorModel().Excluir(id);
            return View();
        }
    }
}
