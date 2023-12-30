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
    public class ServicePhotoManager: IServicePhotoService
    {
        private readonly IServicePhotoDal _servicePhotoDal;
        private readonly REstateContext _context;

        public ServicePhotoManager(IServicePhotoDal servicePhotoDal, REstateContext context)
        {
            _servicePhotoDal = servicePhotoDal;
            _context = context;
        }

        public void Delete(ServicePhoto t)
        {
            _servicePhotoDal.Delete(t);
        }

        public ServicePhoto GetById(int id)
        {
            return _servicePhotoDal.GetById(id);
        }

        public List<ServicePhoto> GetListAll()
        {
            return _servicePhotoDal.GetListAll();
        }

        public void Insert(ServicePhoto t)
        {
            _servicePhotoDal.Insert(t);
        }

        public void Update(ServicePhoto t)
        {
            _servicePhotoDal.Update(t);
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


        public ServicePhoto GetByServiceHousingId(int serviceHousingId)
        {
            return _servicePhotoDal.GetByServiceHousingId(serviceHousingId);
        }



    }
}
