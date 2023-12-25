using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServiceMap
    {
        [Key]
        public int ServiceMapID { get; set; }
        public string Mahalle { get; set; }
        public string Koy { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }

        public virtual ICollection<ServiceHousing> ServiceHousings { get; set; }
        public virtual ICollection<ServiceTerrain> ServiceTerrains { get; set; }
    }
}
