using FootballManagerAPI.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.Entities
{
    public class Coach:Person,IEntity
    {
        public ICollection<Tactic> Tactics { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
