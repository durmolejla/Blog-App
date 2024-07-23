using Blog2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LajkoviController : ControllerBase
    {
        private readonly DbBlogContext _db;

        public LajkoviController(DbBlogContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Spremi([FromBody] TblLajkovi lajk)
        {
            _db.TblLajkovis.Add(lajk);
            _db.SaveChanges();
            return Ok(lajk);
        }

        [HttpGet]
        public IActionResult prikazi_ukupan_broj_lajkova()
        {
            int ukupanBrojLajkova = _db.TblLajkovis.Count();
            return Ok(new { UkupanBrojLajkova = ukupanBrojLajkova });
        }

        [HttpGet]
        public IActionResult prikazi_korisnike_koji_su_lajkali()
        {
            var korisniciKojiSuLajkali = _db.TblLajkovis
                .Join(_db.TblKorisniks,
                      lajk => lajk.IdKorisnika,
                      korisnik => korisnik.IdKorisnika,
                      (lajk, korisnik) => new { korisnik.IdKorisnika, korisnik.Username })
                .Distinct()
                .ToList();

            return Ok(korisniciKojiSuLajkali);
        }

        [HttpDelete("{parametar:int}")]
        public IActionResult Obrisi(int parametar)
        {
            var rezultat = _db.TblLajkovis.FirstOrDefault(r => r.IdLike == parametar);
            if (rezultat == null)
            {
                return NotFound($"Podatak sa Id = {parametar} nije pronadjen");
            }
            else
            {
                _db.Remove(rezultat);
                _db.SaveChanges();
            }
            return Ok(parametar);
        }
    }
}
