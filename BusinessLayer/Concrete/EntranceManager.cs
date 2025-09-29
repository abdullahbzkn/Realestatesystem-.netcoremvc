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
    public class EntranceManager:IEntranceService
    {
        private readonly IEntranceDal _entranceDal;

        public EntranceManager(IEntranceDal entranceDal)
        {
            _entranceDal = entranceDal;
        }

        public void Delete(Entrance t)
        {
            _entranceDal.Delete(t);
        }

        public Entrance GetById(int id)
        {
            return _entranceDal.GetById(id);
        }

        public List<Entrance> GetListAll()
        {
            return _entranceDal.GetListAll();
        }

        public void Insert(Entrance t)
        {
            _entranceDal.Insert(t);
        }

        public void Update(Entrance t)
        {
            _entranceDal.Update(t);
        }
    }
}
