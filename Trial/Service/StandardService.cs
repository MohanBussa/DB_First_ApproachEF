using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trial.Interface;

namespace Trial.Service
{
    public class StandardService: IStandardService
    {

        private IGenericRepository<Standard> managementEntities;
        public StandardService(IGenericRepository<Standard> managementEntities)
        {
            this.managementEntities = managementEntities;
        }
        public List<Standard> GetStandardList()
        {
            List<Standard> standardlist = new List<Standard>();
            var standad = managementEntities.GetAllList();

            foreach (var std in standad)
            {
                Standard standard = new Standard();
                standard.Id = std.Id;
                standard.Name = std.Name;
                standard.IsActive = std.IsActive;

                standardlist.Add(standard);
            }
            return standardlist;
          
        }
        public Standard AddOrUpdateStandard(Standard standard)
        {
            var StdData = managementEntities.GetById(standard.Id);
            if (StdData == null)
            {

                Standard std = new Standard();

                std.Name = standard.Name;
                std.IsActive = standard.IsActive == true ? true : false;
                managementEntities.Insert(std);
                managementEntities.Save();
                return standard;
            }

            else
            {

                StdData.Name = standard.Name;
                StdData.IsActive = standard.IsActive;
                managementEntities.Save();
                return standard;
            }
        }
        public Standard DeleteStandard(Standard standard)
        {
            if (standard != null)
            {
                Standard std = managementEntities.GetById(standard.Id);
                std.IsActive = false;
                managementEntities.Save();
                return standard;
            }
            return standard;
        }
        public Standard GetStandardById(int id)
        {
            Standard standard = new Standard();
            var data = managementEntities.GetById(id);

            if (data != null)
            {
                standard.Id = data.Id;
                standard.Name = data.Name;
                standard.IsActive = data.IsActive;

            }
            return standard;
        }
    }
}