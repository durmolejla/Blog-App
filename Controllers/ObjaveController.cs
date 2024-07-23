using Microsoft.AspNetCore.Mvc;
using Blog2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Blog2.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ObjaveController : ControllerBase
    {
        private readonly DbBlogContext db;

        public ObjaveController(DbBlogContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult PrikaziSveObjave() // Select all
        {
            var podaci = db.TblObjaves
                .Where(r => r.IdObjave != 0)
                .OrderByDescending(r => r.IdObjave)
                .ToList();

            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult PrikaziUsernameUzObjave() // Select all with usernames
        {
            var podaci = db.VObjaves
                .Where(r => !string.IsNullOrEmpty(r.Username))
                .OrderByDescending(r => r.Username)
                .ToList();

            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult PrikaziFilterObjave(string naslov) // Filter by title
        {
            var rezultat = db.TblObjaves
                .Where(r => !string.IsNullOrEmpty(r.Naslov) && r.Naslov.Contains(naslov))
                .ToList();

            return Ok(rezultat);
        }

        [HttpPost]
        public IActionResult Unesi([FromBody] TblObjave podaci) // Insert new entry
        {
            if (podaci != null)
            {
                db.TblObjaves.Add(podaci);
                db.SaveChanges();
                return Ok(podaci);
            }
            return BadRequest("Podaci cannot be null");
        }

        [HttpDelete("{parametar:int}")]
        public IActionResult Obrisi(int parametar) // Delete by ID
        {
            var rezultat = db.TblObjaves.FirstOrDefault(r => r.IdObjave == parametar);
            if (rezultat == null)
            {
                return NotFound($"Podatak sa Id = {parametar} nije pronađen");
            }

            db.TblObjaves.Remove(rezultat);
            db.SaveChanges();
            return Ok(parametar);
        }

        [HttpPut]
        public IActionResult AzurirajSadrzaj(int IDpodatka, string noviSadrzaj) // Update by ID
        {
            var rezultat = db.TblObjaves.FirstOrDefault(r => r.IdObjave == IDpodatka);
            if (rezultat == null)
            {
                return NotFound("Ne postoji podatak sa tim ID");
            }

            rezultat.Sadrzaj = noviSadrzaj;
            db.SaveChanges();
            return Ok("Azurirano");
        }
    }
}
