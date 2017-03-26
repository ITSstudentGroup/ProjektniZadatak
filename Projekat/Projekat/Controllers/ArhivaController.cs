using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using Projekat.ViewModels;
using Projekat.Repo;
using Projekat.Models;

namespace Projekat.Controllers
{
    [Authorize]
    public class ArhivaController : Controller
    {
        RepoArhiva repoArhiva = new RepoArhiva();


        // GET: Arhiva
        public ActionResult Index()
        {       
            return View(repoArhiva.sviPodaciPartial());
        }

        // GET: Arhiva/Detalji/{id}
        public ActionResult Detalji(int id)
        {
            Osoba zaView = repoArhiva.detaljiOsobe(id);

            if (zaView != null)
                return View(zaView);
            else
                return HttpNotFound();

        }

        [HttpPost]
        [Authorize(Roles = "editor, admin")]
        public ActionResult Sacuvaj(OsobaUredjivanje o, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                OsobaUredjivanje podaci = new OsobaUredjivanje
                {
                    Osoba = o.Osoba,
                    Pol = new List<Pol> { new Pol { Prikaz="Muški", Vrednost="M"}, new Pol { Prikaz = "Ženski", Vrednost = "Z" } }
                };
                return View("OsobaFormaOsnovni", podaci);

            }


            if (file != null)
            {
                
                string pic = System.IO.Path.GetExtension(file.FileName);

                if (pic == ".jpg" || pic == ".jpeg")
                {
                    
                    file.SaveAs(HttpContext.Server.MapPath("~/slike/") + o.Osoba.Id + pic);
                    
                    if (!repoArhiva.promeniSliku(o.Osoba.Id, pic))
                    {
                        return HttpNotFound();
                    }
                }
            }



            if (repoArhiva.sacuvajOsnovnePodatkeZaOsobu(o.Osoba))
            {                
                return RedirectToAction("Index", "Arhiva");
            }
            else
                return HttpNotFound();   
        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult IzmeniOsnovnePodatke(int id)
        {
            OsobaOsnovni trenutni = repoArhiva.detaljiOsobeOsnovni(id);

            if (trenutni == null)
                return HttpNotFound();

            OsobaUredjivanje podaci = new OsobaUredjivanje
            {
                Osoba = trenutni,
                Pol = new List<Pol> { new Pol { Prikaz = "Muški", Vrednost = "M" }, new Pol { Prikaz = "Ženski", Vrednost = "Z" } }
            };

            return View("OsobaFormaOsnovni", podaci);
        }

        [HttpPost]
        [Authorize(Roles = "editor, admin")]
        public ActionResult SacuvajNovu(OsobaNovaViewModel o, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                OsobaNovaViewModel podaci = new OsobaNovaViewModel
                {
                    Osoba = o.Osoba,
                    Pol = new List<Pol> { new Pol { Prikaz = "Muški", Vrednost = "M" }, new Pol { Prikaz = "Ženski", Vrednost = "Z" } },
                    OznakeTelefona = repoArhiva.sveOznakeTelefona,
                    OznakeMaila = repoArhiva.sveOznakeMaila,
                    OznakePostanskeAdrese = repoArhiva.sveOznakePostanskeAdrese
                };
                return View("NovaOsoba", podaci); 
            }

            int? id = repoArhiva.sacuvajNovuOsobu(o.Osoba);


            if (id == null) 
                return HttpNotFound();
                      

            if (file != null)
            {

                //string pic = System.IO.Path.GetFileName(file.FileName);
                string pic = System.IO.Path.GetExtension(file.FileName);

                if (pic == ".jpg" || pic == ".jpeg")
                {

                    file.SaveAs(HttpContext.Server.MapPath("~/slike/") + id + pic);

                    if (!repoArhiva.promeniSliku(id.Value, pic))
                    {
                        return HttpNotFound();
                    }
                }
            }

