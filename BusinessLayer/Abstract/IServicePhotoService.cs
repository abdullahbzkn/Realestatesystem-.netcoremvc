using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IServicePhotoService : IGenericService<ServicePhoto>
    {
        ServicePhoto GetByServiceHousingId(int serviceHousingId);
        ServicePhoto GetByServiceTerrainId(int serviceTerrainId);

    }
}
