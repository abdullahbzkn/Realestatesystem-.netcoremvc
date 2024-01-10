using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServiceTerrainPhoto
    {
        [Key]
        public int ServiceTerrainPhotoID { get; set; }
        public string? FotografYolu { get; set; }
        public int? ServiceTerrainId { get; set; }
        public virtual ServiceTerrain ServiceTerrain { get; set; }
    }
}
