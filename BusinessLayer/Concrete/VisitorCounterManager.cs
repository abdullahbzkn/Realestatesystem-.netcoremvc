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
    public class VisitorCounterManager :IVisitorCounterService
    {
        private readonly IVisitorCounterDal _visitorCounterDal;

        public VisitorCounterManager(IVisitorCounterDal visitorCounterDal)
        {
            _visitorCounterDal = visitorCounterDal;
        }

        public void Delete(VisitorCounter t)
        {
            _visitorCounterDal.Delete(t);
        }

        public VisitorCounter GetById(int id)
        {
            return _visitorCounterDal.GetById(id);
        }

        public List<VisitorCounter> GetListAll()
        {
            return _visitorCounterDal.GetListAll();
        }

        public void Insert(VisitorCounter t)
        {
            _visitorCounterDal.Insert(t);
        }

        public void Update(VisitorCounter t)
        {
            _visitorCounterDal.Update(t);
        }
    }
}
