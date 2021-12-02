using FootballManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Coach> Coaches { get; set; }
        public DbSet<ManagementPosition> ManagementPositions { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<NationalTeam> NationalTeams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Tactic> Tactics { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
