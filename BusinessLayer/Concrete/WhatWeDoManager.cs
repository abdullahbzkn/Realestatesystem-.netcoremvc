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
    public class WhatWeDoManager : IWhatWeDoService
    {
        private readonly IWhatWeDoDal _whatWeDoDal;

        public WhatWeDoManager(IWhatWeDoDal whatWeDoDal)
        {
            _whatWeDoDal = whatWeDoDal;
        }

        public void Delete(WhatWeDo t)
        {
            _whatWeDoDal.Delete(t);
        }

        public WhatWeDo GetById(int id)
        {
            return _whatWeDoDal.GetById(id);
        }

        public List<WhatWeDo> GetListAll()
        {
            return _whatWeDoDal.GetListAll();
        }

        public void Insert(WhatWeDo t)
        {
            _whatWeDoDal.Insert(t);
        }

        public void Update(WhatWeDo t)
        {
            _whatWeDoDal.Update(t);
        }
    }
}
