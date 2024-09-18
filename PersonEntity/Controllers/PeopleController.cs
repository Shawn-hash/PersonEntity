using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using PersonEntity.Models;

namespace PersonEntity.Controllers
{
    [Route("odata/People")]
    public class PeopleController : ODataController
    {
        private static List<Person> people = new List<Person>
        {
            new Person { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Age = 30, LastModifiedOn = DateTime.UtcNow },
            new Person { Id = Guid.NewGuid(), FirstName = "Jane", LastName = "Doe", Age = 25, LastModifiedOn = DateTime.UtcNow }
        };

        // GET: odata/People
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(people);
        }

        // GET: odata/People(id)
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST: odata/People
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            person.Id = Guid.NewGuid();
            person.LastModifiedOn = DateTime.UtcNow;
            people.Add(person);
            return Created(person);
        }

        // PUT: odata/People(id)
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Person updatedPerson)
        {
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();
            person.FirstName = updatedPerson.FirstName;
            person.LastName = updatedPerson.LastName;
            person.Age = updatedPerson.Age;
            person.LastModifiedOn = DateTime.UtcNow;
            return Updated(person);
        }

        // DELETE: odata/People(id)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var person = people.FirstOrDefault(p => p.Id == id);
            if (person == null) return NotFound();
            people.Remove(person);
            return NoContent();
        }
    }
}
