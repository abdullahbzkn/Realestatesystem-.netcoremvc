using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfServicePhotoDal : GenericRepository<ServicePhoto>, IServicePhotoDal
    {
        public ServicePhoto GetByServiceHousingId(int serviceHousingId)
        {
            using (var context = new REstateContext())
            {
                return context.ServicePhotos.FirstOrDefault(x => x.ServiceHousingId == serviceHousingId);
            }
        }

        public ServicePhoto GetByServiceTerrainId(int serviceTerrainId)
        {
            using (var context = new REstateContext())
            {
                return context.ServicePhotos.FirstOrDefault(x => x.ServiceHousingId == serviceTerrainId);
            }
        }

    }
}
