using Projekat.Models;
using Projekat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Repo
{
    interface IRepoArhiva
    {
        IEnumerable<Osoba> sviPodaciPartial();

        Osoba detaljiOsobe(int id);

        bool sacuvajOsnovnePodatkeZaOsobu(OsobaOsnovni o);

        OsobaOsnovni detaljiOsobeOsnovni(int id);

        int? sacuvajNovuOsobu(OsobaNova o);

        IEnumerable<Telefon> sviTelefoniOsobe(int id);

        bool sacuvajIzmenjeneTelefone(IEnumerable<Telefon> telefoni);

        IEnumerable<Mail> sveAdreseOsobe(int id);

        bool sacuvajIzmenjeneAdrese(IEnumerable<Mail> adrese);

        IEnumerable<PostanskaAdresa> svePostanskeAdreseOsobe(int id);

        bool sacuvajIzmenjenePostanskeAdrese(IEnumerable<PostanskaAdresa> postanskeAdrese);

        IEnumerable<Korisnik> sviKorisnici();

        KorisnikIzmenaNovi korisnikSaId(string id);

        IEnumerable<Uloga> sveUloge();

        bool sacuvajIzmeneKorisnika(KorisnikIzmenaNovi k);

        bool sacuvajNovogKorisnika(KorisnikIzmenaNovi k);

        bool izbrisiTelefonKorisnika(int id, int rednibr);

        bool sacuvajNoviTelefon(Telefon t);

        bool izbrisiZapis(int id);

        bool izbrisiKorisnika(string id);

        bool sacuvajNovuPostanskuAdresu(PostanskaAdresa t);

        bool izbrisiPostanskuAdresuKorisnika(int id, int rednibr);

        bool promeniSliku(int id, string pic);

        bool sacuvajNovuAdresu(Mail adresa);

        bool izbrisiAdresuKorisnika(int id, int rednibr);
    }
}
