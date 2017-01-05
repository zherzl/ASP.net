using EvidencijaRacunaObrta.Models.ObrtModels;

namespace EvidencijaRacunaObrta.Business
{
    public class ModelManagerBase
    {
        public EvidencijaContext db;

        public ModelManagerBase(EvidencijaContext db)
        {
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