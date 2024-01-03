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
    public class EfServiceTerrainDal : GenericRepository<ServiceTerrain>, IServiceTerrainDal
    {
        public void ServiceTerrainStatusToChange(int id)
        {
            using var context = new REstateContext();
            ServiceTerrain serviceTerrain = context.ServiceTerrains.Find(id);
            if (serviceTerrain.Status == true)
            {
                serviceTerrain.Status = false;
            }
            else
            {
                serviceTerrain.Status = true;
            }
            context.SaveChanges();
        }
    }
}
