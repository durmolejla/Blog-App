using Blog2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KomentariController : ControllerBase
    {
        Blog2.Models.DbBlogContext db = new Blog2.Models.DbBlogContext();//da ne deklariramo novi context u svakoj akciji...

        [HttpGet]
        public IActionResult prikazi_sve_komentare() //za select svega
        {
            List<TblKomentari> podaci = db.TblKomentaris.OrderByDescending(r => r.IdKomentara).ToList();
            return Ok(podaci);
        }



        [HttpPost]
        public IActionResult Unesi([FromBody] TblKomentari podaci)     //za unos novog podatka
        {

            db.Add(podaci);
            db.SaveChanges();
            return Ok(podaci);
        }

     

        [HttpDelete("{parametar:int}")]
        public IActionResult Obrisi(int parametar)  //za brisanje po ID
        {
            TblKomentari rezultat = db.TblKomentaris.Where(r => r.IdKomentara == parametar).FirstOrDefault();
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
        public IActionResult azurirajSadrzaj(int IDpodatka, string noviSadrzaj)     //za azuriranje po ID
        {

            var rezultat = db.TblKomentaris.Where(r => r.IdKomentara == IDpodatka).FirstOrDefault();
            //select * from  where....
            if (rezultat == null)
            { return Ok("ne postoji podatak sa tim ID"); }
            else
            {
                rezultat.Sadrzaj = noviSadrzaj;
                db.SaveChanges();
            }
            return Ok("azurirano");
        }
    }

}