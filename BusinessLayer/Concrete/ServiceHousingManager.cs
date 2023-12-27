using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ServiceHousingManager : IServiceHousingService
    {
        private readonly IServiceHousingDal _serviceHousingDal;

        public ServiceHousingManager(IServiceHousingDal serviceHousingDal)
        {
            _serviceHousingDal = serviceHousingDal;
        }

        public void Delete(ServiceHousing t)
        {
            _serviceHousingDal.Delete(t);
        }

        public ServiceHousing GetById(int id)
        {
            return _serviceHousingDal.GetById(id);
        }

        public List<ServiceHousing> GetListAll()
        {
            return _serviceHousingDal.GetListAll();
        }

        public void Insert(ServiceHousing t)
        {
            _serviceHousingDal.Insert(t);
        }

        public void Update(ServiceHousing t)
        {
            _serviceHousingDal.Update(t);
        }
    }
}
