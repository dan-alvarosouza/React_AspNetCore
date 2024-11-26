using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Models;

namespace ProAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        [HttpGet]
        public Activity Get()
        {
            return new Activity() ;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"Meu primeiro método GET com parâmetro {id}";
        }

        [HttpPost]
        public string Post()
        {
            return "Meu primeiro método POST";
        }

        [HttpPut]
        public string Put()
        {
            return "Meu primeiro método PUT";
        }

        [HttpDelete]
        public string Delete(){
            return "Meu primeiro método DELETE";
        }

    }
}