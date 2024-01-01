using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfServiceHousingDal : GenericRepository<ServiceHousing>, IServiceHousingDal
    {
        public void ServiceHousingStatusToChange(int id)
        {
            using var context = new REstateContext();
            ServiceHousing serviceHousing = context.ServiceHousings.Find(id);
            if (serviceHousing.Status == true)
            {
                serviceHousing.Status = false;
            }
            else
            {
                serviceHousing.Status = true;
            }
            context.SaveChanges();
        }

    }
}
