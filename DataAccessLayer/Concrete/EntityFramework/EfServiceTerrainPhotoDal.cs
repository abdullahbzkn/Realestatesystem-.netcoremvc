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
    public class EfServiceTerrainPhotoDal : GenericRepository<ServiceTerrainPhoto>, IServiceTerrainPhotoDal
    {
        public List<ServiceTerrainPhoto> GetByServiceTerrainId(int serviceTerrainId)
        {
            using (var context = new REstateContext())
            {
                return context.ServiceTerrainPhotos.Where(x => x.ServiceTerrainId == serviceTerrainId).ToList();
            }
        }
    }
}
