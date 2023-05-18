using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trial.Interface
{
    public interface ICountryCodeService
    {
        List<CountryCode> GetCountryCodeList();
        CountryCode AddOrUpdateCountryCode(CountryCode contrycode);
        CountryCode DeleteCountryCode(CountryCode country);
        CountryCode GetCountryCodeById(int id);



    }
}