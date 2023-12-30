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
    public class ServiceMapManager: IServiceMapService
    {
        private readonly IServiceMapDal _serviceMapDal;
        private readonly REstateContext _context;

        public ServiceMapManager(IServiceMapDal serviceMapDal, REstateContext context)
        {
            _serviceMapDal = serviceMapDal;
            _context = context;
        }

        public void Delete(ServiceMap t)
        {
            _serviceMapDal.Delete(t);
        }

        public ServiceMap GetById(int id)
        {
            return _serviceMapDal.GetById(id);
        }

        public List<ServiceMap> GetListAll()
        {
            return _serviceMapDal.GetListAll();
        }

        public void Insert(ServiceMap t)
        {
            _serviceMapDal.Insert(t);
        }

        public void Update(ServiceMap t)
        {
            _serviceMapDal.Update(t);
        }
    }
}
