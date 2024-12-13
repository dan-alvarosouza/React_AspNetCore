using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Services;


namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;
        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            try
            {
                var activities = await _activityService.GetAllActivitiesAsync();
                if (activities == null) return NoContent();

                return Ok(activities);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Atividades. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var activity = await _activityService.GetActivityByIdAsync(id);
                if (activity == null) return NoContent();

                return Ok(activity);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Atividade {id}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public Activity Post(Activity activity)
        {
            _context.Activities.Add(activity);
            if (_context.SaveChanges() > 0)
                return _context.Activities.FirstOrDefault(act => act.Id == activity.Id);
            else
                throw new Exception("Você não conseguiu adicionar uma nova atividade.");
            
        }

        [HttpPut("{id}")]
        public Activity Put(int id, Activity activity)
        {
            if (activity.Id != id) throw new Exception("Você está tentando atualizar a atividade errada.");

            _context.Update(activity);
            if (_context.SaveChanges() > 0)
                return _context.Activities.FirstOrDefault(act => act.Id == id);
            else
                return new Activity();
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var activity = _context.Activities.FirstOrDefault(act => act.Id == id);
            if (activity == null) throw new Exception("Você está tentando deletar uma atividade que não existe.");

            _context.Remove(activity);

            return _context.SaveChanges() > 0;
        }

    }
}