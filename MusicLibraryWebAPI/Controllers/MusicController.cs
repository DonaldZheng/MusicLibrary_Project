using Microsoft.AspNetCore.Mvc;
using MusicLibraryWebAPI.Data;
using MusicLibraryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private ApplicationDbContext _context;
        public MusicController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<MusicController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //GET api/<MusicController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Song id)
        {
            var songId = _context.Songs.Find(id);
            //return songId;
            //return "value";
        }

        // POST api/<MusicController>
        [HttpPost] //insert/add
        public IActionResult Post([FromBody] Song music)
        {
            try
            {
                _context.Songs.Add(music);
                _context.SaveChanges();
                return Ok();
            }
            catch(Exception err)
            {
                return BadRequest(err);
            }
        }

        // PUT api/<MusicController>/5
        [HttpPut("{id}")] //edit/updates existing record
        public IActionResult Put(int id, [FromBody] Song song)
        {
            try
            {
                _context.Songs.Update(song);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        // DELETE api/<MusicController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Song id)
        {
            try
            {
                _context.Songs.Remove(id);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception err)
            {
                return BadRequest(err);            
            }
        }
    }
}
