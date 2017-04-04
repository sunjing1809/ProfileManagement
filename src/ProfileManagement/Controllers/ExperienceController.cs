using Microsoft.AspNetCore.Mvc;
using ProfileManagement.ViewModels;
using ProfileManagement.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProfileManagement.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceRepository repo;

        // Constructor Dependency Injection
        public ExperienceController(IExperienceRepository experienceRepository)
        {
            repo = experienceRepository;
        }

        // This method is called to list the specific experience by passing Id in URL.
        [HttpGet]
        public IActionResult GetExperience(int Id)
        {
            var experience = repo.GetExperience(Id);
            var experienceViewModel = new ExperienceViewModel();
            if (experience != null)
            {
                experienceViewModel.Id = experience.Id;
                experienceViewModel.JobName = experience.JobName;
                experienceViewModel.CompanyName = experience.CompanyName;
                experienceViewModel.JobDescription = experience.JobDescription;
            }

            return View(experienceViewModel);
        }

        // This method is called to list all experience in database system.
        [HttpGet]
        public IActionResult GetAllExperience()
        {
            var experienceListViewModel = new ExperienceListViewModel { Experience = repo.GetExperience() };
            return View(experienceListViewModel);
        }

        // This method is called when user want to add a new experience by click "Add Experience" button, 
        // then it will show a form to collect all the information about Experience
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View("ExperienceForm");
        }

        // This method is called when user finish filling the form which is for adding new experience or editing existing experience
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveExperience(ExperienceViewModel experienceViewModel)
        {
            // If all the data validation is passed, then ModelState is valid
            if (ModelState.IsValid)
            {
                // Check if the experience passed in is new experience, then add it into database system
                if (repo.isNewExperience(experienceViewModel.Id))
                {
                    repo.CreateExperience(experienceViewModel);
                    return RedirectToAction("GetAllExperience");
                }
                // Check if the experience passed in is existing experience, then update it in database system
                else
                {
                    repo.UpdateExperience(experienceViewModel);
                    return RedirectToAction("GetAllExperience");
                }
            }

            // If the data validation is not passed, bring user back to ExperienceForm view to let them fill again
            return View("ExperienceForm", experienceViewModel);

        }

        // This method is called when user want to edit the specific experience
        [HttpGet]
        public IActionResult EditExperience(int Id)
        {
            // Get the edited ExperienceViewModel by passing the Id
            var experience = repo.GetExperienceModel(Id);

            // If the edited experience is existing experience, then pass the view model to the ExperienceForm view
            if (experience != null)
            {
                var experienceViewModel = new ExperienceViewModel();
                experienceViewModel.Id = experience.Id;
                experienceViewModel.JobName = experience.JobName;
                experienceViewModel.CompanyName = experience.CompanyName;
                experienceViewModel.JobDescription = experience.JobDescription;

                return View("ExperienceForm", experienceViewModel);
            }
            // If the edited experience is not an existing experience, then bring user back to GetAllExperience View
            else
            {
                return RedirectToAction("ErrorFound", "Home");
            }

        }

        public IActionResult DeleteExperience(int Id)
        {
            // Check: if the deleted experience is not a existing experience, return Error
            if (repo.isNewExperience(Id))
            {
                return RedirectToAction("ErrorFound", "Home");
            }
            else
            {
                // If the deleted experience is existing experience, then call repository to delete it from database system.
                repo.DeleteExperience(Id);
                return RedirectToAction("GetAllExperience");
            }

        }
    }
}
