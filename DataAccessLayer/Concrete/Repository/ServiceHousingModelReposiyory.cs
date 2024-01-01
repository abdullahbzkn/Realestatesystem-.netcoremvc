//using DataAccessLayer.Abstract;
//using DataAccessLayer.Contexts;
//using EntityLayer.Concrete;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAccessLayer.Concrete.Repository
//{
//    public class ServiceHousingModelReposiyory<M> : IGenericDal<M> where M : Model , new()
//    {
//        public void Delete(M viewModel)
//        {
//            using var context = new REstateContext();
//            context.Remove(viewModel);
//            context.SaveChanges();
//        }

//        public M GetById(int id)
//        {
//            using var context = new REstateContext();
//            var serviceHousing = context.Set<M>().Find(id);
//            return new M
//            {
//                ServiceHousing = serviceHousing,
//                ServicePhoto = ,
//                ServiceMap = serviceHousing.ServiceMap,
//                ServiceInfo = serviceHousing.ServiceInfo
//            };
//        }

//        public List<M> GetListAll()
//        {
//            using var context = new REstateContext();
//            return context.Set<M>().ToList();
//        }

//        public void Insert(M viewModel)
//        {
//            using var context = new REstateContext();
//            context.Add(viewModel);
//            context.SaveChanges();
//        }

//        public void Update(M viewModel)
//        {
//            using var context = new REstateContext();
//            context.Update(viewModel);
//            context.SaveChanges();
//        }
//    }
//}



    
       
    