            return RedirectToAction("Index", "Arhiva");
        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult Nova()
        {
            OsobaNovaViewModel podaci = new OsobaNovaViewModel
            {
                Osoba = new OsobaNova { Id = 1},
                Pol = new List<Pol> { new Pol { Prikaz = "Muški", Vrednost = "M" }, new Pol { Prikaz = "Ženski", Vrednost = "Z" } },
                OznakeTelefona = repoArhiva.sveOznakeTelefona,
                OznakeMaila = repoArhiva.sveOznakeMaila,
                OznakePostanskeAdrese = repoArhiva.sveOznakePostanskeAdrese
            };


            return View("NovaOsoba", podaci);
        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult Telefoni(int id)
        {
            var zaView = new TelefoniViewModel
            {
                Telefoni = repoArhiva.sviTelefoniOsobe(id).ToList(),
                OznakeTelefona = repoArhiva.sveOznakeTelefona
            };

            if (zaView.Telefoni == null || zaView.Telefoni.Count == 0)
                return HttpNotFound();

            return View(zaView);
        }

        [HttpPost]
        [Authorize(Roles = "editor, admin")]
        public ActionResult SacuvajIzmeneTelefona(TelefoniViewModel o)
        {
            if (!ModelState.IsValid)
            {
                TelefoniViewModel podaci = new TelefoniViewModel
                {
                    Telefoni = o.Telefoni,
                    OznakeTelefona = repoArhiva.sveOznakeTelefona
                };
                return View("Telefoni", podaci);
            }

            if (repoArhiva.sacuvajIzmenjeneTelefone(o.Telefoni))
            {
                return RedirectToAction("Telefoni", "Arhiva", new { id = o.Telefoni[0].Id} );
            }
            else
                return HttpNotFound();
        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult Adrese(int id)
        {
            var zaView = new AdreseViewModel
            {
                Adrese = repoArhiva.sveAdreseOsobe(id).ToList(),
                OznakeMaila = repoArhiva.sveOznakeMaila
            };

            if (zaView.Adrese == null || zaView.Adrese.Count==0)
                return HttpNotFound();

            return View(zaView);
        }

        [HttpPost]
        [Authorize(Roles = "editor, admin")]
        public ActionResult SacuvajIzmeneAdresa(AdreseViewModel o)
        {
            if (!ModelState.IsValid)
            {
                AdreseViewModel podaci = new AdreseViewModel
                {
                    Adrese = o.Adrese,
                    OznakeMaila = repoArhiva.sveOznakeMaila
                };
                return View("Adrese", podaci);
            }

            if (repoArhiva.sacuvajIzmenjeneAdrese(o.Adrese))
            {
                return RedirectToAction("Adrese", "Arhiva", new { id = o.Adrese[0].Id });
            }
            else
                return HttpNotFound();
        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult PostanskeAdrese(int id)
        {
            var zaView = new PostanskeAdreseViewModel
            {
                PostanskeAdrese = repoArhiva.svePostanskeAdreseOsobe(id).ToList(),
                OznakePostanskeAdrese = repoArhiva.sveOznakePostanskeAdrese
            };

            if (zaView.PostanskeAdrese == null || zaView.PostanskeAdrese.Count == 0)
                return HttpNotFound();

            return View(zaView);
        }

        [HttpPost]
        [Authorize(Roles = "editor, admin")]
        public ActionResult SacuvajIzmenePostanskihAdresa(PostanskeAdreseViewModel o)
        {
            if (!ModelState.IsValid)
            {
                PostanskeAdreseViewModel podaci = new PostanskeAdreseViewModel
                {
                    PostanskeAdrese = o.PostanskeAdrese,
                    OznakePostanskeAdrese = repoArhiva.sveOznakePostanskeAdrese
                };
                return View("PostanskeAdrese", podaci);
            }

            if (repoArhiva.sacuvajIzmenjenePostanskeAdrese(o.PostanskeAdrese))
            {
                return RedirectToAction("PostanskeAdrese", "Arhiva", new { id = o.PostanskeAdrese[0].Id });
            }
            else
                return HttpNotFound();
        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult IzbrisiTelefon(int id, int rednibr)
        {
            
            if (repoArhiva.izbrisiTelefonKorisnika(id, rednibr))
            {
                return RedirectToAction("Telefoni", "Arhiva", new { id = id });
            }
            else
                return HttpNotFound();
      
        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult NoviTelefon(int id)
        {
            List<Telefon> lista = new List<Telefon>();
            lista.Add(new Telefon { Id = id , OznakaTelefona = new OznakaTelefona() });
            var zaView = new TelefoniViewModel
            {
                Telefoni = lista,
                OznakeTelefona = repoArhiva.sveOznakeTelefona
            };

            return View(zaView);
        }

        [HttpPost]
        [Authorize(Roles = "editor, admin")]
        public ActionResult SacuvajNoviTelefon(TelefoniViewModel o)
        {
            if (!ModelState.IsValid)
            {
                TelefoniViewModel podaci = new TelefoniViewModel
                {
                    Telefoni = o.Telefoni,
                    OznakeTelefona = repoArhiva.sveOznakeTelefona
                };
                return View("NoviTelefon", podaci);
            }

            if (repoArhiva.sacuvajNoviTelefon(o.Telefoni[0]))
            {
                return RedirectToAction("Telefoni", "Arhiva", new { id = o.Telefoni[0].Id });
            }
            else
                return HttpNotFound();


        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult izbrisiZapis(int id) // Ovo je radio Boss :)
        {
           
            if(repoArhiva.detaljiOsobe(id).Fotografija != "")
                System.IO.File.Delete(HttpContext.Server.MapPath("~/slike/") + repoArhiva.detaljiOsobeOsnovni(id).Fotografija);


            repoArhiva.izbrisiZapis(id);
         
            return RedirectToAction("Index", "Arhiva");
        }

        //SVE POSLE OVOGA DODATO 14. marta u Comtrade-u
        //Takodje dodat novi view NovaPostanskaAdresa
        //I u IRepoArhiva i RepoArhiva metode vezane za Postanske adrese i to:
        //sacuvajNovuPostanskuAdresu i izbrisiPostanskuAdresuKorisnika
        [Authorize(Roles = "editor, admin")]
        public ActionResult NovaPostanskaAdresa(int id)
        {
            List<PostanskaAdresa> lista = new List<PostanskaAdresa>();
            lista.Add(new PostanskaAdresa { Id = id, OznakaPostanskeAdrese = new OznakaPostanskeAdrese() });
            var zaView = new PostanskeAdreseViewModel
            {
                PostanskeAdrese = lista,
                OznakePostanskeAdrese = repoArhiva.sveOznakePostanskeAdrese
            };

            return View(zaView);
        }

        [HttpPost]
        [Authorize(Roles = "editor, admin")]
        public ActionResult SacuvajNovuPostanskuAdresu(PostanskeAdreseViewModel o)
        {
            if (!ModelState.IsValid)
            {
                PostanskeAdreseViewModel podaci = new PostanskeAdreseViewModel
                {
                    PostanskeAdrese = o.PostanskeAdrese,
                    OznakePostanskeAdrese = repoArhiva.sveOznakePostanskeAdrese
                };
                return View("NovaPostanskaAdresa", podaci);
            }

            if (repoArhiva.sacuvajNovuPostanskuAdresu(o.PostanskeAdrese[0]))
            {
                return RedirectToAction("PostanskeAdrese", "Arhiva", new { id = o.PostanskeAdrese[0].Id });
            }
            else
                return HttpNotFound();


        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult IzbrisiPostanskuAdresu(int id, int rednibr)
        {
            if (repoArhiva.izbrisiPostanskuAdresuKorisnika(id, rednibr))
            {
                return RedirectToAction("PostanskeAdrese", "Arhiva", new { id = id });
            }
            else
                return HttpNotFound();
        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult NovaAdresa(int id)
        {
            List<Mail> lista = new List<Mail>();
            lista.Add(new Mail { Id = id, OznakaMaila = new OznakaMaila() });
            var zaView = new AdreseViewModel
            {
                Adrese = lista,
                OznakeMaila = repoArhiva.sveOznakeMaila
            };

            return View(zaView);
        }

        [HttpPost]
        [Authorize(Roles = "editor, admin")]
        public ActionResult SacuvajNovuAdresu(AdreseViewModel o)
        {
            if (!ModelState.IsValid)
            {
                AdreseViewModel podaci = new AdreseViewModel
                {
                    Adrese = o.Adrese,
                    OznakeMaila = repoArhiva.sveOznakeMaila
                };
                return View("NovaAdresa", podaci);
            }

            if (repoArhiva.sacuvajNovuAdresu(o.Adrese[0]))
            {
                return RedirectToAction("Adrese", "Arhiva", new { id = o.Adrese[0].Id });
            }
            else
                return HttpNotFound();

        }

        [Authorize(Roles = "editor, admin")]
        public ActionResult IzbrisiAdresu(int id, int rednibr)
        {
            if (repoArhiva.izbrisiAdresuKorisnika(id, rednibr))
            {
                return RedirectToAction("Adrese", "Arhiva", new { id = id });
            }
            else
                return HttpNotFound();
        }
    }

}
