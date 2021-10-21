using CRUD.Filmes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Filmes.Controllers
{
    public class FilmesController : Controller
    {
        private readonly Contexto _contexto;

        public FilmesController(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Filmes.ToListAsync());
        }

        [HttpGet]
        public IActionResult CriarFilme()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarFilme(Filme filme)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(filme);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(filme);
        }

        [HttpGet]
        public IActionResult AtualizarFilme(int? id)
        {
            if (id != null)
            {
                Filme filme = _contexto.Filmes.Find(id);
                return View(filme);

            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarFilme(int id, Filme filme)
        {
            //filme.FilmeId = id;

            if (ModelState.IsValid)
            {
                _contexto.Update(filme);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(filme);
        }

        [HttpGet]
        public IActionResult ExcluirFilme(int? id)
        {
            if (id != null)
            {
                Filme filme = _contexto.Filmes.Find(id);
                return View(filme);
            }
            else return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirFilme(int id)
        {

            Filme filme = _contexto.Filmes.Find(id);
            _contexto.Remove(filme);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
