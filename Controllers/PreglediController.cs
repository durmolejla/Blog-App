using Blog2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blog2.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class PreglediController : ControllerBase
        {
            private readonly DbBlogContext _db;

            public PreglediController(DbBlogContext db)
            {
                _db = db;
            }
        [HttpGet("UkupanBrojPregleda")]
        public IActionResult UkupanBrojPregleda()
        {
            try
            {
                int ukupanBrojPregleda = _db.TblObjaves.Sum(o => o.BrojPregleda.GetValueOrDefault());
                return Ok(new { UkupanBrojPregleda = ukupanBrojPregleda });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error: " + ex.Message);
            }
        }


        [HttpPut("Povecaj/{id}")]
            public IActionResult Povecaj(int id)
            {
                var post = _db.TblObjaves.Find(id);
                if (post == null)
                {
                    return NotFound();
                }

                post.BrojPregleda++;
                _db.SaveChanges();

                return Ok(new { brojPregleda = post.BrojPregleda });
            }
        }
    }
