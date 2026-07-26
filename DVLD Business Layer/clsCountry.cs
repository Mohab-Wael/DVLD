
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Data_Access_Layer;


namespace DVLD_Business_Layer
{
    public class clsCountry
    {
      public int ID { get; set; }
      public string CountryName { get; set; }


      public clsCountry()
      {
            this.ID = -1;
            this.CountryName = "";
      }

      private clsCountry(int CountryID,string CountryName)
      {
         this.ID = CountryID;
         this.CountryName = CountryName;
      }


      public static clsCountry Find(int CountryID)
      {
            string CountryName = "";

            if(clsCountryData.GetCountryInfoByID(CountryID,ref CountryName))
                return new clsCountry(CountryID, CountryName);
            else
                return null;
              
      }

      public static clsCountry Find(string CountryName)
      {
            int CountryID = -1;

            if(clsCountryData.GetCountryInfoByName( ref CountryID,CountryName))
                return new clsCountry(CountryID, CountryName);
            else
                return null;
     
      }

      public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }


    }
}
