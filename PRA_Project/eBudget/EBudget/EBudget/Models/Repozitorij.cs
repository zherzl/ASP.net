using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace EBudget.Models
{
    public class Repozitorij
    {

        public static void SpremiPrihod(PrihodTrosak prihod)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlHelper.ExecuteNonQuery(cs, "SpremiPrihod", prihod.Iznos, prihod.DatumVrijeme, prihod.Aktivno,prihod.UserId, prihod.KategorijaID,prihod.ValutaID);
            
        }

        public static void SpremiTrosak(PrihodTrosak trosak)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlHelper.ExecuteNonQuery(cs, "SpremiPrihod", trosak.Iznos, trosak.DatumVrijeme, trosak.Aktivno, trosak.UserId, trosak.KategorijaID, trosak.ValutaID);

        }

        public static void UpdateTrosak(PrihodTrosak trosak)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlHelper.ExecuteNonQuery(cs, "UpdateTrosak", trosak.IDPrihodTrosak, trosak.Iznos, trosak.DatumVrijeme);
 
        }

        public static void UpdatePrihod(PrihodTrosak prihod)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlHelper.ExecuteNonQuery(cs, "UpdatePrihod", prihod.IDPrihodTrosak, prihod.Iznos, prihod.DatumVrijeme);
        }

        public static void DodajKategoriju(string Naziv, string TipKategorijaID, int UserId)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlHelper.ExecuteNonQuery(cs, "DodajKategoriju", Naziv, int.Parse(TipKategorijaID) , UserId);
            
        }

        public static void UpdateIme(int UserId, string Ime)
        {
            string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

            SqlHelper.ExecuteNonQuery(cs, "UpdateIme", UserId, Ime);
        }
    }
}