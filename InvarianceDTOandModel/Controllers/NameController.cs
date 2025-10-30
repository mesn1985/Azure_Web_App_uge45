using Microsoft.AspNetCore.Mvc;
using ValidateTheNameModelBinding.Models;
using ValidateTheNameModelBinding.Util;

namespace ValidateTheNameWebApplication.Controllers
{
    public class NameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new { nameIsValid = false, showNameEvaluation = false });
        }

        [HttpPost]
        public IActionResult ValidateName(PersonDTO person)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new {nameIsValid = false, showNameEvaluation = true });
            }

            //DI intentionally omittede here for clarity
            PersonRepository personRepository = new PersonRepository();

            Person personWithInvariance = new Person(
                new Firstname(person.Firstname),
                new Lastname(person.Lastname)
            );

            personRepository.AddPerson(personWithInvariance);

            return View("Index", new { nameIsValid = true, showNameEvaluation = true });


        }

       
    }
}
