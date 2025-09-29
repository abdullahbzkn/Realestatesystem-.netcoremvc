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
    public class ServiceInfoManager : IServiceInfoService
    {
        private readonly IServiceInfoDal _serviceInfoDal;
        private readonly REstateContext _context;


        public ServiceInfoManager(IServiceInfoDal serviceInfoDal, REstateContext context)
        {
            _serviceInfoDal = serviceInfoDal;
            _context = context;
        }

        public void Delete(ServiceInfo t)
        {
            _serviceInfoDal.Delete(t);
        }

        public ServiceInfo GetById(int id)
        {
            return _serviceInfoDal.GetById(id);
        }

        public List<ServiceInfo> GetListAll()
        {
            return _serviceInfoDal.GetListAll();
        }

        public void Insert(ServiceInfo t)
        {
            _serviceInfoDal.Insert(t);
        }

        public void Update(ServiceInfo t)
        {
            _serviceInfoDal.Update(t);
        }
    }
}
