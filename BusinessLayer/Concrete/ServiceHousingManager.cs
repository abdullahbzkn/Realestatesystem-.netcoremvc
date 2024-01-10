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
    public class ServiceHousingManager : IServiceHousingService
    {
        private readonly IServiceHousingDal _serviceHousingDal;
        private readonly IServiceHousingPhotoService _servicePhotoService; 

        private readonly REstateContext _context;


        public ServiceHousingManager(IServiceHousingDal serviceHousingDal, IServiceHousingPhotoService servicePhotoService, REstateContext context)
        {
            _serviceHousingDal = serviceHousingDal;
            _servicePhotoService = servicePhotoService;
            _context = context;
        }

        public void Delete(ServiceHousing t)
        {
            //ServicePhotos'u silelim
            var servicePhotos = _servicePhotoService.GetListAll().Where(x => x.ServiceHousingId == t.ServiceHousingID).ToList();
            foreach (var photo in servicePhotos)
            {
                _servicePhotoService.Delete(photo);
            }
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

        public void ServiceHousingStatusToChange(int id)
        {
            _serviceHousingDal.ServiceHousingStatusToChange(id);
        }

        public void Update(ServiceHousing t)
        {
            _serviceHousingDal.Update(t);
        }
    }
}
