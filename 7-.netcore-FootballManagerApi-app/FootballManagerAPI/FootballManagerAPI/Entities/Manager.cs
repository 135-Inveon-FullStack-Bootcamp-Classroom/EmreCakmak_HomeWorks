using FootballManagerAPI.EntityBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.Entities
{
    public class Manager:Person,IEntity
    {
        public ManagementPosition ManagementPosition { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
