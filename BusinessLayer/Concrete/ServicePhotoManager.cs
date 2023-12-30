using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
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

        public ServicePhotoManager(IServicePhotoDal servicePhotoDal)
        {
            _servicePhotoDal = servicePhotoDal;
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
    }
}
