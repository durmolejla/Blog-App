using Blog2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KorisiniciController : ControllerBase
    {
        Blog2.Models.DbBlogContext db = new Blog2.Models.DbBlogContext();//da ne deklariramo novi context u svakoj akciji...

        [HttpGet]
        public IActionResult prikazi_sve_korisnike() 
        {
            List<TblKorisnik> podaci = db.TblKorisniks.OrderByDescending(r => r.IdKorisnika).ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult prikazi_filter_osobe(string ime) //za select po filteru
        {
            List<TblKorisnik> rezultat = db.TblKorisniks.Where(r => r.Ime.Contains(ime)).ToList();
            //select * from  where....
            return Ok(rezultat);
        }

        [HttpPost]
        public IActionResult Unesi([FromBody] TblKorisnik podaci)     //za unos novog podatka
        {

            db.Add(podaci);
            db.SaveChanges();
            return Ok(podaci);
        }


        [HttpDelete("{parametar:int}")]
        public IActionResult Obrisi(int parametar)  //za brisanje po ID
        {
            TblKorisnik rezultat = db.TblKorisniks.Where(r => r.IdKorisnika == parametar).FirstOrDefault();
            //select * from  where....
            if (rezultat == null)
            { return NotFound($"Podatak sa Id = {parametar} nije pronadjen"); }
            else
            {
                db.Remove(rezultat);
                db.SaveChanges();
            }
            return Ok(parametar);
        }


        [HttpGet]
        public IActionResult azurirajUsername(int IDpodatka, string noviUsername)     //za azuriranje po ID
        {

            var rezultat = db.TblKorisniks.Where(r => r.IdKorisnika == IDpodatka).FirstOrDefault();
            //select * from  where....
            if (rezultat == null)
            { return Ok("ne postoji podatak sa tim ID"); }
            else
            {
                rezultat.Username = noviUsername;
                db.SaveChanges();
            }
            return Ok("azurirano");
        }

       
    }



    // // get: api/<korisinicicontroller>
    // [httpget]
    // public ienumerable<string> get()
    // {
    //     return new string[] { "value1", "value2" };
    // }

    // // get api/<korisinicicontroller>/5
    // [httpget("{id}")]
    // public string get(int id)
    // {
    //     return "value";
    // }

    // // post api/<korisinicicontroller>
    // [httppost]
    // public void post([frombody] string value)
    // {
    // }

    // // put api/<korisinicicontroller>/5
    // [httpput("{id}")]
    // public void put(int id, [frombody] string value)
    // {
    // }

    // // delete api/<korisinicicontroller>/5
    // [httpdelete("{id}")]
    // public void delete(int id)
    // {
    // }
    //}
    //}
    //
    //
}