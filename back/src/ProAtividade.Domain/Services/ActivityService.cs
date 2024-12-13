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

        public ActivityService(IActivityRepo activityRepo)
        {
            _activityRepo = activityRepo;
        }
        public async Task<Activity> AddActivity(Activity model)
        {
            if (await _activityRepo.GetByTitleAsync(model.Title) != null)
                throw new Exception("Já existe uma atividade com esse título.");
            
            if (await _activityRepo.GetByIdAsync(model.Id) == null)
            {
                _activityRepo.Add(model);
                if(await _activityRepo.SaveChangesAsync())
                    return model;
            }

            return null;
        }

        public async Task<Activity> UpdateActivity(Activity model)
        {
            if (model.ConclusionDate != null)
                throw new Exception("Não dá para atualizar uma atividade já concluída.");

            if (await _activityRepo.GetByIdAsync(model.Id) == null)
            {
                _activityRepo.Update(model);
                if(await _activityRepo.SaveChangesAsync())
                    return model;
            }

            return null;
        }

        public async Task<bool> FinishActivity(Activity model)
        {
            if (model != null)
            {
                model.Finish();
                _activityRepo.Update<Activity>(model);
                return await _activityRepo.SaveChangesAsync();
            }

            return false;
        }

        public async Task<bool> DeleteActivity(int activityId)
        {
            var activity = await _activityRepo.GetByIdAsync(activityId);
            if (activity == null) throw new Exception("Esta atividade não existe.");

            _activityRepo.Delete(activity);
            return await _activityRepo.SaveChangesAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int activityId)
        {
            try
            {
                var activity = await _activityRepo.GetByIdAsync(activityId);
                if (activity == null) return null;

                return activity;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Activity[]> GetAllActivitiesAsync()
        {
            try
            {
                var activities = await _activityRepo.GetAllAsync();
                if (activities == null) return null;

                return activities;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}