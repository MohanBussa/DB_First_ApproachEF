using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trial.Interface;

namespace Trial.Service
{
    public class CountryCodeService : ICountryCodeService
    {
        private IGenericRepository<CountryCode> managementEntities;
        public CountryCodeService(IGenericRepository<CountryCode> managementEntities)
        {
            this.managementEntities = managementEntities;
        }
        public List<CountryCode> GetCountryCodeList()
        {
            List<CountryCode> countryCodeList = new List<CountryCode>();
            var countrycode = managementEntities.GetAllList();

            foreach (var country in countrycode)
            {
                CountryCode countryCode = new CountryCode();
                countryCode.Id = country.Id;
                countryCode.Name = country.Name;
                countryCode.Code = country.Code;
                countryCode.IsActive = country.IsActive;

                countryCodeList.Add(countryCode);
            }
            return countryCodeList;
        }
        public CountryCode AddOrUpdateCountryCode(CountryCode contrycode)
        {
            var CodeData = managementEntities.GetById(contrycode.Id);
            if (CodeData == null)
            {

                CountryCode countrycode = new CountryCode();

                countrycode.Name = contrycode.Name;
                countrycode.Code = contrycode.Code;

                countrycode.IsActive = contrycode.IsActive == true ? true : false;
                managementEntities.Insert(contrycode);
                managementEntities.Save();
                return contrycode;
            }

            else
            {

                CodeData.Name = contrycode.Name;
                CodeData.Code = contrycode.Code;

                CodeData.IsActive = contrycode.IsActive;
                managementEntities.Save();
                return contrycode;
            }
        }
        public CountryCode DeleteCountryCode(CountryCode country)
        {
            if (country != null)
            {
                CountryCode std = managementEntities.GetById(country.Id);
                std.IsActive = false;
                managementEntities.Save();
                return country;
            }
            return country;
        }
        public CountryCode GetCountryCodeById(int id)
        {
            CountryCode code = new CountryCode();
            var data = managementEntities.GetById(id);

            if (data != null)
            {
                code.Id = data.Id;
                code.Name = data.Name;
                code.Code = data.Code;

                code.IsActive = data.IsActive;

            }
            return code;
        }
    }
}