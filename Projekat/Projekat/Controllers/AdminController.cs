using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projekat.Models;
using Projekat.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat.ViewModels;


namespace Projekat.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        RepoArhiva repoArhiva = new RepoArhiva();

        // GET: Admin
        public ActionResult Index()
        {          
            return View(repoArhiva.sviKorisnici());
        }

        public ActionResult UredjivanjeKorisnika(string id)
        {
            var zaView = repoArhiva.korisnikSaId(id);
            if(zaView==null)
                return HttpNotFound();

            var podaci = new KorisnikIzmenaNoviViewModel
            {
                Korisnik = zaView,
                SveUloge = repoArhiva.sveUloge()
            };

            return View("KorisnikForma", podaci);
        }

        public ActionResult NoviKorisnik()
        {
            var podaci = new KorisnikIzmenaNoviViewModel
            {
                SveUloge = repoArhiva.sveUloge()
            };

            return View(podaci);
        }

        [HttpPost]
        public ActionResult SacuvajKorisnika(KorisnikIzmenaNoviViewModel k)
        {
            if (!ModelState.IsValid)
            {
                KorisnikIzmenaNoviViewModel podaci = new KorisnikIzmenaNoviViewModel
                {
                    Korisnik = k.Korisnik,
                    SveUloge = repoArhiva.sveUloge()
                };
                return View("KorisnikForma", podaci);
            }

            if (repoArhiva.sacuvajIzmeneKorisnika(k.Korisnik)) 
            {
                return RedirectToAction("Index", "Admin");
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult SacuvajNovogKorisnika(KorisnikIzmenaNoviViewModel k)
        {
            var context = new ApplicationDbContext();
            var users = context.Users.Count(a => a.Email == k.Korisnik.UsernameEmail);

            if (!ModelState.IsValid || users!=0)
            {
                KorisnikIzmenaNoviViewModel podaci = new KorisnikIzmenaNoviViewModel
                {
                    Korisnik = k.Korisnik,
                    SveUloge = repoArhiva.sveUloge()
                };
                if (users != 0)
                {
                    ModelState.AddModelError("", "Korisnik sa unetom e-mail adresom već postoji");
                }
                return View("NoviKorisnik", podaci);
            }

            if (repoArhiva.sacuvajNovogKorisnika(k.Korisnik)) 
            {
                return RedirectToAction("Index", "Admin");
            }
            else
                return HttpNotFound();
        }

        public ActionResult IzbrisiKorisnika(string id)
        {
            if (repoArhiva.izbrisiKorisnika(id))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
                return HttpNotFound();
        }


    }
}