using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServiceInfo
    {
        [Key]
        public int ServiceInfoID { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public int IlanNo { get; set; }

        public virtual ICollection<ServiceHousing> ServiceHousings { get; set; }
        public virtual ICollection<ServiceTerrain> ServiceTerrains { get; set; }
        public virtual ICollection<ServicePhoto> ServicePhotos { get; set; }
    }
}
