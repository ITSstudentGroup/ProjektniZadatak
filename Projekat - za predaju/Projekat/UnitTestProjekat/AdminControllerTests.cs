using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Projekat.Controllers;
using Projekat.Models;
using System.Collections.Generic;
using Projekat.Repo;
using System.Linq;
using System.Web.Mvc;
using Projekat.ViewModels;

namespace UnitTestProjekat
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void Index()
        {
            var korisnici = new List<Korisnik>
            {
                new Korisnik {Id = "asdasdqwe123", UsernameEmail = "admin@projekat.com", Uloga = "admin"},
                new Korisnik {Id = "asdasda23we123", UsernameEmail = "editor@projekat.com", Uloga = "editor" },
                new Korisnik {Id = "12dasda23we123", UsernameEmail = "viewer@projekat.com", Uloga = "viewer" }
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sviKorisnici()).Returns(korisnici);
            var ac = new AdminController(repoArhiva.Object);
            // Act 
            var result = ac.Index() as ViewResult;
            var model = result.Model as IEnumerable<Korisnik>;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, model.Count());
            Assert.AreEqual(1, model.Count(a => a.Uloga=="admin"));
            Assert.AreEqual(1, model.Count(a => a.Uloga == "editor"));
            Assert.AreEqual(1, model.Count(a => a.Uloga == "viewer"));
        }

        [TestMethod]
        public void UredjivanjeKorisnika()
        {
            var podaci = new KorisnikIzmenaNoviViewModel
            {
                Korisnik = new KorisnikIzmenaNovi { Id="asdasd23", UsernameEmail = "admin@projekat.com", Password = "P@ssw0rd", UlogaId = "asdasd13"},
                SveUloge = new List<Uloga> { new Uloga { Id= "asdasd13", Ime = "admin"}, new Uloga { Id = "asdasd14", Ime = "editor" }, new Uloga { Id = "asdasd15", Ime = "viewer" } }
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.korisnikSaId("asdasd23")).Returns(podaci.Korisnik);
            repoArhiva.Setup(e => e.sveUloge()).Returns(podaci.SveUloge);
            var ac = new AdminController(repoArhiva.Object);
            // Act 
            var result = ac.UredjivanjeKorisnika("asdasd23") as ViewResult;
            var model = result.Model as KorisnikIzmenaNoviViewModel;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("asdasd13", model.Korisnik.UlogaId);
            Assert.AreEqual(3, model.SveUloge.Count());
        }

        [TestMethod]
        public void NoviKorisnik()
        {
            var podaci = new KorisnikIzmenaNoviViewModel
            {
                SveUloge = new List<Uloga> { new Uloga { Id = "asdasd13", Ime = "admin" }, new Uloga { Id = "asdasd14", Ime = "editor" }, new Uloga { Id = "asdasd15", Ime = "viewer" } }
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sveUloge()).Returns(podaci.SveUloge);
            var ac = new AdminController(repoArhiva.Object);
            // Act 
            var result = ac.NoviKorisnik() as ViewResult;
            var model = result.Model as KorisnikIzmenaNoviViewModel;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(model.Korisnik);
            Assert.AreEqual(3, model.SveUloge.Count());
        }

        [TestMethod]
        public void SacuvajKorisnika()
        {
            var podaci = new KorisnikIzmenaNoviViewModel
            {
                Korisnik = new KorisnikIzmenaNovi { Id = "asdasd23", UsernameEmail = "admin2@projekat.com", Password = "P@ssw0rd123", UlogaId = "asdasd13" },
                SveUloge = new List<Uloga> { new Uloga { Id = "asdasd13", Ime = "admin" }, new Uloga { Id = "asdasd14", Ime = "editor" }, new Uloga { Id = "asdasd15", Ime = "viewer" } }
            };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sveUloge()).Returns(podaci.SveUloge);
            repoArhiva.Setup(e => e.sacuvajIzmeneKorisnika(podaci.Korisnik)).Returns(true);
            var ac = new AdminController(repoArhiva.Object);
            // Act 
            var result = ac.SacuvajKorisnika(podaci) as RedirectToRouteResult;
            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Admin", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void IzbrisiKorisnika()
        {
            
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.izbrisiKorisnika("asdqwe123")).Returns(true);
            var ac = new AdminController(repoArhiva.Object);
            // Act 
            var result = ac.IzbrisiKorisnika("asdqwe123") as RedirectToRouteResult;
            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Admin", result.RouteValues["controller"]);
        }
    }
}
