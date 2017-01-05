using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Entities
{
    [DataContract]
    public class Link
    {
        [DeserializeAs(Name = "self")]
        public string Self { get; set; }
        [DeserializeAs(Name = "teams")]
        public string Teams { get; set; }
        [DeserializeAs(Name = "fixtures")]
        public string Fixtures { get; set; }
        [DeserializeAs(Name = "leagueTable")]
        public string LeagueTable { get; set; }

        //"_links": {
        //    "self": {
        //        "href": "http://api.football-data.org/v1/competitions/424"
        //    },
        //    "teams": {
        //        "href": "http://api.football-data.org/v1/competitions/424/teams"
        //    },
        //    "fixtures": {
        //        "href": "http://api.football-data.org/v1/competitions/424/fixtures"
        //    },
        //    "leagueTable": {
        //        "href": "http://api.football-data.org/v1/competitions/424/leagueTable"
        //    }
       
    }

    [DataContract]
    public class LinkTeams
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DeserializeAs(Name = "self")]
        public string Self { get; set; }

        [DataMember]
        [DeserializeAs(Name = "competition")]
        public string Competition { get; set; }

        [DataMember]
        public int TeamsId { get; set; }

        [DataMember]
        [ForeignKey("TeamsId")]
        public virtual Teams Teams { get; set; }
    }
}
