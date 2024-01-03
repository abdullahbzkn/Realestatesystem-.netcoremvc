using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        public void ContactStatusToChange(int id)
        {
            using var context = new REstateContext();
            Contact contact = context.Contacts.Find(id);
            if (contact.OkunduBilgisi == true)
            {
                contact.OkunduBilgisi = false;
            }
            else
            {
                contact.OkunduBilgisi = true;
            }
            context.SaveChanges();
        }
    }
}
