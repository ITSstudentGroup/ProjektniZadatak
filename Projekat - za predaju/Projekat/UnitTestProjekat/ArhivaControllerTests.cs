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
using UnitTestProjekat;

namespace UnitTestProjekat
{
    [TestClass]
    public class ArhivaControllerTests
    {
        [TestMethod]
        public void Index()
        {
            var osobe = new List<Osoba>
            {
                new Osoba {JMBG = "9874569631256", Ime = "John", Prezime = "Doe", DatumRodjenja = Convert.ToDateTime("28.02.1995"), MestoRodjenja = "Beograd", Pol = "M"}
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sviPodaciPartial()).Returns(osobe.AsQueryable());
            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.Index() as ViewResult;
            var model = result.Model as IEnumerable<Osoba>;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, model.Count());

        }

        [TestMethod]
        public void Detalji()
        {
            var osoba = new Osoba
            {
                JMBG = "9874569631256",
                Ime = "John",
                Prezime = "Doe",
                DatumRodjenja = Convert.ToDateTime("28.02.1995"),
                MestoRodjenja = "Beograd",
                Pol = "M",
                OpstinaRodjenja = "Savski Venac",
                BrojLicneKarte = "852698452",
                Beleska = "",
                Fotografija = "",
                ImeRoditelja = "Laza",
                BrojeviTelefona = new List<Telefon> { new Telefon { Broj = "060569858", OznakaTelefona = new OznakaTelefona { Oznaka = "Mobilni"} } },
                PostanskeAdrese = new List<PostanskaAdresa> { new PostanskaAdresa { Adresa = "Dusanovac 21", Grad = "Beograd", PostanskiBroj = "11000", OznakaPostanskeAdrese = new OznakaPostanskeAdrese {Oznaka = "Kuca"} } },
                MailAdrese = new List<Mail> { new Mail { Adresa = "posao@adresa.com", OznakaMaila = new OznakaMaila { Oznaka = "Posao"} } }
            };
            
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.detaljiOsobe(1)).Returns(osoba);
            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.Detalji(1) as ViewResult;
            var model = result.Model as Osoba;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);

        }

        [TestMethod]
        public void Sacuvaj()
        {
            var osoba = new OsobaOsnovni
            {
                JMBG = "9874569631256",
                Ime = "John",
                Prezime = "Doe",
                DatumRodjenja = "28.02.1995",
                MestoRodjenja = "Beograd",
                Pol = "M",
                OpstinaRodjenja = "Savski Venac",
                BrojLicneKarte = "189698451",
                Beleska = "",
                Fotografija = "",
                ImeRoditelja = "Laza"
            };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sacuvajOsnovnePodatkeZaOsobu(osoba)).Returns(true);
            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var validationResults = TestModelHelper.Validate(osoba);
            var result = ac.Sacuvaj( new OsobaUredjivanje {Osoba = osoba, Pol = new List<Pol> {new Pol {Prikaz = "Muski", Vrednost = "M"}, new Pol {Prikaz = "Zenski", Vrednost = "Z"} } }, null) as RedirectToRouteResult;
            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void IzmeniOsnovnePodatke()
        {
            var osoba = new OsobaOsnovni
            {
                JMBG = "9874569631256",
                Ime = "John",
                Prezime = "Doe",
                DatumRodjenja = "28.02.1995",
                MestoRodjenja = "Beograd",
                Pol = "M",
                OpstinaRodjenja = "Savski Venac",
                BrojLicneKarte = "889698451",
                Beleska = "",
                Fotografija = "",
                ImeRoditelja = "Laza"
            };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.detaljiOsobeOsnovni(1)).Returns(osoba);
            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.IzmeniOsnovnePodatke(1) as ViewResult;
            // Assert            
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual("OsobaFormaOsnovni", result.ViewName);
        }

        [TestMethod]
        public void SacuvajNovu()
        {
            var osoba = new OsobaNova()
            {
                JMBG = "9874569631256",
                Ime = "John",
                Prezime = "Doe",
                DatumRodjenja = "28.02.1995",
                MestoRodjenja = "Beograd",
                Pol = "M",
                OpstinaRodjenja = "Savski Venac",
                BrojLicneKarte = "852698452",
                Beleska = "",
                Fotografija = "",
                ImeRoditelja = "Laza",
                Telefon =  new Telefon { Broj = "060569858", OznakaTelefona = new OznakaTelefona { Oznaka = "Mobilni" } },
                PostanskaAdresa =  new PostanskaAdresa { Adresa = "Dusanovac 21", Grad = "Beograd", PostanskiBroj = "11000", OznakaPostanskeAdrese = new OznakaPostanskeAdrese { Oznaka = "Kuca" } } ,
                Mail =  new Mail { Adresa = "posao@adresa.com", OznakaMaila = new OznakaMaila { Oznaka = "Posao" } } 
            };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sacuvajNovuOsobu(osoba)).Returns(1);
            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.SacuvajNovu(new OsobaNovaViewModel {Osoba = osoba}, null) as RedirectToRouteResult;
            var validationResultsOsoba = TestModelHelper.Validate(osoba);
            var validationResultsMail = TestModelHelper.Validate(osoba.Mail);
            // Assert            
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
            Assert.AreEqual(0, validationResultsOsoba.Count);
            Assert.AreEqual(0, validationResultsMail.Count);
        }

        [TestMethod]
        public void Nova()
        {

            OsobaNovaViewModel podaci = new OsobaNovaViewModel
            {               
                OznakeTelefona = new List<OznakaTelefona> { new OznakaTelefona { Id=1, Oznaka = "Kuca"} },
                OznakeMaila = new List<OznakaMaila> { new OznakaMaila { Id = 1, Oznaka = "Poslovni" } },
                OznakePostanskeAdrese = new List<OznakaPostanskeAdrese> { new OznakaPostanskeAdrese { Id = 1, Oznaka = "Kuca" } }
            };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.SveOznakeMaila).Returns(podaci.OznakeMaila);
            repoArhiva.Setup(e => e.SveOznakePostanskeAdrese).Returns(podaci.OznakePostanskeAdrese);
            repoArhiva.Setup(e => e.SveOznakeTelefona).Returns(podaci.OznakeTelefona);

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.Nova() as ViewResult;
            var model = result.Model as OsobaNovaViewModel;
            // Assert            
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.IsNotNull(model.OznakeMaila);
            Assert.IsNotNull(model.OznakePostanskeAdrese);
            Assert.IsNotNull(model.OznakeTelefona);
            Assert.AreEqual(1, model.OznakePostanskeAdrese.Count());
            Assert.AreEqual("NovaOsoba", result.ViewName);
        }

        [TestMethod]
        public void IzbrisiTelefon()
        {

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.izbrisiTelefonKorisnika(1, 1)).Returns(true);           

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.IzbrisiTelefon(1, 1) as RedirectToRouteResult;
            // Assert            
            Assert.AreEqual("Telefoni", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [TestMethod]
        public void NoviTelefon()
        {
            var sveOznakeTelefona = new List<OznakaTelefona> {new OznakaTelefona {Id = 1, Oznaka = "Kuca"}};

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.SveOznakeTelefona).Returns(sveOznakeTelefona);

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.NoviTelefon(1) as ViewResult;
            var model = result.Model as TelefoniViewModel;
            // Assert            
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Telefoni.Count());
            Assert.AreEqual(1, model.Telefoni[0].Id);
            Assert.AreEqual(1, model.OznakeTelefona.Count());
        }

        [TestMethod]
        public void Adrese()
        {
            var podaci = new AdreseViewModel
            {
                Adrese = new List<Mail> { new Mail { Adresa = "posao@adresa.com", Id = 1, RedniBr = 1, OznakaMaila = new OznakaMaila { Id=1, Oznaka = "Posao"} } },
                OznakeMaila = new List<OznakaMaila> { new OznakaMaila { Id = 1, Oznaka = "Posao" } }
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sveAdreseOsobe(1)).Returns(podaci.Adrese);
            repoArhiva.Setup(e => e.SveOznakeMaila).Returns(podaci.OznakeMaila);
            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.Adrese(1) as ViewResult;
            var model = result.Model as AdreseViewModel;
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, model.Adrese.Count());
            Assert.AreEqual(1, model.Adrese[0].RedniBr);
        }

        [TestMethod]
        public void SacuvajNoviTelefon()
        {
            var podaci = new TelefoniViewModel
            {
                Telefoni = new List<Telefon> { new Telefon { Broj = "0605896588", Id= 1, OznakaTelefona = new OznakaTelefona { Id = 1, Oznaka = "Kuca"} } },
                OznakeTelefona = new List<OznakaTelefona> { new OznakaTelefona { Id = 1, Oznaka = "Kuca" } }
            };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sacuvajNoviTelefon(podaci.Telefoni[0])).Returns(true);

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.SacuvajNoviTelefon(podaci) as RedirectToRouteResult;
            // Assert            
            Assert.AreEqual("Telefoni", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [TestMethod]
        public void Telefoni()
        {

            var podaci = new TelefoniViewModel
            {
                Telefoni = new List<Telefon> { new Telefon { Broj = "0611922809", Id = 1, Lokal = "23", RedniBr = 1 } },
                OznakeTelefona = new List<OznakaTelefona> { new OznakaTelefona { Id = 1, Oznaka = "Mobilni" } }
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sviTelefoniOsobe(1)).Returns(podaci.Telefoni);
            repoArhiva.Setup(e => e.SveOznakeTelefona).Returns(podaci.OznakeTelefona);
            ArhivaController ac = new ArhivaController(repoArhiva.Object);
            var result = ac.Telefoni(1) as ViewResult;
            var model = result.Model as TelefoniViewModel;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Telefoni.Count());
            Assert.AreEqual(1, model.Telefoni[0].RedniBr);
        }

        [TestMethod]
        public void SacuvajIzmeneAdresa()
        {

            AdreseViewModel podaci = new AdreseViewModel
            {
                Adrese = new List<Mail> { new Mail { Adresa = "posao@adresa.com", Id = 1, RedniBr = 1, OznakaMaila = new OznakaMaila { Id = 1, Oznaka = "Posao" } } },
                OznakeMaila = new List<OznakaMaila> { new OznakaMaila { Id = 1, Oznaka = "Posao" } }

            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sacuvajIzmenjeneAdrese(podaci.Adrese)).Returns(true);
            repoArhiva.Setup(e => e.SveOznakeMaila).Returns(podaci.OznakeMaila);
            ArhivaController ac = new ArhivaController(repoArhiva.Object);
            var result = ac.SacuvajIzmeneAdresa(podaci) as RedirectToRouteResult;
            Assert.AreEqual("Adrese", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void SacuvajIzmeneTelefona()
        {

            TelefoniViewModel podaci = new TelefoniViewModel
            {
                Telefoni = new List<Telefon> { new Telefon { Broj = "0612924809", Id = 1, Lokal = "asd", RedniBr = 1 } },
                OznakeTelefona = new List<OznakaTelefona> { new OznakaTelefona { Id = 1, Oznaka = "Mobilni" } }

            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sacuvajIzmenjeneTelefone(podaci.Telefoni)).Returns(true);
            repoArhiva.Setup(e => e.SveOznakeTelefona).Returns(podaci.OznakeTelefona);
            ArhivaController ac = new ArhivaController(repoArhiva.Object);
            var result = ac.SacuvajIzmeneTelefona(podaci) as RedirectToRouteResult;
            Assert.AreEqual("Telefoni", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void PostanskeAdrese()
        {

            var podaci = new PostanskeAdreseViewModel
            {
                PostanskeAdrese = new List<PostanskaAdresa> { new PostanskaAdresa { Adresa = "Nemanjina 22", Grad = "Beograd", Id = 1, PostanskiBroj = "1190", RedniBr = 1 } },
                OznakePostanskeAdrese = new List<OznakaPostanskeAdrese> { new OznakaPostanskeAdrese { Id = 1, Oznaka = "Kucna" } }
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.svePostanskeAdreseOsobe(1)).Returns(podaci.PostanskeAdrese);
            repoArhiva.Setup(e => e.SveOznakePostanskeAdrese).Returns(podaci.OznakePostanskeAdrese);
            ArhivaController ac = new ArhivaController(repoArhiva.Object);
            var result = ac.PostanskeAdrese(1) as ViewResult;
            var model = result.Model as PostanskeAdreseViewModel;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.PostanskeAdrese.Count());
            Assert.AreEqual(1, model.PostanskeAdrese[0].RedniBr);
        }

        [TestMethod]
        public void SacuvajIzmenePostanskihAdresa()
        {

            PostanskeAdreseViewModel podaci = new PostanskeAdreseViewModel
            {
                PostanskeAdrese = new List<PostanskaAdresa> { new PostanskaAdresa { Adresa = "Nemanjina 22", Grad = "Beograd", Id = 1, PostanskiBroj = "1190", RedniBr = 1 } },
                OznakePostanskeAdrese = new List<OznakaPostanskeAdrese> { new OznakaPostanskeAdrese { Id = 1, Oznaka = "Kucna" } }
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sacuvajIzmenjenePostanskeAdrese(podaci.PostanskeAdrese)).Returns(true);
            repoArhiva.Setup(e => e.SveOznakePostanskeAdrese).Returns(podaci.OznakePostanskeAdrese);
            ArhivaController ac = new ArhivaController(repoArhiva.Object);
            var result = ac.SacuvajIzmenePostanskihAdresa(podaci) as RedirectToRouteResult;
            Assert.AreEqual("PostanskeAdrese", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void izbrisiZapis()
        {
            var osoba = new Osoba
            {
                Id = 1,
                JMBG = "9874569631256",
                Ime = "John",
                Prezime = "Doe",
                DatumRodjenja = Convert.ToDateTime("28.02.1995"),
                MestoRodjenja = "Beograd",
                Pol = "M",
                OpstinaRodjenja = "Savski Venac",
                BrojLicneKarte = "852698452",
                Beleska = "",
                Fotografija = "",
                ImeRoditelja = "Laza",
                BrojeviTelefona = new List<Telefon> { new Telefon { Broj = "060569858", OznakaTelefona = new OznakaTelefona { Oznaka = "Mobilni" } } },
                PostanskeAdrese = new List<PostanskaAdresa> { new PostanskaAdresa { Adresa = "Dusanovac 21", Grad = "Beograd", PostanskiBroj = "11000", OznakaPostanskeAdrese = new OznakaPostanskeAdrese { Oznaka = "Kuca" } } },
                MailAdrese = new List<Mail> { new Mail { Adresa = "posao@adresa.com", OznakaMaila = new OznakaMaila { Oznaka = "Posao" } } }
            };
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.detaljiOsobe(1)).Returns(osoba);
            repoArhiva.Setup(e => e.izbrisiZapis(1)).Returns(true);
            ArhivaController ac = new ArhivaController(repoArhiva.Object);
            var result = ac.izbrisiZapis(1) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
        }

        [TestMethod]
        public void SacuvajNovuPostanskuAdresu()
        {
            PostanskeAdreseViewModel podaci = new PostanskeAdreseViewModel
            {
                PostanskeAdrese = new List<PostanskaAdresa> { new PostanskaAdresa { Adresa = "Nemanjina 22", Grad = "Beograd", Id = 1, PostanskiBroj = "1190" } },
                OznakePostanskeAdrese = new List<OznakaPostanskeAdrese> { new OznakaPostanskeAdrese { Id = 1, Oznaka = "Kucna" } }
            };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sacuvajNovuPostanskuAdresu(podaci.PostanskeAdrese[0])).Returns(true);

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.SacuvajNovuPostanskuAdresu(podaci) as RedirectToRouteResult;
            // Assert            
            Assert.AreEqual("PostanskeAdrese", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [TestMethod]
        public void IzbrisiPostanskuAdresu()
        {

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.izbrisiPostanskuAdresuKorisnika(1, 1)).Returns(true);

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.IzbrisiPostanskuAdresu(1, 1) as RedirectToRouteResult;
            // Assert            
            Assert.AreEqual("PostanskeAdrese", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [TestMethod]
        public void NovaAdresa()
        {
            var sveOznakeAdresa = new List<OznakaMaila> { new OznakaMaila { Id = 1, Oznaka = "Posao" } };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.SveOznakeMaila).Returns(sveOznakeAdresa);

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.NovaAdresa(1) as ViewResult;
            var model = result.Model as AdreseViewModel;
            // Assert            
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Adrese.Count());
            Assert.AreEqual(1, model.Adrese[0].Id);
            Assert.AreEqual(1, model.OznakeMaila.Count());
        }

        [TestMethod]
        public void SacuvajNovuAdresu()
        {
            AdreseViewModel podaci = new AdreseViewModel
            {
                Adrese = new List<Mail> { new Mail { Adresa = "posao@adresa.com", Id = 1, OznakaMaila = new OznakaMaila { Id = 1, Oznaka = "Posao" } } },
                OznakeMaila = new List<OznakaMaila> { new OznakaMaila { Id = 1, Oznaka = "Posao" } }
            };

            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.sacuvajNovuAdresu(podaci.Adrese[0])).Returns(true);

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.SacuvajNovuAdresu(podaci) as RedirectToRouteResult;
            // Assert            
            Assert.AreEqual("Adrese", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }

        [TestMethod]
        public void IzbrisiAdresu()
        {
            var repoArhiva = new Mock<IRepoArhiva>();
            repoArhiva.Setup(e => e.izbrisiAdresuKorisnika(1, 1)).Returns(true);

            var ac = new ArhivaController(repoArhiva.Object);
            // Act 
            var result = ac.IzbrisiAdresu(1, 1) as RedirectToRouteResult;
            // Assert            
            Assert.AreEqual("Adrese", result.RouteValues["action"]);
            Assert.AreEqual("Arhiva", result.RouteValues["controller"]);
            Assert.AreEqual(1, result.RouteValues["id"]);
        }
    }
}
