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
    public class ServiceTerrainManager : IServiceTerrainService
    {
        private readonly IServiceTerrainDal _serviceTerrainDal;
        private readonly IServiceHousingPhotoService _servicePhotoService;

        private readonly REstateContext _context;

        public ServiceTerrainManager(IServiceTerrainDal serviceTerrainDal,IServiceHousingPhotoService servicePhotoService, REstateContext context)
        {
            _serviceTerrainDal = serviceTerrainDal;
            _servicePhotoService = servicePhotoService;
            _context = context;
        }

        public void Delete(ServiceTerrain t)
        {
            //ServicePhotos'u silelim
            var servicePhotos = _servicePhotoService.GetListAll().Where(x => x.ServiceHousingId == t.ServiceTerrainID).ToList();
            foreach (var photo in servicePhotos)
            {
                _servicePhotoService.Delete(photo);
            }
            _serviceTerrainDal.Delete(t);
        }

        public ServiceTerrain GetById(int id)
        {
            return _serviceTerrainDal.GetById(id);
        }

        public List<ServiceTerrain> GetListAll()
        {
            return _serviceTerrainDal.GetListAll();
        }

        public void Insert(ServiceTerrain t)
        {
            _serviceTerrainDal.Insert(t);
        }

        public void ServiceTerrainStatusToChange(int id)
        {
            _serviceTerrainDal.ServiceTerrainStatusToChange(id);
        }

        public void Update(ServiceTerrain t)
        {
            _serviceTerrainDal.Update(t);
        }


    }
}
