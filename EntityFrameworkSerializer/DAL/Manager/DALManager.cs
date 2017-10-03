using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class DALManager
    {
        MyModel db = new MyModel();
        public DrzaveResponse GetDrzave()
        {
            DrzaveResponse response = new DrzaveResponse();

            try
            {
                response.Drzave = db.Drzavas.ToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public CitiesResponse GetCities()
        {
            CitiesResponse response = new CitiesResponse();

            try
            {
                response.Cities = db.Grads.ToList();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
