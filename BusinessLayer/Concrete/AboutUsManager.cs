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
    public class AboutUsManager : IAboutUsService
    {
        private readonly IAboutUsDal _aboutUsDal;

        public AboutUsManager(IAboutUsDal aboutUsDal)
        {
            _aboutUsDal = aboutUsDal;
        }

        public void Delete(AboutUs t)
        {
            _aboutUsDal.Delete(t);
        }

        public AboutUs GetById(int id)
        {
            return _aboutUsDal.GetById(id);
        }

        public List<AboutUs> GetListAll()
        {
            return _aboutUsDal.GetListAll();
        }

        public void Insert(AboutUs t)
        {
            _aboutUsDal.Insert(t);
        }

        public void Update(AboutUs t)
        {
            _aboutUsDal.Update(t);
        }
    }
}
