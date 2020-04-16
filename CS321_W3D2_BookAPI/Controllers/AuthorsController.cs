using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CS321_W3D2_BookAPI.Data;
using CS321_W3D2_BookAPI.Models;
using CS321_W3D2_BookAPI.Services;

namespace CS321_W3D2_BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET: api/Authors
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_authorService.GetAll());
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Author author = _authorService.Get(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Author updateAuthor)
        {
            Author author = _authorService.Update(updateAuthor);
            if (author == null) return NotFound();
            return Ok(author);
        }


        // POST: api/Authors
        [HttpPost]
        public IActionResult Post([FromBody] Author newAuthor)
        {
            try
            {
                // add the new book
                _authorService.Add(newAuthor);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddAuthor", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new book. E.g., /api/books/99, if the new is 99
            return CreatedAtAction("Get", new { Id = newAuthor.Id }, newAuthor);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Author author = _authorService.Get(id);
            if (author == null) return NotFound();
            _authorService.Remove(author);
            return NoContent();
        }

      
    }
}
