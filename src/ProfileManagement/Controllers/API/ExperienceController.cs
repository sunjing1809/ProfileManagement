using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProfileManagement.Repositories;
using ProfileManagement.Models;
using ProfileManagement.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProfileManagement.Controllers.API
{
    [Route("api/[controller]")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceRepository repo;

        // Constructor Dependency Injection  
        public ExperienceController(IExperienceRepository experienceRepository)
        {
            repo = experienceRepository;
        }

        // GET: api/experience
        [HttpGet]
        public IActionResult Get()
        {
            var list = repo.GetExperience(); 
            return new ObjectResult(list);
        }

        // GET api/experience/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (repo.isNewExperience(id))
            {
                return NoContent();
            }

            var experience = repo.GetExperience(id);     
            return new ObjectResult(experience);
        }

        // POST api/experience
        [HttpPost]
        [Produces(typeof(ExperienceViewModel))]
        public IActionResult Post([FromBody]ExperienceViewModel experienceViewModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (experienceViewModel.Id != repo.GetMaxId() + 1)
                {
                    return BadRequest();
                }

                repo.CreateExperience(experienceViewModel);
                return CreatedAtAction("Get", experienceViewModel);
            }
            
        }

        // PUT api/experience/5  
        [HttpPut("{id}")]
        [Produces(typeof(ExperienceViewModel))]
        public IActionResult Put(int id, [FromBody]ExperienceViewModel experienceViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                if (experienceViewModel == null || experienceViewModel.Id != id || repo.isNewExperience(id))
                {
                    return BadRequest(ModelState);
                }

                 repo.UpdateExperience(experienceViewModel);
                 return new NoContentResult();                                  
            }
        }

        // DELETE api/experience/5  
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (repo.isNewExperience(id))
            {
                return NoContent();
            }

            repo.DeleteExperience(id);
            return new OkResult();
        }
    }
}