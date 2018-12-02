using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _200354592API;
using _200354592API.Models;

namespace _200354592API.Controllers
{
    [Produces("application/json")]
    [Route("api/Grades")]
    public class GradesController : Controller
    {
        private readonly grademeter_databaseContext _context;

        public GradesController(grademeter_databaseContext context)
        {
            _context = context;
        }

        // GET: api/Grades
        [HttpGet]
        public IEnumerable<Grades> GetGrades()
        {
            return _context.Grades;
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGrades([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grades = await _context.Grades.SingleOrDefaultAsync(m => m.GradeId == id);

            if (grades == null)
            {
                return NotFound();
            }

            return Ok(grades);
        }

        // PUT: api/Grades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrades([FromRoute] int id, [FromBody] Grades grades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != grades.GradeId)
            {
                return BadRequest();
            }

            _context.Entry(grades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Grades
        [HttpPost]
        public async Task<IActionResult> PostGrades([FromBody] Grades grades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Grades.Add(grades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGrades", new { id = grades.GradeId }, grades);
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrades([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var grades = await _context.Grades.SingleOrDefaultAsync(m => m.GradeId == id);
            if (grades == null)
            {
                return NotFound();
            }

            _context.Grades.Remove(grades);
            await _context.SaveChangesAsync();

            return Ok(grades);
        }

        private bool GradesExists(int id)
        {
            return _context.Grades.Any(e => e.GradeId == id);
        }
    }
}