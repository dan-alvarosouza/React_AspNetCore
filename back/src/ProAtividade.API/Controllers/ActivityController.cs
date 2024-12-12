using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Entities;


namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly DataContext _context;
        public ActivityController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IEnumerable<Activity> Get(){
            return _context.Activities;
        }

        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return _context.Activities.FirstOrDefault(act => act.Id == id);
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