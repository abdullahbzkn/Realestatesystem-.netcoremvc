using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServicePhoto
    {
        [Key]
        public int ServicePhotoID { get; set; }
        public string FotografYolu { get; set; }

        public int? ServiceHousingId { get; set; }
        public virtual ServiceHousing ServiceHousing { get; set; }

        public int? ServiceTerrainId { get; set; }
        public virtual ServiceTerrain ServiceTerrain { get; set; }
    }
}
