using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes2.Data;
using SuperHeroes2.Models;

namespace SuperHeroes2.Controllers
{
    public class SuperHeroesController : Controller
    {
        // Member variables
        private ApplicationDbContext _context { get; }

        // constructor
        public SuperHeroesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Member methods
        // GET: SuperHeroes
        public ActionResult Index()
        {
            List<SuperHero> superHeroesList;

            superHeroesList = _context.SuperHeroes.ToList();

            return View(superHeroesList);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                SuperHero superHero = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();

                return View(superHero);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();

            return View(superHero);
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                _context.SuperHeroes.Add(superHero);
                _context.SaveChanges();
        
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                SuperHero superHero = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();

                return View(superHero);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHero superHero)
        {
            if (id != superHero.Id)
                return NotFound();

            try
            {
                _context.Update(superHero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                SuperHero superHero = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();

                return View(superHero);
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: SuperHeroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            if (id != superHero.Id)
                return NotFound();

            try
            {
                _context.SuperHeroes.Remove(superHero);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}