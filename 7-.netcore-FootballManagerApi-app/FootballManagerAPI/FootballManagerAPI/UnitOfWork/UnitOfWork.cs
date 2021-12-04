using FootballManagerAPI.Data;
using FootballManagerAPI.ServiceAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ITeamService teamService, IFootballerService footballerService, ICoachService coachService, ITacticService tacticService, IPositionService positionService, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            this.FootballerService = footballerService;
            this.TeamService = teamService;
            this.CoachService = coachService;
            this.TacticService = tacticService;
            this.PositionService = positionService;
        }

        public ITeamService TeamService { get; set; }
        public IFootballerService FootballerService { get; set; }
        public ICoachService CoachService { get; set; }
        public ITacticService TacticService { get; set; }
        public IPositionService PositionService { get; set; }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
