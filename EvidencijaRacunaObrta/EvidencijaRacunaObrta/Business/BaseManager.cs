using EvidencijaRacunaObrta.Models.ObrtModels;

namespace EvidencijaRacunaObrta.Business
{
    public class ModelManagerBase
    {
        public EvidencijaContext db;
        public int UserId { get; set; }

        public ModelManagerBase(EvidencijaContext db, int userId)
        {
            this.UserId = userId;

            if (db == null)
            {
                this.db = new EvidencijaContext();
            }
            else
            {
                this.db = db;
            }
        }
    }
}