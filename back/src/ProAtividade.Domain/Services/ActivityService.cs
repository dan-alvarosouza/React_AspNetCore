using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Services;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.Domain.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepo _activityRepo;
        private readonly IGeneralRepo _generalRepo;

        public ActivityService(IActivityRepo activityRepo, IGenerealRepo generalRepo)
        {
            _activityRepo = activityRepo;
            _generalRepo = generalRepo;
        }
        public Task<Activity> AddActivity(Activity model)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> UpdateActivity(Activity model)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> FinishActivity(Activity model)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> DeleteActivity(int activityId)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> GetActivityByIdAsync(int activityId)
        {
            throw new NotImplementedException();
        }

        public Task<Activity[]> GetAllActivitiesAsync()
        {
            throw new NotImplementedException();
        }
    }
}