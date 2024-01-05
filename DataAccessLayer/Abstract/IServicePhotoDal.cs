using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IServicePhotoDal : IGenericDal<ServicePhoto>
    {
        List<ServicePhoto> GetByServiceHousingId(int serviceHousingId);
        List<ServicePhoto> GetByServiceTerrainId(int serviceTerrainId);
    }
}
