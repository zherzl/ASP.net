
using ModelLibrary.Entities;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FootballService
{
    [ServiceContract]
    public interface IFootballService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        List<Team> GetAllTeamsData();

        [OperationContract]
        void AddTeam(Team team);

        [OperationContract]
        void AddTeamRange(List<Team> teams);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class TeamsResponse
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
