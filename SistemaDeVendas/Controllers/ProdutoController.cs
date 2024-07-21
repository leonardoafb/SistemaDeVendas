using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVendas.Models;

namespace SistemaDeVendas.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListaProdutos = new ProdutoModel().ListarTodosProdutos();
            return View();
        }

        public IActionResult Cadastro(int? id)
        {
            if (id != null)
            {
                ViewBag.Produto = new ProdutoModel().RetornarProdutoId(id);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                produto.Gravar();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Excluir(int id)
        {
            ViewData["IdExcluir"] = id;
            return View();
        }

        public IActionResult ExcluirProduto(int id)
        {
            new ProdutoModel().Excluir(id);
            return View();
        }
    }
}
