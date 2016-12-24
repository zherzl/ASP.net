using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDataSource.Models
{
    public class TeamModel
    {
        //        {
        //    "count": 20,
        //    "teams":
        //    [
        //        {
        //            "id": 66,
        //            "name": "Manchester United FC",
        //            "shortName": "ManU",
        //            "squadMarketValue": "377,250,000 €",
        //            "crestUrl": "http://upload.wikimedia.org/wikipedia/de/d/da/Manchester_United_FC.svg"
        //        },
        //        {
        //            "id": 73,
        //            "name": "Tottenham Hotspur FC",
        //            "shortName": "Spurs",
        //            "squadMarketValue": "288,000,000 €",
        //            "crestUrl": "http://upload.wikimedia.org/wikipedia/de/b/b4/Tottenham_Hotspur.svg"
        //        },
        //        {
        //    { ... },
        //    { ... }
        //}

        public int count { get; set; }
        public List<Team> teams { get; set; }
    }
}
