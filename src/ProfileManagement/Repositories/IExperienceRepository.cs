using ProfileManagement.Models;
using ProfileManagement.ViewModels;
using System.Collections.Generic;

namespace ProfileManagement.Repositories
{
    public interface IExperienceRepository
    {
        void CreateExperience(ExperienceViewModel experienceViewModel);
        Experience GetExperience(int Id);
        List<Experience> GetExperience();
        Experience GetExperienceModel(int Id);
        void UpdateExperience(ExperienceViewModel experienceViewModel);
        void DeleteExperience(int Id);
        bool isNewExperience(int Id);
        int GetMaxId();
    }
}
