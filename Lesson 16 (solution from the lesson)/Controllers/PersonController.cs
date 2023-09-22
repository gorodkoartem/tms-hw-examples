using Microsoft.AspNetCore.Mvc;
using Sandbox.Models;
using Sandbox.Services;

namespace Sandbox.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(_personService.GetPersons());
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            _personService.AddPerson(person);
            return Json(person);
        }
    }
}
