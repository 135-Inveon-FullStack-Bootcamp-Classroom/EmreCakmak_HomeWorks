using FootballManagerAPI.ServiceAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ITeamService TeamService { get; set; }
        public IFootballerService FootballerService { get; set; }
        public IPositionService PositionService { get; set; }
        public ITacticService TacticService { get; set; }
        public ICoachService CoachService { get; set; }
        Task SaveChangesAsync();
    }
}
