using ProfileManagement.Models;
using ProfileManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProfileManagement.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private ExperienceContext _context;

        public ExperienceRepository(ExperienceContext context)
        {
            _context = context;
        }

        // Create/Add new experience into DB context
        public void CreateExperience(ExperienceViewModel experienceViewModel)
        {
            _context.Experience.Add(new Experience
            {
                //Id = experienceViewModel.Id,
                CompanyName = experienceViewModel.CompanyName,
                JobName = experienceViewModel.JobName,
                JobDescription = experienceViewModel.JobDescription
            });
            _context.SaveChanges();
        }

        // Get/List all the existing experience 
        public List<Experience> GetExperience()
        {
            return _context.Experience.ToList();
        }

        // Get the specific experience with id is euqual to id number passed in.
        public Experience GetExperience(int Id)
        {
            var experience = _context.Experience.FirstOrDefault(e => e.Id == Id);          
            return experience;           
        }

        // Get experience model from DB context by passing in a id number
        public Experience GetExperienceModel(int Id)
        {
            var experience = _context.Experience.FirstOrDefault(e => e.Id == Id);
            return experience;
        }

        // Update the specific experience 
        public void UpdateExperience(ExperienceViewModel experienceViewModel)
        {
            var experience = _context.Experience.FirstOrDefault(e => e.Id == experienceViewModel.Id);
            experience.CompanyName = experienceViewModel.CompanyName;
            experience.JobName = experienceViewModel.JobName;
            experience.JobDescription = experienceViewModel.JobDescription;
            _context.SaveChanges();
        }

        // Delete the specific experience which id is equal to the id number passed in
        public void DeleteExperience(int Id)
        {
            var job = _context.Experience.FirstOrDefault(e => e.Id == Id);
            if (job != null)
            {
                _context.Remove(job);
                _context.SaveChanges();
            }
        }

        public bool isNewExperience(int Id)
        {
            var experienceModel = _context.Experience.Where(e => e.Id == Id).SingleOrDefault();
            if (experienceModel != null)
                return false;
            else
                return true;
        }

        public int GetMaxId()
        {
            var id = _context.Experience.Max(e => e.Id);
            return id ;
        }
    }
}
