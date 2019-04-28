using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class HeroesController : Controller
    {
        ApplicationDbContext context;

        public HeroesController()
        {
            context = new ApplicationDbContext();

            Hulk hulk = new Hulk();
            Batman batman = new Batman();
            Goliath goliath = new Goliath();
            OptimusPrime optimusPrime = new OptimusPrime();
            List<Heroes> initialHeroes = new List<Heroes>();
            initialHeroes.Add(hulk);
            initialHeroes.Add(batman);
            initialHeroes.Add(goliath);
            initialHeroes.Add(optimusPrime);
            CheckInitialHeroes(initialHeroes);
        }

        public void CheckInitialHeroes(List<Heroes> heroes)
        {
            foreach (Heroes hero in heroes)
            {

                var listedHeroes = (from r in context.Heroes
                                   where r.heroName == hero.heroName
                                   select r.heroName).FirstOrDefault();
                if (listedHeroes == null)
                {
                    context.Heroes.Add(hero);
                    context.SaveChanges();
                }

            }
        }
        // GET: Heroes
        public ActionResult Index()
        {
            return View(context.Heroes.ToList());
        }

        // GET: Heroes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Heroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Heroes/Create
        [HttpPost]
        public ActionResult Create(Heroes hero)
        {
            try
            {
                // TODO: Add insert logic here
                context.Heroes.Add(hero);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Heroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Heroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
