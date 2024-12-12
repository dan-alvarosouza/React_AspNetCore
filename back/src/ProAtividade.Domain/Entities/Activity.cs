using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAtividade.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ConclusionDate { get; set; }
        public Priority Priority { get; set; }

        public Activity() => CreationDate = DateTime.Now;
        public Activity(int id, string title, string description) : this()
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public void Conclusion()
        {
            if (ConclusionDate == null)
                ConclusionDate = DateTime.Now;
            else
                throw new Exception("Atividade já concluída!");



        }
    }
}