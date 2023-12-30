using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
        private readonly REstateContext _context;

        public ServiceTerrainManager(IServiceTerrainDal serviceTerrainDal, REstateContext context)
        {
            _serviceTerrainDal = serviceTerrainDal;
            _context = context;
        }

        public void Delete(ServiceTerrain t)
        {
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

        public void Update(ServiceTerrain t)
        {
            _serviceTerrainDal.Update(t);
        }
    }
}
