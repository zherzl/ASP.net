using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.ServiceModel.Web;


namespace ModelLibrary.Entities
{

    [DataContract]
    [Table("dbo.TeamsMeta")]
    public class Teams
    {

        //http://api.football-data.org/v1/competitions/398/teams

        public static string GetTeamsForCompetitionLink(string apiVerzija, int competitionId)
        {
            return string.Format("{0}/competitions/{1}/teams", apiVerzija, competitionId);
        }

        public Teams()
        {
            _links = new List<LinkTeams>();
            teams = new List<Team>();
        }


        [Key] [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int count { get; set; }

        [DataMember]
        public List<Team> teams { get; set; }

        [DataMember]
        public List<LinkTeams> _links { get; set; }
    }


    [DataContract]
    [Table("dbo.Team")]
    public class Team
    {
        public Team()
        {
        }

        //{
        //            "id": 66,
        //            "name": "Manchester United FC",
        //            "shortName": "ManU",
        //            "squadMarketValue": "377,250,000 €",
        //            "crestUrl": "http://upload.wikimedia.org/wikipedia/de/d/da/Manchester_United_FC.svg"
        //        },

        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DeserializeAs(Name = "id")]
        public int? SourceId { get; set; }

        [DataMember]
        [DeserializeAs(Name = "name")]
        public string Name { get; set; }

        [DataMember]
        [DeserializeAs(Name = "shortName")]
        public string ShortName { get; set; }

        [DataMember]
        [DeserializeAs(Name = "squadMarketValue")]
        public string SquadMarketValue { get; set; }

        [DataMember]
        [DeserializeAs(Name = "crestUrl")]
        public string CrestUrl { get; set; }

        //[DataMember]
        //public int TeamsId { get; set; }

        //[DataMember]
        //[ForeignKey("TeamsId")]
        //public virtual Teams Teams { get; set; }
    }
}
