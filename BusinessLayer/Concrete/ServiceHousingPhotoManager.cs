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
    public class ServiceHousingPhotoManager: IServiceHousingPhotoService
    {
        private readonly IServiceHousingPhotoDal _serviceHousingPhotoDal;
        private readonly REstateContext _context;

        public ServiceHousingPhotoManager(IServiceHousingPhotoDal serviceHousingPhotoDal, REstateContext context)
        {
            _serviceHousingPhotoDal = serviceHousingPhotoDal;
            _context = context;
        }

        public void Delete(ServiceHousingPhoto t)
        {
            _serviceHousingPhotoDal.Delete(t);
        }

        public ServiceHousingPhoto GetById(int id)
        {
            return _serviceHousingPhotoDal.GetById(id);
        }

        public List<ServiceHousingPhoto> GetListAll()
        {
            return _serviceHousingPhotoDal.GetListAll();
        }

        public void Insert(ServiceHousingPhoto t)
        {
            _serviceHousingPhotoDal.Insert(t);
        }

        public void Update(ServiceHousingPhoto t)
        {
            _serviceHousingPhotoDal.Update(t);
        }

        //public ServicePhoto GetByServiceHousingId(int serviceHousingId)
        //{
        //    try
        //    {
        //        if (serviceHousingId > 0)
        //        {
        //            var servicePhoto = _context.ServicePhotos.FirstOrDefault(x => x.ServiceHousingId == serviceHousingId);
        //            if (servicePhoto != null)
        //            {
        //                return servicePhoto;
        //            }
        //            else
        //            {
        //                // Eğer servicePhoto null ise, null yerine başka bir değer ya da hata durumunu işleyebilirsiniz.
        //                // Örneğin:
        //                throw new InvalidOperationException($"ServicePhoto not found for ServiceHousingId: {serviceHousingId}");
        //            }
        //        }

        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Hata Detayı: {ex.ToString()}");
        //        throw;
        //    }

        //}


        public List<ServiceHousingPhoto> GetByServiceHousingId(int serviceHousingId)
        {
            return _serviceHousingPhotoDal.GetByServiceHousingId(serviceHousingId);
        }
    }
}
