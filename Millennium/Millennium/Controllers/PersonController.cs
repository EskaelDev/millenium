//using Microsoft.AspNetCore.Mvc;
using Millennium.Models;
using Millennium.Persistance;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ModelBinding;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Millennium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository repository;

        public PersonController(IPersonRepository repository)
        {
            this.repository = repository;
        }


        // GET api/<PersonController>/5
        [HttpGet(), FormatFilter]
        public IActionResult GetAll()
        {
            var result = repository.GetAll();
            if (result is null || !result.Any())
            {
                return NoContent();
            }

            return Ok(result);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}.{format}"), FormatFilter]
        public IActionResult Get(Guid id)
        {
            var result = repository.GetById(id);
            if (result is null)
            {
                return NotFound($"Person of id: {id} not found");
            }

            return Ok(result);
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
            {
                var result = repository.Add(person);
                return Created(new Uri($"{Request.Path}/{result.Id}", UriKind.Relative), person);
            }
            return BadRequest();
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            repository.Delete(id);
        }
    }
}
