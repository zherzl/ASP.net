using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ModelLibrary.Entities;
using DAL_EF;

namespace FootballService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class FootballService : IFootballService
    {
        

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public TeamsResponse GetTeamsData(TeamsResponse composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Team> GetAllTeamsData()
        {
            using (FootballContext db = new FootballContext())
            {
                return db.Teams.ToList();
            }
        }

        public void AddTeam(Team team)
        {
            using (FootballContext db = new FootballContext())
            {
                db.Teams.Add(team);
                db.SaveChanges();
            }
        }

        public void AddTeamRange(List<Team> teams)
        {
            using (FootballContext db = new FootballContext())
            {
                db.Teams.AddRange(teams);
                db.SaveChanges();
            }
        }
    }
}
