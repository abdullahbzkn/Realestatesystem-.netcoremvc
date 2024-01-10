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
    public class EfServiceHousingPhotoDal : GenericRepository<ServiceHousingPhoto>, IServiceHousingPhotoDal
    {
        public List<ServiceHousingPhoto> GetByServiceHousingId(int serviceHousingId)
        {
            using (var context = new REstateContext())
            {
                return context.ServiceHousingPhotos.Where(x => x.ServiceHousingId == serviceHousingId).ToList();
            }
        }
    }
}
