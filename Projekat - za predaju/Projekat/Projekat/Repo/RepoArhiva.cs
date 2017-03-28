using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Projekat.Models;
using System.Data.SqlClient;
using Projekat.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Projekat.Repo
{
    public class RepoArhiva : IRepoArhiva
    {
        SqlConnection cn;
        public IEnumerable<OznakaTelefona> sveOznakeTelefona;
        public IEnumerable<OznakaMaila> sveOznakeMaila;
        public IEnumerable<OznakaPostanskeAdrese> sveOznakePostanskeAdrese;

        public IEnumerable<OznakaTelefona> SveOznakeTelefona
        {
            get
            {
                return sveOznakeTelefona;
            }

            set
            {
                sveOznakeTelefona = value;
            }
        }

        public IEnumerable<OznakaMaila> SveOznakeMaila
        {
            get
            {
                return sveOznakeMaila;
            }

            set
            {
                sveOznakeMaila = value;
            }
        }

        public IEnumerable<OznakaPostanskeAdrese> SveOznakePostanskeAdrese
        {
            get
            {
                return sveOznakePostanskeAdrese;
            }

            set
            {
                sveOznakePostanskeAdrese = value;
            }
        }

        public RepoArhiva()
        {
            cn = new SqlConnection(KonString.Konekcija);
            sveOznakeTelefona = oznakeTelefona();
            sveOznakeMaila = oznakeMaila();
            sveOznakePostanskeAdrese = oznakePostanskeAdrese();
        }

        public Osoba detaljiOsobe(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Osoba WHERE Id = @ID", cn);
            cmd.Parameters.AddWithValue("@ID", id);

            Osoba temp = null;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    temp = new Osoba();
                    temp.Id = dr.GetInt32(0);
                    temp.Ime = dr[1].ToString();
                    temp.Prezime = dr[2].ToString();
                    temp.ImeRoditelja = dr[3].ToString();
                    temp.JMBG = dr[4].ToString();
                    temp.DatumRodjenja = dr.GetDateTime(5);
                    temp.MestoRodjenja = dr[6].ToString();
                    temp.OpstinaRodjenja = dr[7].ToString();
                    temp.Pol = dr[8].ToString();
                    temp.BrojLicneKarte = dr[9].ToString();
                    temp.Beleska = dr[10].ToString();
                    temp.Fotografija = dr[11].ToString();
                    temp.BrojeviTelefona = new List<Telefon>();
                    temp.MailAdrese = new List<Mail>();
                    temp.PostanskeAdrese = new List<PostanskaAdresa>();
                }
                dr.Close();

                if (temp == null)
                    return null;
                
                temp.BrojeviTelefona = sviTelefoniOsobe(id);
                
                temp.MailAdrese = sveAdreseOsobe(id);
                
                temp.PostanskeAdrese = svePostanskeAdreseOsobe(id);
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
            
            return temp;

        }

        public IEnumerable<Osoba> sviPodaciPartial()
        {         
            SqlCommand cmd = new SqlCommand("SELECT Id, Ime, Prezime, JMBG, DatumRodjenja, MestoRodjenja, Pol FROM Osoba", cn);

            Osoba temp;
            List<Osoba> povVrednost = new List<Osoba>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp = new Osoba();
                    temp.Id = dr.GetInt32(0);
                    temp.Ime = dr[1].ToString();
                    temp.Prezime = dr[2].ToString();
                    temp.JMBG = dr[3].ToString();
                    temp.DatumRodjenja = dr.GetDateTime(4);
                    temp.MestoRodjenja = dr[5].ToString();
                    temp.Pol = dr[6].ToString();

                    povVrednost.Add(temp);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
            

            return povVrednost;
        }

        private IEnumerable<OznakaTelefona> oznakeTelefona()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM OznakaTelefona", cn);
            List<OznakaTelefona> povVrednost = new List<OznakaTelefona>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                OznakaTelefona temp;

                while (dr.Read())
                {
                    temp = new OznakaTelefona();
                    temp.Id = dr.GetInt32(0);
                    temp.Oznaka = dr[1].ToString();
                    povVrednost.Add(temp);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }

            return povVrednost;

        }

        private IEnumerable<OznakaMaila> oznakeMaila()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM OznakaMaila", cn);
            List<OznakaMaila> povVrednost = new List<OznakaMaila>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                OznakaMaila temp;

                while (dr.Read())
                {
                    temp = new OznakaMaila();
                    temp.Id = dr.GetInt32(0);
                    temp.Oznaka = dr[1].ToString();
                    povVrednost.Add(temp);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }

            return povVrednost;

        }

        private IEnumerable<OznakaPostanskeAdrese> oznakePostanskeAdrese()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM OznakaPostanskeAdrese", cn);
            List<OznakaPostanskeAdrese> povVrednost = new List<OznakaPostanskeAdrese>();
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                OznakaPostanskeAdrese temp;

                while (dr.Read())
                {
                    temp = new OznakaPostanskeAdrese();
                    temp.Id = dr.GetInt32(0);
                    temp.Oznaka = dr[1].ToString();
                    povVrednost.Add(temp);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }

            return povVrednost;

        }

        public bool sacuvajOsnovnePodatkeZaOsobu(OsobaOsnovni o)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Osoba SET JMBG=@JMBG, Ime=@IME, Prezime=@PREZIME, ImeRoditelja=@IMER, DatumRodjenja=@DATRODJ, MestoRodjenja=@MESRODJ, OpstinaRodjenja=@OPSRODJ, Pol=@POL, BrojLicneKarte=@BLK, Beleska=@BEL WHERE Id=@ID", cn);
            cmd.Parameters.AddWithValue("@ID", o.Id);
            cmd.Parameters.AddWithValue("@JMBG", o.JMBG);
            cmd.Parameters.AddWithValue("@IME", o.Ime);
            cmd.Parameters.AddWithValue("@PREZIME", o.Prezime);
            cmd.Parameters.AddWithValue("@IMER", o.ImeRoditelja);
            cmd.Parameters.AddWithValue("@DATRODJ", Convert.ToDateTime( o.DatumRodjenja ));
            cmd.Parameters.AddWithValue("@MESRODJ", o.MestoRodjenja);
            cmd.Parameters.AddWithValue("@OPSRODJ", o.OpstinaRodjenja);
            cmd.Parameters.AddWithValue("@POL", o.Pol);
            cmd.Parameters.AddWithValue("@BLK", o.BrojLicneKarte);
            cmd.Parameters.AddWithValue("@BEL", (object)o.Beleska ?? DBNull.Value);

            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }
            return true;


        }

        public OsobaOsnovni detaljiOsobeOsnovni(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT Id, Ime, Prezime, ImeRoditelja, JMBG, DatumRodjenja, MestoRodjenja, OpstinaRodjenja, Pol, BrojLicneKarte, Beleska, Fotografija FROM Osoba WHERE Id = @ID", cn);
            cmd.Parameters.AddWithValue("@ID", id);

            OsobaOsnovni temp = null;
            try
            {
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    temp = new OsobaOsnovni();
                    temp.Id = dr.GetInt32(0);
                    temp.Ime = dr[1].ToString();
                    temp.Prezime = dr[2].ToString();
                    temp.ImeRoditelja = dr[3].ToString();
                    temp.JMBG = dr[4].ToString();
                    temp.DatumRodjenja = dr.GetDateTime(5).ToShortDateString();
                    temp.MestoRodjenja = dr[6].ToString();
                    temp.OpstinaRodjenja = dr[7].ToString();
                    temp.Pol = dr[8].ToString();
                    temp.BrojLicneKarte = dr[9].ToString();
                    temp.Beleska = dr[10].ToString();
                    temp.Fotografija = dr[11].ToString();
                }
                dr.Close();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }

            if (temp == null)
                return null;

            return temp;
        }

        public int? sacuvajNovuOsobu(OsobaNova o)
        {
            //string sqlQuery = String.Format("Insert into Articles (ArticleTitle, ArticleBody ,PublishDate, ArticleCategoryID) Values('{0}', '{1}', '{2}', {3} );"
            //+"Select @@Identity",article.Title, article.Body, article.PublishDate.ToString("yyyy-MM-dd"), article.CategoryID);
            string upit = "INSERT INTO Osoba(Ime, Prezime, ImeRoditelja, JMBG, DatumRodjenja, MestoRodjenja, OpstinaRodjenja, Pol, BrojLicneKarte, Beleska) VALUES (@IME,@PREZIME,@IMER,@JMBG,@DATRODJ,@MESRODJ,@OPSRODJ,@POL,@BLK,@BEL); Select @@Identity";
            SqlCommand cmd = new SqlCommand(upit, cn);
            cmd.Parameters.AddWithValue("@JMBG", o.JMBG);
            cmd.Parameters.AddWithValue("@IME", o.Ime);
            cmd.Parameters.AddWithValue("@PREZIME", o.Prezime);
            cmd.Parameters.AddWithValue("@IMER", o.ImeRoditelja);
            cmd.Parameters.AddWithValue("@DATRODJ", Convert.ToDateTime(o.DatumRodjenja));
            cmd.Parameters.AddWithValue("@MESRODJ", o.MestoRodjenja);
            cmd.Parameters.AddWithValue("@OPSRODJ", o.OpstinaRodjenja);
            cmd.Parameters.AddWithValue("@POL", o.Pol);
            cmd.Parameters.AddWithValue("@BLK", o.BrojLicneKarte);
            cmd.Parameters.AddWithValue("@BEL", (object)o.Beleska ?? DBNull.Value);
            int id;
            try
            {
                cn.Open();

                id = Convert.ToInt32((decimal) cmd.ExecuteScalar());
                cmd.Parameters.Clear();

                cmd.CommandText =
                    "INSERT INTO BrojeviTelefona(Id, Broj, Lokal, OznakaId) VALUES (@ID, @BROJ, @LOKAL, @OZNID)";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@BROJ", o.Telefon.Broj);
                cmd.Parameters.AddWithValue("@LOKAL", ((object) o.Beleska ?? DBNull.Value));
                cmd.Parameters.AddWithValue("@OZNID", o.Telefon.OznakaTelefona.Id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText = "INSERT INTO MailAdrese(Id, Adresa, OznakaId) VALUES (@ID, @MADRESA, @OZNID)";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@MADRESA", o.Mail.Adresa);
                cmd.Parameters.AddWithValue("@OZNID", o.Mail.OznakaMaila.Id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                cmd.CommandText =
                    "INSERT INTO PostanskeAdrese(Id, Adresa, PostanskiBroj, Grad, OznakaId) VALUES (@ID, @PADRESA, @PBR, @GRAD, @OZNID)";
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@PADRESA", o.PostanskaAdresa.Adresa);
                cmd.Parameters.AddWithValue("@PBR", o.PostanskaAdresa.PostanskiBroj);
                cmd.Parameters.AddWithValue("@GRAD", o.PostanskaAdresa.Grad);
                cmd.Parameters.AddWithValue("@OZNID", o.PostanskaAdresa.OznakaPostanskeAdrese.Id);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                cn.Close();
            }

            return id;
        }

        public IEnumerable<Telefon> sviTelefoniOsobe(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM BrojeviTelefona WHERE Id = @ID", cn);
            cmd.Parameters.AddWithValue("@ID", id);
            List<Telefon> temp = new List<Telefon>();
            Telefon tempTelefon;
            try
            {
                if( cn.State == ConnectionState.Closed )
                    cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tempTelefon = new Telefon();
                    tempTelefon.Id = dr.GetInt32(0);
                    tempTelefon.RedniBr = dr.GetInt32(1);
                    tempTelefon.Broj = dr[2].ToString();
                    tempTelefon.Lokal = dr[3].ToString();
                    tempTelefon.OznakaTelefona = sveOznakeTelefona.First(a => a.Id == dr.GetInt32(4));
                    temp.Add(tempTelefon);
                }
                dr.Close();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
            return temp;
        }

        public bool sacuvajIzmenjeneTelefone(IEnumerable<Telefon> telefoni)
        {
            SqlCommand cmd = new SqlCommand("UPDATE BrojeviTelefona SET Broj=@BROJ, Lokal=@LOKAL, OznakaId=@OID WHERE Id=@ID AND RedniBr=@RB",cn);
            try
            {
                cn.Open();
                foreach (Telefon telefon in telefoni)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@BROJ", telefon.Broj);
                    cmd.Parameters.AddWithValue("@LOKAL", (object) telefon.Lokal ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ID", telefon.Id);
                    cmd.Parameters.AddWithValue("@RB", telefon.RedniBr);
                    cmd.Parameters.AddWithValue("@OID", telefon.OznakaTelefona.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }

            return true;
        }

        public IEnumerable<Mail> sveAdreseOsobe(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM MailAdrese WHERE Id = @ID", cn);
            cmd.Parameters.AddWithValue("@ID", id);
            List<Mail> temp = new List<Mail>();
            Mail tempMail;
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tempMail = new Mail();
                    tempMail.Id = dr.GetInt32(0);
                    tempMail.RedniBr = dr.GetInt32(1);
                    tempMail.Adresa = dr[2].ToString();
                    tempMail.OznakaMaila = sveOznakeMaila.First(a => a.Id == dr.GetInt32(3));
                    temp.Add(tempMail);
                }
                dr.Close();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
            return temp;
        }

        public bool sacuvajIzmenjeneAdrese(IEnumerable<Mail> adrese)
        {
            SqlCommand cmd = new SqlCommand("UPDATE MailAdrese SET Adresa=@ADRESA, OznakaID=@OID WHERE Id=@ID AND RedniBr=@RB", cn);
            try
            {
                cn.Open();
                foreach (Mail adresa in adrese)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ADRESA", adresa.Adresa);
                    cmd.Parameters.AddWithValue("@ID", adresa.Id);
                    cmd.Parameters.AddWithValue("@RB", adresa.RedniBr);
                    cmd.Parameters.AddWithValue("@OID", adresa.OznakaMaila.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }


            return true;
        }

        public IEnumerable<PostanskaAdresa> svePostanskeAdreseOsobe(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM PostanskeAdrese WHERE Id = @ID", cn);
            cmd.Parameters.AddWithValue("@ID", id);
            List<PostanskaAdresa> temp = new List<PostanskaAdresa>();
            PostanskaAdresa tempPostanskaAdresa;
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tempPostanskaAdresa = new PostanskaAdresa();
                    tempPostanskaAdresa.Id = dr.GetInt32(0);
                    tempPostanskaAdresa.RedniBr = dr.GetInt32(1);
                    tempPostanskaAdresa.Adresa = dr[2].ToString();
                    tempPostanskaAdresa.PostanskiBroj = dr[3].ToString();
                    tempPostanskaAdresa.Grad = dr[4].ToString();
                    tempPostanskaAdresa.OznakaPostanskeAdrese =
                    sveOznakePostanskeAdrese.First(a => a.Id == dr.GetInt32(5));
                    temp.Add(tempPostanskaAdresa);
                }
                dr.Close();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
            return temp;
        }

        public bool sacuvajIzmenjenePostanskeAdrese(IEnumerable<PostanskaAdresa> postanskeAdrese)
        {
            SqlCommand cmd = new SqlCommand("UPDATE PostanskeAdrese SET Adresa=@ADRESA, PostanskiBroj=@PB, Grad=@GRAD, OznakaID=@OID WHERE Id=@ID AND RedniBr=@RB", cn);
            try
            {
                cn.Open();
                foreach (PostanskaAdresa adresa in postanskeAdrese)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ADRESA", adresa.Adresa);
                    cmd.Parameters.AddWithValue("@ID", adresa.Id);
                    cmd.Parameters.AddWithValue("@RB", adresa.RedniBr);
                    cmd.Parameters.AddWithValue("@OID", adresa.OznakaPostanskeAdrese.Id);
                    cmd.Parameters.AddWithValue("@PB", adresa.PostanskiBroj);
                    cmd.Parameters.AddWithValue("@GRAD", adresa.Grad);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }


            return true;
        }

        public IEnumerable<Korisnik> sviKorisnici()
        {
            var context = new ApplicationDbContext();

            var allUsers = context.Users.ToList();
            var allRoles = context.Roles.ToList();

            List<Korisnik> sviKorisnici = new List<Korisnik>();

            foreach (var korisnik in allUsers)
            {
                sviKorisnici.Add(new Korisnik { Id = korisnik.Id, UsernameEmail = korisnik.Email, Uloga = allRoles.First(a => a.Id == korisnik.Roles.First().RoleId).Name });
            }

            return sviKorisnici;
        }

        public KorisnikIzmenaNovi korisnikSaId(string id)
        {
            var context = new ApplicationDbContext();

            var trazeni = context.Users.Find(id);

            KorisnikIzmenaNovi povVr = new KorisnikIzmenaNovi { Id  = trazeni.Id, UsernameEmail = trazeni.Email, UlogaId = trazeni.Roles.ToList()[0].RoleId};

            if (trazeni == null)
                return null;

            return povVr;


        }

        public IEnumerable<Uloga> sveUloge()
        {
            var context = new ApplicationDbContext();

            var allRoles = context.Roles.ToList();

            var povVr = new List<Uloga>();

            foreach (var uloga in allRoles)
            {
                povVr.Add(new Uloga {Id = uloga.Id, Ime = uloga.Name});
            }

            return povVr;
        }

        public bool sacuvajIzmeneKorisnika(KorisnikIzmenaNovi k)
        {
            var context = new ApplicationDbContext();
            var korisnik = context.Users.Find(k.Id);

            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            var pom = userManager.RemovePassword(k.Id);
            if (!pom.Succeeded)
                return false;
            pom = userManager.AddPassword(k.Id, k.Password);
            if (!pom.Succeeded)
                return false;

            var allRoles = context.Roles.ToList();
            var trenutniRole = allRoles.First(a => a.Id == korisnik.Roles.First().RoleId  ).Name;           

            pom = userManager.RemoveFromRole(k.Id, trenutniRole);
            if (!pom.Succeeded)
                return false;
            pom = userManager.AddToRole(k.Id, allRoles.First(a => a.Id == k.UlogaId).Name);

            return pom.Succeeded;
            
        }

        public bool sacuvajNovogKorisnika(KorisnikIzmenaNovi k)
        {
            var context = new ApplicationDbContext();
            var allRoles = context.Roles.ToList();

            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());
            var user = new IdentityUser { UserName = k.UsernameEmail, Email = k.UsernameEmail };
            var pom = userManager.Create(user, k.Password);
            if (!pom.Succeeded)
                return false;
            pom = userManager.AddToRole(user.Id, allRoles.First(a => a.Id == k.UlogaId).Name);



            return pom.Succeeded;
        }

        public bool izbrisiTelefonKorisnika(int id, int rednibr)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM BrojeviTelefona WHERE Id=@ID AND RedniBr=@RB", cn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@RB", rednibr);
            try
            {
                cn.Open();
                
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }


            return true;
        }

        public bool sacuvajNoviTelefon(Telefon t)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO BrojeviTelefona(Id, Broj, Lokal, OznakaId) VALUES (@ID, @BROJ, @LOKAL, @OZNID)", cn);
            cmd.Parameters.AddWithValue("@ID", t.Id);
            cmd.Parameters.AddWithValue("@BROJ", t.Broj);
            cmd.Parameters.AddWithValue("@LOKAL", (object)t.Lokal ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@OZNID", t.OznakaTelefona.Id);
            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }


            return true;
        }

        public bool izbrisiZapis(int id) 
        {
            
            SqlCommand cmd = new SqlCommand("DELETE FROM Osoba WHERE Id=@id", cn);
            cmd.Parameters.AddWithValue("@id",id);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                cn.Close();
            }
            return true;
        }

        public bool izbrisiKorisnika(string id)
        {
            var context = new ApplicationDbContext();
            var korisnik = context.Users.Find(id);

            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            var allRoles = context.Roles.ToList();
            var trenutniRole = allRoles.First(a => a.Id == korisnik.Roles.First().RoleId).Name;

            var pom = userManager.RemoveFromRole(id, trenutniRole);
            if (!pom.Succeeded)
                return false;

            var zaBrisanje = userManager.FindById(id);

            pom = userManager.Delete(zaBrisanje);

            return pom.Succeeded;
        }

        public bool sacuvajNovuPostanskuAdresu(PostanskaAdresa t)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO PostanskeAdrese(Id, Adresa, PostanskiBroj, Grad, OznakaId) VALUES (@ID, @ADRESA, @PB, @GRAD, @OZNID)", cn);
            cmd.Parameters.AddWithValue("@ID", t.Id);
            cmd.Parameters.AddWithValue("@ADRESA", t.Adresa);
            cmd.Parameters.AddWithValue("@PB", t.PostanskiBroj);
            cmd.Parameters.AddWithValue("@GRAD", t.Grad);
            cmd.Parameters.AddWithValue("@OZNID", t.OznakaPostanskeAdrese.Id);
            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }


            return true;
        }

        public bool izbrisiPostanskuAdresuKorisnika(int id, int rednibr)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM PostanskeAdrese WHERE Id=@ID AND RedniBr=@RB", cn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@RB", rednibr);
            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }


            return true;
        }

        public bool promeniSliku(int id, string pic)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Osoba SET Fotografija=@FILE WHERE Id=@ID", cn);

            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@FILE", id + pic);

            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }

            return true;
            
        }
        // 14. mart 2017.
        /////////////////////////////////////////////////////////////////////////
        /// 
        /// 

        public bool sacuvajNovuAdresu(Mail adresa)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO MailAdrese(Adresa,OznakaID,Id) VALUES (@ADRESA,@OID,@ID)", cn);
            cmd.Parameters.AddWithValue("@ADRESA", adresa.Adresa);
            cmd.Parameters.AddWithValue("@ID", adresa.Id);
            cmd.Parameters.AddWithValue("@OID", adresa.OznakaMaila.Id);
            
            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }


            return true;
        }

        public bool izbrisiAdresuKorisnika(int id, int rednibr)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM MailAdrese WHERE Id=@ID AND RedniBr=@RB", cn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@RB", rednibr);
            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                cn.Close();
            }


            return true;
        }
    }
}