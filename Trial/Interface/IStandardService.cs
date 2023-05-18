using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trial.Interface
{
    public interface IStandardService
    {
        List<Standard> GetStandardList();
        Standard AddOrUpdateStandard(Standard standard);
        Standard DeleteStandard(Standard standard);
        Standard GetStandardById(int id);

    }
}