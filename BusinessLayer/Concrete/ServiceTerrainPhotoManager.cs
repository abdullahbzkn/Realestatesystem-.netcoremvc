using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceTerrainPhotoManager : IServiceTerrainPhotoService
    {
        private readonly IServiceTerrainPhotoDal _serviceTerrainPhotoDal;
        private readonly REstateContext _context;

        public ServiceTerrainPhotoManager(IServiceTerrainPhotoDal serviceTerrainPhotoDal, REstateContext context)
        {
            _serviceTerrainPhotoDal = serviceTerrainPhotoDal;
            _context = context;
        }

        public void Delete(ServiceTerrainPhoto t)
        {
            _serviceTerrainPhotoDal.Delete(t);
        }

        public ServiceTerrainPhoto GetById(int id)
        {
            return _serviceTerrainPhotoDal.GetById(id);
        }

        public List<ServiceTerrainPhoto> GetListAll()
        {
            return _serviceTerrainPhotoDal.GetListAll();
        }

        public void Insert(ServiceTerrainPhoto t)
        {
            _serviceTerrainPhotoDal.Insert(t);
        }

        public void Update(ServiceTerrainPhoto t)
        {
            _serviceTerrainPhotoDal.Update(t);
        }


        public List<ServiceTerrainPhoto> GetByServiceTerrainId(int serviceTerrainId)
        {
            return _serviceTerrainPhotoDal.GetByServiceTerrainId(serviceTerrainId);
        }
    }
}
