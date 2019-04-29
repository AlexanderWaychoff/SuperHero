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
        public ActionResult Index(int id)
        {
            Heroes hero = GetHeroInformation(id);
            List<Heroes> oneHero = new List<Heroes>();
            oneHero.Add(hero);
            return View(oneHero);
        }

        public ActionResult List()
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
                if (ModelState.IsValid)
                {
                    context.Heroes.Add(hero);
                    context.SaveChanges();

                    return RedirectToAction("List");
                }
                else
                {
                    return View(hero);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Edit/5
        public ActionResult Edit(int id)
        {
            bool isDefault = CheckIfHeroIsDefault(id);
            if (isDefault)
            {
                return RedirectToAction("Nope");//add method name
            }
            else
            {
                Heroes hero = GetHeroInformation(id);
                return View(hero);
            }
        }

        // POST: Heroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Heroes hero)
        {
            try
            {
                Heroes oldHero = GetHeroInformation(id);
                context.Entry(oldHero).State = System.Data.Entity.EntityState.Deleted;
                context.Heroes.Add(hero);
                context.SaveChanges();

                return RedirectToAction("List", context.Heroes.ToList());
            }
            catch
            {
                return View();
            }
        }

        // GET: Heroes/Delete/5
        public ActionResult Delete(int id)
        {
            bool isDefault = CheckIfHeroIsDefault(id);
            if(isDefault)
            {
                return RedirectToAction("Nope");//add method name
            }
            else
            {
                Heroes deleteHero = GetHeroInformation(id);
                context.Entry(deleteHero).State = System.Data.Entity.EntityState.Deleted;
                //context.Heroes.Remove(deleteHero);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public Heroes GetHeroInformation(int id)
        {
            Heroes hero = new Heroes();
            hero.heroId = id;

            var heroInformation = (from r in context.Heroes
                                where r.heroId == id
                                select r.heroName).FirstOrDefault();
            hero.heroName = heroInformation.ToString();

            heroInformation = (from r in context.Heroes
                                where r.heroId == id
                                select r.alterEgoName).FirstOrDefault();
            hero.alterEgoName = heroInformation.ToString();

            heroInformation = (from r in context.Heroes
                               where r.heroId == id
                               select r.primaryAbility).FirstOrDefault();
            hero.primaryAbility = heroInformation.ToString();

            heroInformation = (from r in context.Heroes
                               where r.heroId == id
                               select r.secondaryAbility).FirstOrDefault();
            hero.secondaryAbility = heroInformation.ToString();

            heroInformation = (from r in context.Heroes
                               where r.heroId == id
                               select r.catchphrase).FirstOrDefault();
            hero.catchphrase = heroInformation.ToString();

            return hero;
        }

        public bool CheckIfHeroIsDefault(int id)
        {
            Hulk hulk = new Hulk();
            Batman batman = new Batman();
            Goliath goliath = new Goliath();
            OptimusPrime optimusPrime = new OptimusPrime();
            var listedHeroes = (from r in context.Heroes
                                where r.heroId == id
                                select r.heroName).FirstOrDefault();
            if (listedHeroes.ToString() == hulk.heroName || listedHeroes.ToString() == batman.heroName || listedHeroes.ToString() == goliath.heroName || listedHeroes.ToString() == optimusPrime.heroName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // POST: Heroes/Delete/5
        //[HttpPost]
        //public ActionResult Delete(Heroes hero)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here
        //        bool isDefault = CheckIfHeroIsDefault(hero.heroId);
        //        if (isDefault)
        //        {
                    
        //            return RedirectToAction("Nope");//add method name
        //        }
        //        else
        //        {
        //            context.Heroes.Remove(hero);

        //            return RedirectToAction("List");
        //        }
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Nope()
        {
            ViewBag.Message = "This hero too stronk, try the same action on another one.";
            return View();
        }
    }
}
